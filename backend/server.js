import express from 'express';
import cors from 'cors';
import fs from 'fs';
import path from 'path';
import { fileURLToPath } from 'url';
import nodemailer from 'nodemailer';
import dotenv from 'dotenv';
import mongoose from 'mongoose';
import dns from 'dns';
import crypto from 'crypto';

dotenv.config();

// Optional DNS override for environments where Node cannot resolve mongodb+srv.
// Leave unset by default; some networks block direct DNS to public resolvers.
const mongoDnsServers = (process.env.MONGODB_DNS_SERVERS || process.env.MONGO_DNS_SERVERS || '')
  .split(',')
  .map(server => server.trim())
  .filter(Boolean);

if (mongoDnsServers.length > 0) {
  try {
    dns.setServers(mongoDnsServers);
    console.log(`Configured MongoDB DNS servers: ${mongoDnsServers.join(', ')}`);
  } catch (dnsErr) {
    console.warn('Could not override DNS servers:', dnsErr.message);
  }
}

const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const app = express();
const PORT = process.env.PORT || 3001;

// Middleware
app.use(cors());
app.use(express.json());

// Ensure data directory exists (for offline fallback JSON storage)
const dataDir = path.join(__dirname, 'data');
if (!fs.existsSync(dataDir)) {
  fs.mkdirSync(dataDir);
}

// ==========================================
// 1. MONGODB ATLAS SCHEMAS & MODELS
// ==========================================

// User Schema
const userSchema = new mongoose.Schema({
  id: { type: String }, // Custom generated ID for backward compatibility
  uid: { type: String, unique: true, sparse: true }, // Firebase UID
  username: { type: String, required: true, unique: true }, // Email
  password: { type: String }, // Optional for social login users
  name: { type: String },
  role: { type: String, default: 'Student' },
  phoneNumber: { type: String },
  otpCode: { type: String },
  otpExpiresAt: { type: String }
}, { timestamps: true });

// Resource Schema
const resourceSchema = new mongoose.Schema({
  id: { type: String, unique: true },
  type: { type: String, required: true }, // 'documentsData', 'midtermExams', 'finalExams'
  title: { type: String, required: true },
  date: { type: String },
  category: { type: String },
  categoryLabel: { type: String },
  image: { type: String },
  pdf: { type: String },
  desc: { type: String },
  externalUrl: { type: String },
  professor: { type: String },
  professorName: { type: String },
  hasDetailRoute: { type: Boolean }
}, { timestamps: true });

// Message Schema
const messageSchema = new mongoose.Schema({
  id: { type: String },
  name: { type: String, required: true },
  email: { type: String, required: true },
  subject: { type: String },
  message: { type: String, required: true }
}, { timestamps: true });

// Subscriber Schema
const subscriberSchema = new mongoose.Schema({
  email: { type: String, required: true, unique: true }
}, { timestamps: true });

// Payment Schema for payOS webhook tracking
const paymentSchema = new mongoose.Schema({
  orderCode: { type: Number, required: true, unique: true },
  amount: { type: Number, default: 0 },
  description: { type: String },
  status: { type: String, default: 'PENDING' },
  paymentLinkId: { type: String },
  checkoutUrl: { type: String },
  qrCode: { type: String },
  reference: { type: String },
  paidAt: { type: String },
  canceledAt: { type: String },
  webhookData: { type: mongoose.Schema.Types.Mixed }
}, { timestamps: true });

const User = mongoose.model('User', userSchema);
const Resource = mongoose.model('Resource', resourceSchema);
const Message = mongoose.model('Message', messageSchema);
const Subscriber = mongoose.model('Subscriber', subscriberSchema);
const Payment = mongoose.model('Payment', paymentSchema);

// ==========================================
// 2. MONGODB ATLAS CONNECTION & HYBRID STATUS
// ==========================================
let isMongoDBConnected = false;

// Helpers to read and write JSON files (Offline Fallback)
const readJSONFile = (filePath, defaultValue = []) => {
  try {
    if (!fs.existsSync(filePath)) {
      return defaultValue;
    }
    const content = fs.readFileSync(filePath, 'utf8');
    return JSON.parse(content || JSON.stringify(defaultValue));
  } catch (error) {
    console.error(`Lỗi khi đọc file JSON tại ${filePath}:`, error);
    return defaultValue;
  }
};

const writeJSONFile = (filePath, data) => {
  try {
    fs.writeFileSync(filePath, JSON.stringify(data, null, 2), 'utf8');
    return true;
  } catch (error) {
    console.error(`Lỗi khi ghi file JSON tại ${filePath}:`, error);
    return false;
  }
};

const normalizeResourceItem = (type, item) => ({
  id: item.id || (type.substring(0, 2) + '-' + Date.now()),
  type,
  title: item.title,
  date: item.date,
  category: item.category,
  categoryLabel: item.categoryLabel,
  image: item.image,
  pdf: item.pdf,
  desc: item.desc,
  externalUrl: item.externalUrl,
  professor: item.professor,
  professorName: item.professorName,
  hasDetailRoute: item.hasDetailRoute
});

const getLocalResourceSeedItems = () => {
  const localResources = readJSONFile(path.join(dataDir, 'resources.json'), { documentsData: [], midtermExams: [], finalExams: [] });
  const seedItems = [];
  const types = ['documentsData', 'midtermExams', 'finalExams'];

  types.forEach(type => {
    if (localResources[type] && Array.isArray(localResources[type])) {
      localResources[type].forEach(item => {
        seedItems.push(normalizeResourceItem(type, item));
      });
    }
  });

  return seedItems;
};

const paymentsFilePath = path.join(dataDir, 'payments.json');

const sortObjectByKey = (object) => Object.keys(object || {})
  .sort()
  .reduce((result, key) => {
    result[key] = object[key];
    return result;
  }, {});

const convertPayOSDataToQueryString = (data) => Object.keys(data || {})
  .filter((key) => data[key] !== undefined)
  .map((key) => {
    let value = data[key];
    if (Array.isArray(value)) {
      value = JSON.stringify(value.map(item => sortObjectByKey(item)));
    }
    if ([null, undefined, 'null', 'undefined'].includes(value)) {
      value = '';
    }
    return `${key}=${value}`;
  })
  .join('&');

const createPayOSSignature = (data, checksumKey) => {
  const signedContent = convertPayOSDataToQueryString(sortObjectByKey(data || {}));

  return crypto
    .createHmac('sha256', checksumKey)
    .update(signedContent)
    .digest('hex');
};

const normalizePayOSDescription = (description) => {
  const normalized = String(description || 'PAYOS')
    .normalize('NFD')
    .replace(/[\u0300-\u036f]/g, '')
    .replace(/[\u0111\u0110]/g, 'D')
    .toUpperCase()
    .replace(/[^A-Z0-9]/g, '');

  return (normalized || 'PAYOS').slice(0, 9);
};

const createPayOSPaymentSignature = (paymentData) => {
  const checksumKey = process.env.PAYOS_CHECKSUM_KEY;
  if (!checksumKey) {
    throw new Error('PAYOS_CHECKSUM_KEY is not configured');
  }

  return createPayOSSignature({
    amount: paymentData.amount,
    cancelUrl: paymentData.cancelUrl,
    description: paymentData.description,
    orderCode: paymentData.orderCode,
    returnUrl: paymentData.returnUrl
  }, checksumKey);
};

