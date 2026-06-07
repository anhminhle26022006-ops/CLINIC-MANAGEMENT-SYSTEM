using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ServicesExternal
{
    public class PayOsCreatePaymentRequest
    {
        public long orderCode { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public string buyerName { get; set; }
        public string returnUrl { get; set; }
        public string cancelUrl { get; set; }
        public string signature { get; set; }
    }

    public class PayOsPaymentData
    {
        public string bin { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public int amount { get; set; }
        public int amountPaid { get; set; }
        public int amountRemaining { get; set; }
        public string description { get; set; }
        public long orderCode { get; set; }
        public string currency { get; set; }
        public string paymentLinkId { get; set; }
        public string status { get; set; }
        public string checkoutUrl { get; set; }
        public string qrCode { get; set; }
        public string qrDataURL { get; set; }
        public string createdAt { get; set; }
        public string paidAt { get; set; }
        public string canceledAt { get; set; }
    }

    public class PayOsApiResponse
    {
        public string code { get; set; }
        public string desc { get; set; }
        public PayOsPaymentData data { get; set; }
        public string signature { get; set; }
    }

    public static class ImageHelper
    {
        public static string ImageToBase64(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();
                string base64String = Convert.ToBase64String(imageBytes);
                string mimeType = GetMimeType(format);
                return $"data:{mimeType};base64,{base64String}";
            }
        }

        private static string GetMimeType(ImageFormat format)
        {
            if (format.Equals(ImageFormat.Jpeg))
            {
                return "image/jpeg";
            }

            if (format.Equals(ImageFormat.Png))
            {
                return "image/png";
            }

            if (format.Equals(ImageFormat.Bmp))
            {
                return "image/bmp";
            }

            if (format.Equals(ImageFormat.Gif))
            {
                return "image/gif";
            }

            if (format.Equals(ImageFormat.Tiff))
            {
                return "image/tiff";
            }

            throw new ArgumentOutOfRangeException("Unknown image format");
        }

        public static Image Base64ToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            return Image.FromStream(ms, true);
        }
    }
}
