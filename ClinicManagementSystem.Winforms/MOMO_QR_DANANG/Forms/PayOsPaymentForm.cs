using Newtonsoft.Json;
using RestSharp;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOMO_QR_DANANG
{
    public partial class PayOsPaymentForm : Form
    {
        private const int ApiTimeoutSeconds = 20;
        private const string DefaultBackendBaseUrl = "http://localhost:5000";

        private CancellationTokenSource apiRequestCancellation;
        private bool isClosing;
        private long? currentOrderCode;
        private bool isCheckingPaymentStatus;
        private System.Windows.Forms.Timer paymentStatusTimer;
        private Label lblPaymentStatus;
        private TextBox txtCheckoutUrl;
        private Button btnCheckStatus;

        public PayOsPaymentForm()
        {
            InitializeComponent();
        }

        private void PayOsPaymentForm_Load(object sender, EventArgs e)
        {
            ConfigurePayOsUi();
            paymentStatusTimer = new System.Windows.Forms.Timer
            {
                Interval = 5000
            };
            paymentStatusTimer.Tick += async (s, args) => await CheckCurrentPaymentStatusAsync(false);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isClosing = true;
            paymentStatusTimer?.Stop();
            apiRequestCancellation?.Cancel();
            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            paymentStatusTimer?.Dispose();
            paymentStatusTimer = null;
            apiRequestCancellation?.Dispose();
            apiRequestCancellation = null;
            base.OnFormClosed(e);
        }

        private void ConfigurePayOsUi()
        {
            label6.Text = "TẠO MÃ THANH TOÁN PAYOS";
            groupBox1.Text = "Mã QR PayOS";
            groupBox2.Text = "Thông tin thanh toán";
            label8.Text = "Cổng:";
            label1.Text = "Mã đơn hàng:";
            label7.Text = "Người mua:";
            label3.Text = "Nội dung:";
            label4.Text = "(PayOS sẽ rút gọn nội dung về tối đa 9 ký tự)";

            cboNganHang.Items.Clear();
            cboNganHang.Items.Add("PayOS");
            cboNganHang.SelectedIndex = 0;
            cboNganHang.Enabled = false;

            label5.Visible = false;
            picLogo.Visible = false;
            button1.Visible = false;

            button2.Location = new Point(270, 235);

            var checkoutLabel = new Label
            {
                AutoSize = true,
                Location = new Point(53, 306),
                Name = "labelCheckout",
                Size = new Size(65, 14),
                Text = "Checkout:"
            };
            txtCheckoutUrl = new TextBox
            {
                Location = new Point(134, 303),
                Name = "txtCheckoutUrl",
                ReadOnly = true,
                Size = new Size(287, 22)
            };
            lblPaymentStatus = new Label
            {
                AutoSize = true,
                ForeColor = Color.DimGray,
                Location = new Point(134, 333),
                Name = "lblPaymentStatus",
                Size = new Size(120, 14),
                Text = "Chưa tạo thanh toán"
            };
            btnCheckStatus = new Button
            {
                Enabled = false,
                Location = new Point(270, 328),
                Name = "btnCheckStatus",
                Size = new Size(151, 25),
                Text = "Kiểm tra trạng thái",
                UseVisualStyleBackColor = true
            };
            btnCheckStatus.Click += async (s, e) => await CheckCurrentPaymentStatusAsync(true);

            groupBox2.Controls.Add(checkoutLabel);
            groupBox2.Controls.Add(txtCheckoutUrl);
            groupBox2.Controls.Add(lblPaymentStatus);
            groupBox2.Controls.Add(btnCheckStatus);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.png)|*.png;",
                Title = "Select an Image"
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picLogo.LoadAsync(openFileDialog.FileName);
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var buyerName = txtTenTaiKhoan.Text.Trim();

            if (!int.TryParse(txtSoTien.Text.Trim(), out var amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền phải là số nguyên lớn hơn 0.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long orderCode;
            if (string.IsNullOrWhiteSpace(txtSoTaiKhoan.Text))
            {
                orderCode = GenerateOrderCode();
                txtSoTaiKhoan.Text = orderCode.ToString(CultureInfo.InvariantCulture);
            }
            else if (!long.TryParse(txtSoTaiKhoan.Text.Trim(), out orderCode) || orderCode <= 0)
            {
                MessageBox.Show("Mã đơn hàng phải là số nguyên lớn hơn 0.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var description = NormalizePayOsDescription(txtNoiDung.Text);

            apiRequestCancellation?.Cancel();
            apiRequestCancellation?.Dispose();
            apiRequestCancellation = new CancellationTokenSource();
            var cancellationToken = apiRequestCancellation.Token;

            button2.Enabled = false;
            Cursor = Cursors.WaitCursor;
            SetPaymentStatus("Đang tạo link thanh toán...", Color.DimGray);

            PayOsApiResponse dataResult;
            try
            {
                dataResult = await CreatePaymentAsync(orderCode, amount, description, buyerName, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                if (!isClosing && !IsDisposed)
                {
                    MessageBox.Show("Đã hủy gọi API PayOS.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }
            catch (Exception ex)
            {
                if (!isClosing && !IsDisposed)
                {
                    SetPaymentStatus("Tạo thanh toán thất bại", Color.Firebrick);
                    MessageBox.Show($"Không tạo được thanh toán PayOS.\n{ex.Message}", "Lỗi API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return;
            }
            finally
            {
                if (!isClosing && !IsDisposed)
                {
                    Cursor = Cursors.Default;
                    button2.Enabled = true;
                }
            }

            if (isClosing || IsDisposed)
            {
                return;
            }

            if (dataResult?.data == null || dataResult.code != "00")
            {
                SetPaymentStatus("Tạo thanh toán thất bại", Color.Firebrick);
                MessageBox.Show($"PayOS không tạo được link.\nMã lỗi: {dataResult?.code}\nMô tả: {dataResult?.desc}", "Lỗi API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            currentOrderCode = dataResult.data.orderCode == 0 ? orderCode : dataResult.data.orderCode;
            txtCheckoutUrl.Text = dataResult.data.checkoutUrl ?? "";
            RenderPaymentQr(dataResult.data);
            SetPaymentStatus($"Trạng thái: {dataResult.data.status ?? "PENDING"}", Color.DarkGoldenrod);
            btnCheckStatus.Enabled = true;
            paymentStatusTimer.Start();
        }

        private async Task<PayOsApiResponse> CreatePaymentAsync(long orderCode, int amount, string description, string buyerName, CancellationToken cancellationToken)
        {
            var backendBaseUrl = GetCleanBackendBaseUrl();
            if (!string.IsNullOrWhiteSpace(backendBaseUrl))
            {
                try
                {
                    return await CreatePaymentViaBackendAsync(backendBaseUrl, orderCode, amount, description, buyerName, cancellationToken);
                }
                catch (InvalidOperationException ex) when (IsNotFoundResponse(ex))
                {
                    if (!AllowDirectPayOsFallback())
                    {
                        throw;
                    }

                    Debug.WriteLine($"Backend create-payment route is not deployed yet, fallback to direct payOS: {ex.Message}");
                }
            }

            if (!AllowDirectPayOsFallback())
            {
                throw new InvalidOperationException("BackendBaseUrl chưa được cấu hình hoặc backend chưa sẵn sàng. Flow đúng chuẩn yêu cầu form gọi backend trước.");
            }

            return await CreatePaymentDirectPayOsAsync(orderCode, amount, description, buyerName, cancellationToken);
        }

        private async Task<PayOsApiResponse> CreatePaymentViaBackendAsync(string backendBaseUrl, long orderCode, int amount, string description, string buyerName, CancellationToken cancellationToken)
        {
            var payload = new
            {
                orderCode,
                amount,
                description,
                buyerName
            };

            return await ExecuteJsonAsync(
                backendBaseUrl.TrimEnd('/'),
                "/api/payos/create-payment",
                Method.Post,
                payload,
                cancellationToken);
        }

        private async Task<PayOsApiResponse> CreatePaymentDirectPayOsAsync(long orderCode, int amount, string description, string buyerName, CancellationToken cancellationToken)
        {
            var clientId = RequireSetting("PayOSClientId");
            var apiKey = RequireSetting("PayOSApiKey");
            var checksumKey = RequireSetting("PayOSChecksumKey");
            var returnUrl = RequireSetting("PayOSReturnUrl");
            var cancelUrl = RequireSetting("PayOSCancelUrl");

            var payload = new PayOsCreatePaymentRequest
            {
                orderCode = orderCode,
                amount = amount,
                description = description,
                buyerName = buyerName,
                returnUrl = returnUrl,
                cancelUrl = cancelUrl,
                signature = CreatePayOsPaymentSignature(amount, cancelUrl, description, orderCode, returnUrl, checksumKey)
            };

            return await ExecuteJsonAsync(
                "https://api-merchant.payos.vn",
                "/v2/payment-requests",
                Method.Post,
                payload,
                cancellationToken,
                clientId,
                apiKey);
        }

        private async Task CheckCurrentPaymentStatusAsync(bool showMessage)
        {
            if (isCheckingPaymentStatus || currentOrderCode == null || isClosing || IsDisposed)
            {
                return;
            }

            isCheckingPaymentStatus = true;
            try
            {
                var statusResponse = await GetPaymentStatusAsync(currentOrderCode.Value, CancellationToken.None);
                var status = statusResponse?.data?.status;
                if (string.IsNullOrWhiteSpace(status))
                {
                    if (showMessage)
                    {
                        MessageBox.Show("Chưa đọc được trạng thái thanh toán.", "PayOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    return;
                }

                var color = status.Equals("PAID", StringComparison.OrdinalIgnoreCase)
                    ? Color.SeaGreen
                    : status.IndexOf("CANCEL", StringComparison.OrdinalIgnoreCase) >= 0
                        ? Color.Firebrick
                        : Color.DarkGoldenrod;

                SetPaymentStatus($"Trạng thái: {status}", color);

                if (status.Equals("PAID", StringComparison.OrdinalIgnoreCase) ||
                    status.IndexOf("CANCEL", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    paymentStatusTimer.Stop();
                }

                if (showMessage)
                {
                    MessageBox.Show($"Trạng thái đơn {currentOrderCode.Value}: {status}", "PayOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                if (showMessage)
                {
                    MessageBox.Show($"Không kiểm tra được trạng thái.\n{ex.Message}", "PayOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                isCheckingPaymentStatus = false;
            }
        }

        private async Task<PayOsApiResponse> GetPaymentStatusAsync(long orderCode, CancellationToken cancellationToken)
        {
            var backendBaseUrl = GetCleanBackendBaseUrl();
            if (!string.IsNullOrWhiteSpace(backendBaseUrl))
            {
                try
                {
                    return await ExecuteJsonAsync(
                        backendBaseUrl.TrimEnd('/'),
                        $"/api/payos/payments/{orderCode}",
                        Method.Get,
                        null,
                        cancellationToken);
                }
                catch (InvalidOperationException ex) when (IsNotFoundResponse(ex))
                {
                    if (!AllowDirectPayOsFallback())
                    {
                        throw;
                    }

                    Debug.WriteLine($"Backend payment status route is not deployed yet, fallback to direct payOS: {ex.Message}");
                }
            }

            if (!AllowDirectPayOsFallback())
            {
                throw new InvalidOperationException("BackendBaseUrl chưa được cấu hình hoặc backend chưa sẵn sàng. Flow đúng chuẩn yêu cầu form lấy trạng thái từ backend.");
            }

            return await ExecuteJsonAsync(
                "https://api-merchant.payos.vn",
                $"/v2/payment-requests/{orderCode}",
                Method.Get,
                null,
                cancellationToken,
                RequireSetting("PayOSClientId"),
                RequireSetting("PayOSApiKey"));
        }

        private async Task<PayOsApiResponse> ExecuteJsonAsync(string baseUrl, string resource, Method method, object payload, CancellationToken cancellationToken, string clientId = null, string apiKey = null)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var request = new RestRequest(resource, method)
            {
                Timeout = TimeSpan.FromSeconds(ApiTimeoutSeconds)
            };
            request.AddHeader("Accept", "application/json");

            if (!string.IsNullOrWhiteSpace(clientId))
            {
                request.AddHeader("x-client-id", clientId);
            }

            if (!string.IsNullOrWhiteSpace(apiKey))
            {
                request.AddHeader("x-api-key", apiKey);
            }

            if (payload != null)
            {
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("application/json", JsonConvert.SerializeObject(payload), ParameterType.RequestBody);
            }

            RestResponse response;
            using (var client = new RestClient(new RestClientOptions(baseUrl)
            {
                Timeout = TimeSpan.FromSeconds(ApiTimeoutSeconds)
            }))
            {
                response = await client.ExecuteAsync(request, cancellationToken);
            }

            if (!response.IsSuccessful || string.IsNullOrWhiteSpace(response.Content))
            {
                var errorMessage = response.ResponseStatus == ResponseStatus.TimedOut
                    ? $"API không phản hồi sau {ApiTimeoutSeconds} giây."
                    : response.ErrorMessage;

                throw new InvalidOperationException($"HTTP: {(int)response.StatusCode} {response.StatusDescription}\nTrạng thái: {response.ResponseStatus}\n{errorMessage}\n{response.Content}");
            }

            try
            {
                return JsonConvert.DeserializeObject<PayOsApiResponse>(response.Content);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException($"API trả về dữ liệu không hợp lệ.\n{ex.Message}\n{response.Content}", ex);
            }
        }

        private static bool IsNotFoundResponse(InvalidOperationException ex)
        {
            return ex.Message.IndexOf("HTTP: 404", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static bool AllowDirectPayOsFallback()
        {
            return string.Equals(GetSetting("AllowDirectPayOSFallback", "false"), "true", StringComparison.OrdinalIgnoreCase);
        }

        private void RenderPaymentQr(PayOsPaymentData paymentData)
        {
            picQRMOMO.Image = null;

            if (!string.IsNullOrWhiteSpace(paymentData.qrDataURL))
            {
                var base64 = paymentData.qrDataURL.Replace("data:image/png;base64,", "");
                picQRMOMO.Image = ImageHelper.Base64ToImage(base64);
                return;
            }

            if (!string.IsNullOrWhiteSpace(paymentData.qrCode))
            {
                picQRMOMO.LoadAsync("https://api.qrserver.com/v1/create-qr-code/?size=333x333&data=" + Uri.EscapeDataString(paymentData.qrCode));
                return;
            }

            if (!string.IsNullOrWhiteSpace(paymentData.checkoutUrl))
            {
                picQRMOMO.LoadAsync("https://api.qrserver.com/v1/create-qr-code/?size=333x333&data=" + Uri.EscapeDataString(paymentData.checkoutUrl));
            }
        }

        private void SetPaymentStatus(string text, Color color)
        {
            if (lblPaymentStatus == null)
            {
                return;
            }

            lblPaymentStatus.Text = text;
            lblPaymentStatus.ForeColor = color;
        }

        private static long GenerateOrderCode()
        {
            return long.Parse(DateTime.Now.ToString("yyMMddHHmmss", CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
        }

        private static string NormalizePayOsDescription(string input)
        {
            var raw = string.IsNullOrWhiteSpace(input) ? "PAYOS" : input;
            raw = RemoveDiacritics(raw).ToUpperInvariant();
            var clean = new string(raw.Where(char.IsLetterOrDigit).ToArray());
            if (string.IsNullOrWhiteSpace(clean))
            {
                clean = "PAYOS";
            }

            return clean.Length > 9 ? clean.Substring(0, 9) : clean;
        }

        private static string RemoveDiacritics(string text)
        {
            text = text.Replace('Đ', 'D').Replace('đ', 'd');
            var normalized = text.Normalize(NormalizationForm.FormD);
            var builder = new StringBuilder();

            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    builder.Append(c);
                }
            }

            return builder.ToString().Normalize(NormalizationForm.FormC);
        }

        private static string CreatePayOsPaymentSignature(int amount, string cancelUrl, string description, long orderCode, string returnUrl, string checksumKey)
        {
            var data = $"amount={amount}&cancelUrl={cancelUrl}&description={description}&orderCode={orderCode}&returnUrl={returnUrl}";
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(checksumKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(data));
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        private string GetCleanBackendBaseUrl()
        {
            var backendBaseUrl = GetSetting("BackendBaseUrl", DefaultBackendBaseUrl);
            if (string.IsNullOrWhiteSpace(backendBaseUrl))
            {
                return "";
            }

            backendBaseUrl = backendBaseUrl.Trim().TrimEnd('/');

            // Check if the user accidentally put the webhook URL instead of base URL
            string webhookSuffix = "/api/payos/webhook";
            if (backendBaseUrl.EndsWith(webhookSuffix, StringComparison.OrdinalIgnoreCase))
            {
                backendBaseUrl = backendBaseUrl.Substring(0, backendBaseUrl.Length - webhookSuffix.Length);
            }

            return backendBaseUrl.TrimEnd('/');
        }

        private static string GetSetting(string key, string fallback = "")
        {
            var value = ConfigurationManager.AppSettings[key];
            return value == null ? fallback : value.Trim();
        }

        private static string RequireSetting(string key)
        {
            var value = GetSetting(key);
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new InvalidOperationException($"Thieu cau hinh App.config: {key}");
            }

            return value;
        }
    }
}