const callPayOS = async (pathName, options = {}) => {
  const clientId = process.env.PAYOS_CLIENT_ID;
  const apiKey = process.env.PAYOS_API_KEY;

  if (!clientId || !apiKey) {
    throw new Error('PAYOS_CLIENT_ID or PAYOS_API_KEY is not configured');
  }

  const response = await fetch(`https://api-merchant.payos.vn${pathName}`, {
    ...options,
    headers: {
      'Accept': 'application/json',
      'Content-Type': 'application/json',
      'x-client-id': clientId,
      'x-api-key': apiKey,
      ...(options.headers || {})
    }
  });

  const result = await response.json().catch(() => ({}));
  if (!response.ok) {
    throw new Error(`payOS ${response.status}: ${JSON.stringify(result)}`);
  }

  return result;
};

const safeCompareSignature = (expected, received) => {
  if (!expected || !received) return false;
  const expectedBuffer = Buffer.from(expected, 'utf8');
  const receivedBuffer = Buffer.from(received, 'utf8');
  return expectedBuffer.length === receivedBuffer.length && crypto.timingSafeEqual(expectedBuffer, receivedBuffer);
};

const verifyPayOSWebhookSignature = (body) => {
  const checksumKey = process.env.PAYOS_CHECKSUM_KEY;
  if (!checksumKey) {
    throw new Error('PAYOS_CHECKSUM_KEY is not configured');
  }

  if (!body?.data || !body.signature) {
    return false;
  }

  const expectedSignature = createPayOSSignature(body.data, checksumKey);
  return safeCompareSignature(expectedSignature, body.signature);
};

const normalizePaymentResponse = (payment) => ({
  orderCode: payment.orderCode,
  amount: payment.amount,
  description: payment.description,
  status: payment.status,
  paymentLinkId: payment.paymentLinkId,
  checkoutUrl: payment.checkoutUrl,
  qrCode: payment.qrCode,
  reference: payment.reference,
  paidAt: payment.paidAt,
  canceledAt: payment.canceledAt,
  createdAt: payment.createdAt,
  updatedAt: payment.updatedAt
});

const isFinalPaymentStatus = (status) => ['PAID', 'CANCELLED', 'CANCELED', 'EXPIRED'].includes(String(status || '').toUpperCase());

const findStoredPayment = async (orderCode) => {
  if (isMongoDBConnected) {
    return Payment.findOne({ orderCode })
      .select('-_id orderCode amount description status paymentLinkId checkoutUrl qrCode reference paidAt canceledAt createdAt updatedAt')
      .lean();
  }

  const payments = readJSONFile(paymentsFilePath, []);
  return payments.find(item => Number(item.orderCode) === orderCode) || null;
};

const findStoredPaymentByLinkId = async (paymentLinkId) => {
  if (!paymentLinkId) return null;

  if (isMongoDBConnected) {
    return Payment.findOne({ paymentLinkId })
      .select('-_id orderCode amount description status paymentLinkId checkoutUrl qrCode reference paidAt canceledAt createdAt updatedAt')
      .lean();
  }

  const payments = readJSONFile(paymentsFilePath, []);
  return payments.find(item => item.paymentLinkId === paymentLinkId) || null;
};

const saveLocalPaymentFromWebhook = (body, paymentUpdate) => {
  const payments = readJSONFile(paymentsFilePath, []);
  const existingIndex = payments.findIndex(payment => Number(payment.orderCode) === paymentUpdate.orderCode);
  const now = new Date().toISOString();

  if (existingIndex >= 0) {
    payments[existingIndex] = {
      ...payments[existingIndex],
      ...paymentUpdate,
      webhookData: body,
      updatedAt: now
    };
  } else {
    payments.push({
      orderCode: paymentUpdate.orderCode,
      amount: paymentUpdate.amount || 0,
      description: paymentUpdate.description || '',
      status: paymentUpdate.status || 'PENDING',
      paymentLinkId: paymentUpdate.paymentLinkId || null,
      checkoutUrl: null,
      qrCode: null,
      reference: paymentUpdate.reference || null,
      paidAt: paymentUpdate.paidAt || null,
      canceledAt: paymentUpdate.canceledAt || null,
      createdAt: now,
      updatedAt: now,
      webhookData: body
    });
  }

  writeJSONFile(paymentsFilePath, payments);
};

const saveLocalPaymentFromCreate = (paymentData, payosResponse) => {
  const payments = readJSONFile(paymentsFilePath, []);
  const orderCode = Number(paymentData.orderCode);
  const existingIndex = payments.findIndex(payment => Number(payment.orderCode) === orderCode);
  const now = new Date().toISOString();
  const update = {
    orderCode,
    amount: Number(paymentData.amount) || 0,
    description: paymentData.description || '',
    status: paymentData.status || 'PENDING',
    paymentLinkId: paymentData.paymentLinkId || null,
    checkoutUrl: paymentData.checkoutUrl || null,
    qrCode: paymentData.qrCode || null,
    reference: paymentData.reference || null,
    paidAt: paymentData.paidAt || null,
    canceledAt: paymentData.canceledAt || null,
    payosResponse,
    updatedAt: now
  };

  if (existingIndex >= 0) {
    payments[existingIndex] = {
      ...payments[existingIndex],
      ...update
    };
  } else {
    payments.push({
      ...update,
      createdAt: now
    });
  }

  writeJSONFile(paymentsFilePath, payments);
};

const persistPaymentUpdate = async (paymentUpdate, sourcePayload = null) => {
  if (isMongoDBConnected) {
    await Payment.findOneAndUpdate(
      { orderCode: paymentUpdate.orderCode },
      { $set: paymentUpdate },
      { upsert: true, new: true }
    );
    return;
  }

  saveLocalPaymentFromCreate(paymentUpdate, sourcePayload || { code: '00', desc: 'local update', data: paymentUpdate });
};

const getPayOSRedirectOrderCode = (query) => {
  const raw = query.orderCode || query.order_code || query.ordercode;
  const orderCode = Number(raw);
  return Number.isFinite(orderCode) ? orderCode : null;
};

const renderPaymentResultPage = ({ title, message, color, orderCode, status }) => {
  const safeOrder = orderCode ? `Ma don hang: ${orderCode}` : 'Khong tim thay ma don hang tren URL.';
  const safeStatus = status ? `Trang thai: ${status}` : '';

  return `<!doctype html>
<html lang="vi">
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width,initial-scale=1" />
  <title>${title}</title>
  <style>
    body{margin:0;min-height:100vh;display:flex;align-items:center;justify-content:center;background:#151936;color:#e5e7eb;font-family:Segoe UI,Arial,sans-serif}
    .card{width:min(580px,calc(100vw - 40px));padding:46px 36px;border-radius:26px;background:#202840;border:1px solid #34405f;box-shadow:0 28px 90px rgba(0,0,0,.35);text-align:center}
    .icon{width:92px;height:92px;margin:0 auto 24px;border-radius:50%;border:3px solid ${color};display:flex;align-items:center;justify-content:center;color:${color};font-size:56px;line-height:1}
    h1{margin:0 0 14px;color:${color};font-size:34px}
    p{margin:8px 0;color:#b9c0d4;font-size:19px;line-height:1.55}
    .meta{margin-top:18px;padding:12px 14px;border-radius:12px;background:#151936;color:#dbeafe;font-size:15px}
    button,a{display:block;width:100%;box-sizing:border-box;margin-top:20px;padding:16px 18px;border-radius:14px;border:0;background:${color};color:#fff;font-weight:700;font-size:17px;text-decoration:none;cursor:pointer}
    a.secondary{margin-top:14px;background:#2b344d;border:1px solid #4b556b}
  </style>
</head>
<body>
  <main class="card">
    <div class="icon">${status === 'PAID' ? '✓' : '×'}</div>
    <h1>${title}</h1>
    <p>${message}</p>
    <div class="meta">${safeOrder}<br>${safeStatus}</div>
    <button onclick="window.close()">Dong Cua So</button>
    <a class="secondary" href="/">Ve Trang Hoc Tap</a>
  </main>
  <script>setTimeout(function(){ try { window.close(); } catch(e) {} }, 6000);</script>
</body>
</html>`;
};

// Auto-Migration Function
const runAutoMigration = async () => {
  try {
    console.log('--- Đang thực hiện tự động di trú dữ liệu (Auto-Migration) ---');

    // 1. Di trú Users
    const userCount = await User.countDocuments();
    if (userCount === 0) {
      console.log('MongoDB collection User trống. Bắt đầu import từ users.json...');
      const localUsers = readJSONFile(path.join(dataDir, 'users.json'), []);
      if (localUsers.length > 0) {
        const usersToInsert = localUsers.map(u => ({
          id: u.id,
          uid: u.uid || undefined,
          username: u.username,
          password: u.password,
          name: u.name,
          role: u.role || 'Student',
          phoneNumber: u.phoneNumber || undefined,
          createdAt: u.createdAt ? new Date(u.createdAt) : new Date(),
          updatedAt: u.updatedAt ? new Date(u.updatedAt) : new Date()
        }));
        await User.insertMany(usersToInsert);
        console.log(`>>> Đã di trú thành công ${usersToInsert.length} người dùng lên MongoDB! <<<`);
      }
    } else {
      console.log('Collection User trên MongoDB đã có dữ liệu. Bỏ qua di trú User.');
    }

    // 2. Di trú Resources
    const resourceCount = await Resource.countDocuments();
    const resourcesToInsert = getLocalResourceSeedItems();

    if (resourceCount === 0) {
      console.log('MongoDB collection Resource trống. Bắt đầu import từ resources.json...');

      if (resourcesToInsert.length > 0) {
        await Resource.insertMany(resourcesToInsert);
        console.log(`>>> Đã di trú thành công ${resourcesToInsert.length} tài liệu/đề thi lên MongoDB! <<<`);
      }
    } else {
      let insertedCount = 0;
      let metadataUpdatedCount = 0;

      for (const seedItem of resourcesToInsert) {
        const existing = await Resource.findOne({ id: seedItem.id });
        if (!existing) {
          await Resource.create(seedItem);
          insertedCount += 1;
          continue;
        }

        const metadataUpdates = {};
        ['professor', 'professorName', 'hasDetailRoute'].forEach(field => {
          if (seedItem[field] !== undefined && existing[field] === undefined) {
            metadataUpdates[field] = seedItem[field];
          }
        });

        if (seedItem.type === 'documentsData' || seedItem.type === 'finalExams') {
          ['title', 'date', 'desc', 'hasDetailRoute'].forEach(field => {
            if (seedItem[field] !== undefined && existing[field] !== seedItem[field]) {
              metadataUpdates[field] = seedItem[field];
            }
          });
        }

        if (seedItem.type === 'documentsData') {
          ['category', 'categoryLabel', 'image', 'pdf', 'externalUrl'].forEach(field => {
            if (seedItem[field] !== undefined && existing[field] !== seedItem[field]) {
              metadataUpdates[field] = seedItem[field];
            }
          });
        }

        if (Object.keys(metadataUpdates).length > 0) {
          await Resource.updateOne({ id: seedItem.id }, { $set: metadataUpdates });
          metadataUpdatedCount += 1;
        }
      }

      console.log(`Collection Resource đã có dữ liệu. Đã bổ sung ${insertedCount} tài nguyên seed còn thiếu, cập nhật metadata ${metadataUpdatedCount} tài nguyên.`);
    }

    // 3. Di trú Subscribers
    const subscriberCount = await Subscriber.countDocuments();
    if (subscriberCount === 0) {
      console.log('MongoDB collection Subscriber trống. Bắt đầu import từ subscribers.json...');
      const localSubscribers = readJSONFile(path.join(dataDir, 'subscribers.json'), []);
      if (localSubscribers.length > 0) {
        const subsToInsert = localSubscribers.map(email => ({
          email,
          createdAt: new Date()
        }));
        await Subscriber.insertMany(subsToInsert);
        console.log(`>>> Đã di trú thành công ${subsToInsert.length} email đăng ký lên MongoDB! <<<`);
      }
    } else {
      console.log('Collection Subscriber trên MongoDB đã có dữ liệu. Bỏ qua di trú Subscriber.');
    }

    // 4. Di trú Messages
    const messageCount = await Message.countDocuments();
    if (messageCount === 0) {
      console.log('MongoDB collection Message trống. Bắt đầu import từ messages.json...');
      const localMessages = readJSONFile(path.join(dataDir, 'messages.json'), []);
      if (localMessages.length > 0) {
        const msgsToInsert = localMessages.map(m => ({
          id: m.id,
          name: m.name,
          email: m.email,
          subject: m.subject || 'Liên hệ từ website',
          message: m.message,
          createdAt: m.createdAt ? new Date(m.createdAt) : new Date()
        }));
        await Message.insertMany(msgsToInsert);
        console.log(`>>> Đã di trú thành công ${msgsToInsert.length} tin nhắn liên hệ lên MongoDB! <<<`);
      }
    } else {
      console.log('Collection Message trên MongoDB đã có dữ liệu. Bỏ qua di trú Message.');
    }

    console.log('--- Hoàn thành tự động di trú dữ liệu! ---');
  } catch (error) {
    console.error('!!! Gặp lỗi trong quá trình tự động di trú dữ liệu:', error);
  }
};

const mongoURI = process.env.MONGODB_DIRECT_URI || process.env.MONGO_DIRECT_URI || process.env.MONGODB_URI || process.env.MONGO_URI;

// Establish connection directly over internet
if (mongoURI) {
  console.log('Đang kết nối trực tiếp đến MongoDB Atlas qua internet...');
  mongoose.connect(mongoURI, { dbName: 'UEH_TCC' })
    .then(() => {
      isMongoDBConnected = true;
      console.log('======================================================');
      console.log('>>> KẾT NỐI THÀNH CÔNG ĐẾN MONGODB ATLAS (ONLINE) <<<');
      console.log('======================================================');
      runAutoMigration();
    })
    .catch((err) => {
      console.error('!!! Lỗi kết nối MongoDB Atlas:', err.message);
      if (mongoURI.startsWith('mongodb+srv://') && /querySrv|ENOTFOUND|ETIMEOUT|ECONNREFUSED/i.test(err.message)) {
        console.error('Goi y: URI mongodb+srv can DNS SRV. Neu Node khong resolve duoc, hay dung MONGODB_DIRECT_URI/MONGO_DIRECT_URI dang mongodb:// seedlist hoac cau hinh MONGODB_DNS_SERVERS.');
      }
      console.log('>>> Server hoạt động ở chế độ OFFLINE FALLBACK (đọc/ghi file JSON cục bộ) <<<');
    });
} else {
  console.log('Không tìm thấy cấu hình MONGODB_DIRECT_URI, MONGO_DIRECT_URI, MONGODB_URI hoặc MONGO_URI.');
  console.log('>>> Server hoạt động ở chế độ OFFLINE FALLBACK (đọc/ghi file JSON cục bộ) <<<');
}

// ==========================================
// 3. API ENDPOINTS & LOGIC
// ==========================================

// 1. Newsletter Subscription
app.post('/api/subscribe', async (req, res) => {
  const { email } = req.body;
  
  if (!email || !email.includes('@')) {
    return res.status(400).json({ success: false, message: 'Email không hợp lệ!' });
  }

  try {
    if (isMongoDBConnected) {
      const existing = await Subscriber.findOne({ email });
      if (existing) {
        return res.status(400).json({ success: false, message: 'Email này đã đăng ký nhận tin từ trước!' });
      }
      const newSub = new Subscriber({ email });
      await newSub.save();
      return res.json({ success: true, message: 'Đăng ký nhận bài viết mới thành công! Cảm ơn bạn.' });
    } else {
      const filePath = path.join(dataDir, 'subscribers.json');
      const subscribers = readJSONFile(filePath);
      
      if (subscribers.includes(email)) {
        return res.status(400).json({ success: false, message: 'Email này đã đăng ký nhận tin từ trước!' });
      }

      subscribers.push(email);
      if (writeJSONFile(filePath, subscribers)) {
        return res.json({ success: true, message: 'Đăng ký nhận bài viết mới thành công! Cảm ơn bạn.' });
      } else {
        return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lưu đăng ký.' });
      }
    }
  } catch (error) {
    console.error("Lỗi đăng ký email:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lưu đăng ký.' });
  }
});

// 2. Contact Message
app.post('/api/contact', async (req, res) => {
  const { name, email, subject, message } = req.body;

  if (!name || !email || !message) {
    return res.status(400).json({ success: false, message: 'Vui lòng điền đầy đủ các thông tin bắt buộc!' });
  }

  try {
    if (isMongoDBConnected) {
      const newMessage = new Message({
        id: Date.now().toString(),
        name,
        email,
        subject: subject || 'Liên hệ từ website',
        message
      });
      await newMessage.save();
      return res.json({ success: true, message: 'Tin nhắn của bạn đã được gửi đi thành công! Chúng tôi sẽ phản hồi sớm.' });
    } else {
      const filePath = path.join(dataDir, 'messages.json');
      const messages = readJSONFile(filePath);

      const newMessage = {
        id: Date.now().toString(),
        name,
        email,
        subject: subject || 'Liên hệ từ website',
        message,
        createdAt: new Date().toISOString()
      };

      messages.push(newMessage);
      if (writeJSONFile(filePath, messages)) {
        return res.json({ success: true, message: 'Tin nhắn của bạn đã được gửi đi thành công! Chúng tôi sẽ phản hồi sớm.' });
      } else {
        return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lưu tin nhắn.' });
      }
    }
  } catch (error) {
    console.error("Lỗi gửi tin nhắn liên hệ:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lưu tin nhắn.' });
  }
});

// 3. Dynamic Resources GET
app.get('/api/resources', async (req, res) => {
  try {
    if (isMongoDBConnected) {
      const items = await Resource.find({}).sort({ createdAt: -1 });
      const resources = {
        documentsData: items.filter(i => i.type === 'documentsData'),
        midtermExams: items.filter(i => i.type === 'midtermExams'),
        finalExams: items.filter(i => i.type === 'finalExams')
      };
      return res.json({ success: true, resources });
    } else {
      const filePath = path.join(dataDir, 'resources.json');
      const resources = readJSONFile(filePath, { documentsData: [], midtermExams: [], finalExams: [] });
      return res.json({ success: true, resources });
    }
  } catch (error) {
    console.error("Lỗi lấy tài liệu:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lấy tài liệu học tập.' });
  }
});

// 3. Dynamic Resources POST (Publish resource)
app.post('/api/resources', async (req, res) => {
  const { type, item, adminRole, uid, email } = req.body;

  try {
    let dbUser = null;
    
    if (isMongoDBConnected) {
      if (uid) {
        dbUser = await User.findOne({ uid });
      } else if (email) {
        dbUser = await User.findOne({ username: new RegExp(`^${email}$`, 'i') });
      }
    } else {
      const usersFilePath = path.join(dataDir, 'users.json');
      const users = readJSONFile(usersFilePath, []);
      dbUser = users.find(u => 
        (uid && u.uid === uid) || 
        (email && u.username && u.username.toLowerCase() === email.toLowerCase())
      );
    }

    // Role verification
    const isAuthorized = dbUser ? (dbUser.role === 'Admin') : (adminRole === 'Admin' && !uid);

    if (!isAuthorized) {
      return res.status(403).json({ success: false, message: 'Bạn không có quyền thực hiện hành động này (Từ chối bởi Server)!' });
    }

    if (!type || !item || !item.title) {
      return res.status(400).json({ success: false, message: 'Dữ liệu tài liệu không hợp lệ!' });
    }

    const finalId = item.id || (type.substring(0, 2) + '-' + Date.now());

    let finalDate = item.date;
    if (!finalDate) {
      const today = new Date();
      const dd = String(today.getDate()).padStart(2, '0');
      const mm = String(today.getMonth() + 1).padStart(2, '0');
      const yyyy = today.getFullYear();
      finalDate = `${dd}/${mm}/${yyyy}`;
    }

    const savedItem = {
      ...item,
      id: finalId,
      date: finalDate
    };

    if (isMongoDBConnected) {
      const newResource = new Resource({
        id: finalId,
        type: type,
        title: item.title,
        date: finalDate,
        category: item.category,
        categoryLabel: item.categoryLabel,
        image: item.image,
        pdf: item.pdf,
        desc: item.desc,
        externalUrl: item.externalUrl,
        professor: item.professor,
        professorName: item.professorName,
        hasDetailRoute: item.hasDetailRoute
      });
      await newResource.save();
      return res.json({ success: true, message: 'Đăng tải tài liệu thành công!', item: savedItem });
    } else {
      const filePath = path.join(dataDir, 'resources.json');
      const resources = readJSONFile(filePath, { documentsData: [], midtermExams: [], finalExams: [] });

      if (!resources[type]) {
        resources[type] = [];
      }

      resources[type].unshift(savedItem);

      if (writeJSONFile(filePath, resources)) {
        return res.json({ success: true, message: 'Đăng tải tài liệu thành công!', item: savedItem });
      } else {
        return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lưu tài liệu.' });
      }
    }
  } catch (error) {
    console.error("Lỗi đăng tải tài liệu:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lưu tài liệu.' });
  }
});

// 4. Real Signup API
app.post('/api/signup', async (req, res) => {
  const { username, password, name } = req.body;

  if (!username || !password || !name) {
    return res.status(400).json({ success: false, message: 'Vui lòng điền đầy đủ thông tin đăng ký!' });
  }

  try {
    if (isMongoDBConnected) {
      const userExists = await User.findOne({ username: new RegExp(`^${username}$`, 'i') });
      if (userExists) {
        return res.status(400).json({ success: false, message: 'Tên đăng nhập hoặc Email này đã tồn tại!' });
      }

      const userId = 'u-' + Date.now();
      const newUser = new User({
        id: userId,
        username,
        password, // Lưu mật khẩu text (mã hóa bcrypt có thể nâng cấp sau)
        name,
        role: 'Student'
      });
      await newUser.save();

      return res.json({
        success: true,
        message: 'Đăng ký tài khoản thành công!',
        user: {
          id: userId,
          username: newUser.username,
          name: newUser.name,
          role: newUser.role
        }
      });
    } else {
      const filePath = path.join(dataDir, 'users.json');
      const users = readJSONFile(filePath, []);

      const userExists = users.some(u => u.username.toLowerCase() === username.toLowerCase());
      if (userExists) {
        return res.status(400).json({ success: false, message: 'Tên đăng nhập hoặc Email này đã tồn tại!' });
      }

      const newUser = {
        id: 'u-' + Date.now(),
        username,
        password,
        name,
        role: 'Student',
        createdAt: new Date().toISOString()
      };

      users.push(newUser);
      if (writeJSONFile(filePath, users)) {
        return res.json({
          success: true,
          message: 'Đăng ký tài khoản thành công!',
          user: {
            id: newUser.id,
            username: newUser.username,
            name: newUser.name,
            role: newUser.role
          }
        });
      } else {
        return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi lưu tài khoản.' });
      }
    }
  } catch (error) {
    console.error("Lỗi đăng ký:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi đăng ký.' });
  }
});

// 5. Dynamic Database Login API
app.post('/api/login', async (req, res) => {
  const { username, password } = req.body;

  if (!username || !password) {
    return res.status(400).json({ success: false, message: 'Tên đăng nhập và mật khẩu không được bỏ trống!' });
  }

  try {
    let user = null;
    if (isMongoDBConnected) {
      user = await User.findOne({ 
        username: new RegExp(`^${username}$`, 'i'),
        password: password
      });
    } else {
      const filePath = path.join(dataDir, 'users.json');
      const users = readJSONFile(filePath, []);
      user = users.find(u => u.username.toLowerCase() === username.toLowerCase() && u.password === password);
    }

    if (!user) {
      return res.status(401).json({ success: false, message: 'Tên đăng nhập hoặc mật khẩu chưa chính xác!' });
    }

    return res.json({
      success: true,
      message: 'Đăng nhập thành công!',
      user: {
        id: user.id || user._id.toString(),
        username: user.username,
        name: user.name,
        role: user.role
      }
    });
  } catch (error) {
    console.error("Lỗi đăng nhập:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi đăng nhập.' });
  }
});

// 6. Firebase Auth Sync API
app.post('/api/auth/sync', async (req, res) => {
  const { uid, email, name, phoneNumber } = req.body;

  if (!uid) {
    return res.status(400).json({ success: false, message: 'Thiếu mã định danh UID từ Firebase!' });
  }

  try {
    if (isMongoDBConnected) {
      let user = await User.findOne({ uid });

      if (!user) {
        if (email) {
          user = await User.findOne({ username: new RegExp(`^${email}$`, 'i') });
        }

        if (user) {
          user.uid = uid;
          if (phoneNumber && !user.phoneNumber) {
            user.phoneNumber = phoneNumber;
          }
          await user.save();
        } else {
          const isAdminEmail = email && email.toLowerCase() === 'admin@ueh.edu.vn';
          const userId = 'u-' + Date.now();
          user = new User({
            id: userId,
            uid: uid,
            username: email || phoneNumber || uid,
            name: name || (email ? email.split('@')[0] : 'Người dùng OTP'),
            phoneNumber: phoneNumber || null,
            role: isAdminEmail ? 'Admin' : 'Student'
          });
          await user.save();
        }
      } else {
        let updated = false;
        if (name && user.name !== name) {
          user.name = name;
          updated = true;
        }
        if (phoneNumber && user.phoneNumber !== phoneNumber) {
          user.phoneNumber = phoneNumber;
          updated = true;
        }
        if (email && user.username !== email) {
          user.username = email;
          updated = true;
        }
        if (updated) {
          await user.save();
        }
      }

      return res.json({
        success: true,
        message: 'Đồng bộ tài khoản thành công!',
        user: {
          id: user.id || user._id.toString(),
          uid: user.uid,
          username: user.username,
          name: user.name,
          role: user.role,
          phoneNumber: user.phoneNumber
        }
      });
    } else {
      const filePath = path.join(dataDir, 'users.json');
      const users = readJSONFile(filePath, []);

      let user = users.find(u => u.uid === uid);

      if (!user) {
        if (email) {
          user = users.find(u => u.username && u.username.toLowerCase() === email.toLowerCase());
        }

        if (user) {
          user.uid = uid;
          if (phoneNumber && !user.phoneNumber) {
            user.phoneNumber = phoneNumber;
          }
          user.updatedAt = new Date().toISOString();
        } else {
          const isAdminEmail = email && email.toLowerCase() === 'admin@ueh.edu.vn';
          user = {
            id: 'u-' + Date.now(),
            uid: uid,
            username: email || phoneNumber || uid,
            name: name || (email ? email.split('@')[0] : 'Người dùng OTP'),
            phoneNumber: phoneNumber || null,
            role: isAdminEmail ? 'Admin' : 'Student',
            createdAt: new Date().toISOString()
          };
          users.push(user);
        }

        writeJSONFile(filePath, users);
      } else {
        let updated = false;
        if (name && user.name !== name) {
          user.name = name;
          updated = true;
        }
        if (phoneNumber && user.phoneNumber !== phoneNumber) {
          user.phoneNumber = phoneNumber;
          updated = true;
        }
        if (email && user.username !== email) {
          user.username = email;
          updated = true;
        }
        if (updated) {
          user.updatedAt = new Date().toISOString();
          writeJSONFile(filePath, users);
        }
      }

      return res.json({
        success: true,
        message: 'Đồng bộ tài khoản thành công!',
        user: {
          id: user.id,
          uid: user.uid,
          username: user.username,
          name: user.name,
          role: user.role,
          phoneNumber: user.phoneNumber
        }
      });
    }
  } catch (error) {
    console.error("Lỗi đồng bộ Firebase:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi đồng bộ tài khoản.' });
  }
});

// Configure Nodemailer Transporter for Email OTP
const createMailTransporter = () => {
  const host = process.env.EMAIL_HOST || 'smtp.gmail.com';
  const port = parseInt(process.env.EMAIL_PORT) || 587;
  const secure = process.env.EMAIL_SECURE === 'true';
  const user = process.env.EMAIL_USER;
  const pass = process.env.EMAIL_PASS;

  if (!user || !pass) {
    return null; // Mock Mode
  }

  return nodemailer.createTransport({
    host,
    port,
    secure,
    auth: { user, pass }
  });
};

// 7. Forgot Password - Generate & Send OTP
app.post('/api/auth/forgot-password', async (req, res) => {
  const { email } = req.body;

  if (!email || !email.includes('@')) {
    return res.status(400).json({ success: false, message: 'Đầu vào email không hợp lệ!' });
  }

  try {
    let user = null;
    const otpCode = Math.floor(100000 + Math.random() * 900000).toString();
    const otpExpiresAt = new Date(Date.now() + 10 * 60 * 1000).toISOString(); // 10 phút hiệu lực

    if (isMongoDBConnected) {
      user = await User.findOne({ username: new RegExp(`^${email}$`, 'i') });
      if (!user) {
        return res.status(404).json({ success: false, message: 'Không tìm thấy tài khoản nào liên kết với email này!' });
      }
      user.otpCode = otpCode;
      user.otpExpiresAt = otpExpiresAt;
      await user.save();
    } else {
      const filePath = path.join(dataDir, 'users.json');
      const users = readJSONFile(filePath, []);

      const userIndex = users.findIndex(u => u.username && u.username.toLowerCase() === email.toLowerCase());
      if (userIndex === -1) {
        return res.status(404).json({ success: false, message: 'Không tìm thấy tài khoản nào liên kết với email này!' });
      }

      user = users[userIndex];
      user.otpCode = otpCode;
      user.otpExpiresAt = otpExpiresAt;
      writeJSONFile(filePath, users);
    }

    const transporter = createMailTransporter();

    if (!transporter) {
      // Mock Mode: Print OTP to backend console
      console.log(`\n======================================================`);
      console.log(`[SMTP MOCK MODE] GỬI MÃ OTP QUÊN MẬT KHẨU`);
      console.log(`Email nhận: ${email}`);
      console.log(`Mã OTP 6 chữ số: ${otpCode}`);
      console.log(`Thời hạn: Hết hạn sau 10 phút (${new Date(otpExpiresAt).toLocaleTimeString()})`);
      console.log(`======================================================\n`);

      return res.json({
        success: true,
        message: 'Mã OTP đã được gửi về email của bạn! (Chế độ mô phỏng offline: Vui lòng xem mã OTP trong Terminal của Backend server)',
        isMock: true
      });
    }

    // Real SMTP Gửi Mail Mode
    const mailOptions = {
      from: `"Hệ thống Hỗ trợ Học tập UEH TCC" <${process.env.EMAIL_USER}>`,
      to: email,
      subject: '[UEH TCC] Mã OTP khôi phục mật khẩu tài khoản của bạn',
      html: `
        <div style="font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #e2e8f0; border-radius: 8px; background-color: #ffffff;">
          <div style="text-align: center; border-bottom: 2px solid #0d9488; padding-bottom: 15px; margin-bottom: 20px;">
            <h2 style="color: #0d9488; margin: 0;">UEH TCC STUDY HELPER</h2>
            <p style="color: #64748b; font-size: 14px; margin: 5px 0 0 0;">Hệ thống Khôi phục Mật khẩu Tự động</p>
          </div>
          
          <div style="line-height: 1.6; color: #334155;">
            <p>Chào <strong>${user.name || 'Sinh viên UEH'}</strong>,</p>
            <p>Chúng tôi nhận được yêu cầu khôi phục mật khẩu cho tài khoản của bạn tại UEH TCC Study Helper.</p>
            
            <div style="background-color: #f0fdfa; border: 1px dashed #0d9488; border-radius: 6px; padding: 20px; text-align: center; margin: 25px 0;">
              <p style="margin: 0 0 10px 0; font-size: 14px; color: #0f766e; text-transform: uppercase; font-weight: bold; letter-spacing: 1px;">Mã OTP xác thực của bạn là:</p>
              <span style="font-size: 32px; font-weight: 800; color: #0d9488; letter-spacing: 5px; display: inline-block;">${otpCode}</span>
              <p style="margin: 10px 0 0 0; font-size: 12px; color: #64748b;">(Mã này có hiệu lực trong vòng <strong>10 phút</strong> và chỉ sử dụng được 1 lần)</p>
            </div>
            
            <p>Nếu bạn không gửi yêu cầu này, vui lòng bỏ qua email này. Tài khoản của bạn vẫn an toàn và không bị thay đổi.</p>
            <p style="margin-top: 30px;">Trân trọng,<br><strong>Đội ngũ Kỹ thuật UEH TCC</strong></p>
          </div>
          
          <div style="margin-top: 30px; padding-top: 15px; border-top: 1px solid #e2e8f0; text-align: center; font-size: 11px; color: #94a3b8;">
            <p>Đây là email tự động từ hệ thống UEH TCC. Vui lòng không phản hồi lại email này.</p>
          </div>
        </div>
      `
    };

    await transporter.sendMail(mailOptions);
    return res.json({
      success: true,
      message: 'Mã xác thực OTP đã được gửi đến hòm thư email của bạn! Vui lòng kiểm tra (cả thư rác nếu chưa thấy).'
    });
  } catch (error) {
    console.error("Lỗi khi gửi email SMTP khôi phục mật khẩu:", error);
    return res.status(500).json({
      success: false,
      message: 'Gặp lỗi trong quá trình gửi mail qua SMTP server.'
    });
  }
});

// 8. Reset Password - Verify OTP & Update Password
app.post('/api/auth/reset-password', async (req, res) => {
  const { email, otpCode, newPassword } = req.body;

  if (!email || !otpCode || !newPassword) {
    return res.status(400).json({ success: false, message: 'Vui lòng cung cấp đầy đủ thông tin: email, mã OTP và mật khẩu mới!' });
  }

  try {
    if (isMongoDBConnected) {
      const user = await User.findOne({ username: new RegExp(`^${email}$`, 'i') });
      if (!user) {
        return res.status(404).json({ success: false, message: 'Không tìm thấy tài khoản liên kết với email này!' });
      }

      if (!user.otpCode || user.otpCode !== otpCode) {
        return res.status(400).json({ success: false, message: 'Mã xác thực OTP không chính xác!' });
      }

      const isExpired = new Date() > new Date(user.otpExpiresAt);
      if (isExpired) {
        return res.status(400).json({ success: false, message: 'Mã xác thực OTP đã hết hạn! Vui lòng gửi lại mã mới.' });
      }

      user.password = newPassword;
      user.otpCode = undefined;
      user.otpExpiresAt = undefined;
      await user.save();

      return res.json({
        success: true,
        message: 'Đổi mật khẩu tài khoản thành công! Bạn có thể sử dụng mật khẩu mới để đăng nhập ngay.'
      });
    } else {
      const filePath = path.join(dataDir, 'users.json');
      const users = readJSONFile(filePath, []);

      const userIndex = users.findIndex(u => u.username && u.username.toLowerCase() === email.toLowerCase());

      if (userIndex === -1) {
        return res.status(404).json({ success: false, message: 'Không tìm thấy tài khoản liên kết với email này!' });
      }

      const user = users[userIndex];

      if (!user.otpCode || user.otpCode !== otpCode) {
        return res.status(400).json({ success: false, message: 'Mã xác thực OTP không chính xác!' });
      }

      const isExpired = new Date() > new Date(user.otpExpiresAt);
      if (isExpired) {
        return res.status(400).json({ success: false, message: 'Mã xác thực OTP đã hết hạn! Vui lòng gửi lại mã mới.' });
      }

      user.password = newPassword;
      delete user.otpCode;
      delete user.otpExpiresAt;
      user.updatedAt = new Date().toISOString();

      if (writeJSONFile(filePath, users)) {
        return res.json({
          success: true,
          message: 'Đổi mật khẩu tài khoản thành công! Bạn có thể sử dụng mật khẩu mới để đăng nhập ngay.'
        });
      } else {
        return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi cập nhật mật khẩu mới.' });
      }
    }
  } catch (error) {
    console.error("Lỗi đặt lại mật khẩu:", error);
    return res.status(500).json({ success: false, message: 'Lỗi hệ thống khi cập nhật mật khẩu mới.' });
  }
});

// 9. payOS payment request API
app.post('/api/payos/create-payment', async (req, res) => {
  try {
    const amount = Number(req.body.amount);
    if (!Number.isInteger(amount) || amount <= 0) {
      return res.status(400).json({ code: 'BAD_AMOUNT', desc: 'amount must be a positive integer' });
    }

    const orderCode = Number(req.body.orderCode || Date.now());
    if (!Number.isInteger(orderCode) || orderCode <= 0) {
      return res.status(400).json({ code: 'BAD_ORDER_CODE', desc: 'orderCode must be a positive integer' });
    }

    const returnUrl = process.env.PAYOS_RETURN_URL || 'https://ueh-tcc-backend.onrender.com/payment/success';
    const cancelUrl = process.env.PAYOS_CANCEL_URL || 'https://ueh-tcc-backend.onrender.com/payment/cancel';
    const paymentRequest = {
      orderCode,
      amount,
      description: normalizePayOSDescription(req.body.description),
      buyerName: req.body.buyerName || '',
      returnUrl,
      cancelUrl
    };
    paymentRequest.signature = createPayOSPaymentSignature(paymentRequest);

    const payosResult = await callPayOS('/v2/payment-requests', {
      method: 'POST',
      body: JSON.stringify(paymentRequest)
    });

    if (payosResult?.data) {
      if (isMongoDBConnected) {
        await Payment.findOneAndUpdate(
          { orderCode },
          {
            $set: {
              orderCode,
              amount,
              description: paymentRequest.description,
              status: payosResult.data.status || 'PENDING',
              paymentLinkId: payosResult.data.paymentLinkId || null,
              checkoutUrl: payosResult.data.checkoutUrl || null,
              qrCode: payosResult.data.qrCode || null,
              webhookData: null
            }
          },
          { upsert: true, new: true }
        );
      } else {
        saveLocalPaymentFromCreate(payosResult.data, payosResult);
      }
    }

    return res.status(200).json(payosResult);
  } catch (error) {
    console.error('PayOS create payment error:', error);
    return res.status(500).json({ code: 'SERVER_ERROR', desc: error.message });
  }
});

app.get('/payment/cancel', async (req, res) => {
  let orderCode = getPayOSRedirectOrderCode(req.query);
  let storedPayment = null;
  if (!orderCode && req.query.id) {
    storedPayment = await findStoredPaymentByLinkId(req.query.id);
    orderCode = storedPayment ? Number(storedPayment.orderCode) : null;
  }

  if (orderCode) {
    storedPayment = storedPayment || await findStoredPayment(orderCode);
    await persistPaymentUpdate({
      orderCode,
      amount: Number(req.query.amount ?? storedPayment?.amount) || 0,
      description: req.query.description || storedPayment?.description || '',
      status: 'CANCELLED',
      paymentLinkId: req.query.id || req.query.paymentLinkId || storedPayment?.paymentLinkId || null,
      checkoutUrl: storedPayment?.checkoutUrl || null,
      qrCode: storedPayment?.qrCode || null,
      reference: req.query.reference || storedPayment?.reference || null,
      paidAt: storedPayment?.paidAt || null,
      canceledAt: new Date().toISOString(),
      redirectData: req.query
    }, {
      code: '00',
      desc: 'cancel redirect',
      data: req.query
    });
  }

  res
    .status(200)
    .type('html')
    .send(renderPaymentResultPage({
      title: 'Giao Dich Da Huy',
      message: 'Yeu cau thanh toan nay da bi huy. He thong da ghi nhan CANCELLED de WinForms doc lai trang thai.',
      color: '#ef5350',
      orderCode,
      status: 'CANCELLED'
    }));
});

app.get('/payment/success', async (req, res) => {
  let orderCode = getPayOSRedirectOrderCode(req.query);
  let storedPayment = null;
  if (!orderCode && req.query.id) {
    storedPayment = await findStoredPaymentByLinkId(req.query.id);
    orderCode = storedPayment ? Number(storedPayment.orderCode) : null;
  }

  if (orderCode) {
    storedPayment = storedPayment || await findStoredPayment(orderCode);
    await persistPaymentUpdate({
      orderCode,
      amount: Number(req.query.amount ?? storedPayment?.amount) || 0,
      description: req.query.description || storedPayment?.description || '',
      status: 'PAID',
      paymentLinkId: req.query.id || req.query.paymentLinkId || storedPayment?.paymentLinkId || null,
      checkoutUrl: storedPayment?.checkoutUrl || null,
      qrCode: storedPayment?.qrCode || null,
      reference: req.query.reference || storedPayment?.reference || null,
      paidAt: new Date().toISOString(),
      canceledAt: storedPayment?.canceledAt || null,
      redirectData: req.query
    }, {
      code: '00',
      desc: 'success redirect',
      data: req.query
    });
  }

  res
    .status(200)
    .type('html')
    .send(renderPaymentResultPage({
      title: 'Thanh Toan Thanh Cong',
      message: 'He thong da ghi nhan PAID de WinForms doc lai trang thai.',
      color: '#22c55e',
      orderCode,
      status: 'PAID'
    }));
});

// 10. payOS webhook receiver
app.get('/api/payos/webhook', (req, res) => {
  res.json({
    success: true,
    message: 'payOS webhook endpoint is ready. payOS will call this URL with POST.',
    method: 'POST',
    path: '/api/payos/webhook'
  });
});

app.post('/api/payos/webhook', async (req, res) => {
  const body = req.body;

  try {
    if (!body || !body.data) {
      return res.status(400).json({ success: false, message: 'Invalid payOS webhook body' });
    }

    const isValidSignature = verifyPayOSWebhookSignature(body);
    if (!isValidSignature) {
      console.warn('Rejected payOS webhook because signature is invalid');
      return res.status(400).json({ success: false, message: 'Invalid payOS signature' });
    }

    const orderCode = Number(body.data.orderCode);
    if (!Number.isFinite(orderCode)) {
      return res.status(400).json({ success: false, message: 'Invalid orderCode' });
    }

    const dataStatus = String(body.data.status || '').toUpperCase();
    const isCancelEvent = body.cancel === true ||
      body.data.cancel === true ||
      dataStatus.includes('CANCEL') ||
      String(body.code || '').toUpperCase().includes('CANCEL');
    const isPaid = !isCancelEvent && body.success === true && body.code === '00';
    const paymentUpdate = {
      orderCode,
      amount: Number(body.data.amount) || 0,
      description: body.data.description || '',
      status: isPaid ? 'PAID' : (isCancelEvent ? 'CANCELLED' : (body.data.status || 'PENDING')),
      paymentLinkId: body.data.paymentLinkId || null,
      reference: body.data.reference || null,
      paidAt: isPaid ? (body.data.transactionDateTime || new Date().toISOString()) : null,
      canceledAt: isCancelEvent ? (body.data.canceledAt || new Date().toISOString()) : null,
      webhookData: body
    };

    if (isMongoDBConnected) {
      await Payment.findOneAndUpdate(
        { orderCode },
        {
          $set: paymentUpdate,
          $setOnInsert: {
            checkoutUrl: null,
            qrCode: null
          }
        },
        { upsert: true, new: true }
      );
    } else {
      saveLocalPaymentFromWebhook(body, paymentUpdate);
    }

    return res.json({ success: true });
  } catch (error) {
    console.error('PayOS webhook error:', error);
    return res.status(500).json({ success: false, message: 'PayOS webhook processing failed' });
  }
});

// 11. Confirm payOS webhook URL with payOS merchant API
app.post('/api/payos/confirm-webhook', async (req, res) => {
  const { webhookUrl } = req.body;
  const clientId = process.env.PAYOS_CLIENT_ID;
  const apiKey = process.env.PAYOS_API_KEY;
  const confirmToken = process.env.PAYOS_CONFIRM_TOKEN;

  if (!clientId || !apiKey) {
    return res.status(500).json({ success: false, message: 'PAYOS_CLIENT_ID or PAYOS_API_KEY is not configured' });
  }

  if (!confirmToken || req.get('x-payos-confirm-token') !== confirmToken) {
    return res.status(401).json({ success: false, message: 'Unauthorized webhook confirmation request' });
  }

  try {
    const parsedUrl = new URL(webhookUrl);
    if (parsedUrl.protocol !== 'https:') {
      return res.status(400).json({ success: false, message: 'Webhook URL must use HTTPS' });
    }
  } catch {
    return res.status(400).json({ success: false, message: 'Webhook URL is invalid' });
  }

  try {
    const response = await fetch('https://api-merchant.payos.vn/confirm-webhook', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'x-client-id': clientId,
        'x-api-key': apiKey
      },
      body: JSON.stringify({ webhookUrl })
    });

    const result = await response.json().catch(() => ({}));
    return res.status(response.status).json({
      success: response.ok,
      payos: result
    });
  } catch (error) {
    console.error('PayOS confirm webhook error:', error);
    return res.status(502).json({ success: false, message: 'Could not connect to payOS confirm-webhook API' });
  }
});

app.get('/api/payos/payments/:orderCode', async (req, res) => {
  const orderCode = Number(req.params.orderCode);

  if (!Number.isFinite(orderCode)) {
    return res.status(400).json({ code: 'BAD_ORDER_CODE', desc: 'Invalid orderCode' });
  }

  try {
    const storedPayment = await findStoredPayment(orderCode);
    if (storedPayment && isFinalPaymentStatus(storedPayment.status)) {
      return res.json({ code: '00', desc: 'success', data: normalizePaymentResponse(storedPayment) });
    }

    const payosResult = await callPayOS(`/v2/payment-requests/${orderCode}`, { method: 'GET' });
    if (payosResult?.data) {
      const paymentUpdate = {
        orderCode,
        amount: Number(payosResult.data.amount) || 0,
        description: payosResult.data.description || '',
        status: payosResult.data.status || 'PENDING',
        paymentLinkId: payosResult.data.id || payosResult.data.paymentLinkId || null,
        checkoutUrl: payosResult.data.checkoutUrl || null,
        qrCode: payosResult.data.qrCode || null
      };

      if (isMongoDBConnected) {
        await Payment.findOneAndUpdate(
          { orderCode },
          { $set: paymentUpdate },
          { upsert: true, new: true }
        );
      } else {
        saveLocalPaymentFromCreate(paymentUpdate, payosResult);
      }
    }

    return res.json(payosResult);
  } catch (error) {
    console.warn('Could not refresh payment from payOS, falling back to stored payment:', error.message);
  }

  try {
    const payment = await findStoredPayment(orderCode);
    if (!payment) {
      return res.status(404).json({ code: 'NOT_FOUND', desc: 'Payment not found' });
    }

    return res.json({ code: '00', desc: 'success', data: normalizePaymentResponse(payment) });
  } catch (error) {
    console.error('PayOS payment lookup error:', error);
    return res.status(500).json({ code: 'SERVER_ERROR', desc: 'Could not load payment status' });
  }
});

app.post('/api/payos/payments/:orderCode/cancel', async (req, res) => {
  const orderCode = Number(req.params.orderCode);

  if (!Number.isFinite(orderCode)) {
    return res.status(400).json({ code: 'BAD_ORDER_CODE', desc: 'Invalid orderCode' });
  }

  try {
    const cancellationReason = req.body?.cancellationReason || 'Cancelled from HealthCare+ demo';
    const payosResult = await callPayOS(`/v2/payment-requests/${orderCode}/cancel`, {
      method: 'POST',
      body: JSON.stringify({ cancellationReason })
    });

    const paymentData = payosResult?.data || {};
    const storedPayment = await findStoredPayment(orderCode);
    const paymentUpdate = {
      orderCode,
      amount: Number(paymentData.amount ?? storedPayment?.amount) || 0,
      description: paymentData.description || storedPayment?.description || '',
      status: paymentData.status || 'CANCELLED',
      paymentLinkId: paymentData.id || paymentData.paymentLinkId || storedPayment?.paymentLinkId || null,
      checkoutUrl: paymentData.checkoutUrl || storedPayment?.checkoutUrl || null,
      qrCode: paymentData.qrCode || storedPayment?.qrCode || null,
      reference: paymentData.reference || storedPayment?.reference || null,
      paidAt: storedPayment?.paidAt || null,
      canceledAt: paymentData.canceledAt || new Date().toISOString()
    };

    if (isMongoDBConnected) {
      await Payment.findOneAndUpdate(
        { orderCode },
        { $set: paymentUpdate },
        { upsert: true, new: true }
      );
    } else {
      saveLocalPaymentFromCreate(paymentUpdate, payosResult);
    }

    return res.json({
      code: '00',
      desc: 'cancelled',
      data: {
        ...paymentData,
        ...paymentUpdate
      }
    });
  } catch (error) {
    console.error('PayOS cancel payment error:', error);
    return res.status(502).json({ code: 'PAYOS_CANCEL_FAILED', desc: error.message });
  }
});

// 12. Payment status lookup for future clients
app.get('/api/payments/:orderCode', async (req, res) => {
  const orderCode = Number(req.params.orderCode);

  if (!Number.isFinite(orderCode)) {
    return res.status(400).json({ success: false, message: 'Invalid orderCode' });
  }

  try {
    if (isMongoDBConnected) {
      const payment = await Payment.findOne({ orderCode })
        .select('-_id orderCode amount description status paymentLinkId checkoutUrl qrCode reference paidAt canceledAt createdAt updatedAt')
        .lean();
      if (!payment) {
        return res.status(404).json({ success: false, message: 'Payment not found' });
      }

      return res.json(normalizePaymentResponse(payment));
    }

    const payments = readJSONFile(paymentsFilePath, []);
    const payment = payments.find(item => Number(item.orderCode) === orderCode);
    if (!payment) {
      return res.status(404).json({ success: false, message: 'Payment not found' });
    }

    return res.json(normalizePaymentResponse(payment));
  } catch (error) {
    console.error('Payment lookup error:', error);
    return res.status(500).json({ success: false, message: 'Could not load payment status' });
  }
});

// Health check endpoint
app.get('/api/health', (req, res) => {
  res.json({ 
    status: 'ok', 
    uptime: process.uptime(),
    database: isMongoDBConnected ? 'MongoDB Atlas (Online)' : 'Local JSON (Offline Fallback)'
  });
});

// Start Server
app.listen(PORT, () => {
  console.log(`Server is running on port ${PORT}`);
});
