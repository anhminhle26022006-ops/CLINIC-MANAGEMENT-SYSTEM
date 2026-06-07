using System;

namespace CMS.Core.Utils
{
    public static class ServiceTypeHelper
    {
        public static bool ContainsIgnoreCase(string source, string target)
        {
            if (source == null || target == null) return false;
            return source.IndexOf(target, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public static bool IsImagingService(string serviceType)
        {
            if (string.IsNullOrWhiteSpace(serviceType)) return false;
            return ContainsIgnoreCase(serviceType, "MRI") || 
                   ContainsIgnoreCase(serviceType, "X-quang") || 
                   ContainsIgnoreCase(serviceType, "X-ray") || 
                   ContainsIgnoreCase(serviceType, "Xray") || 
                   ContainsIgnoreCase(serviceType, "Siêu âm") || 
                   ContainsIgnoreCase(serviceType, "Sieu am");
        }

        public static bool IsPdfUploadService(string serviceType)
        {
            if (string.IsNullOrWhiteSpace(serviceType)) return false;
            return ContainsIgnoreCase(serviceType, "xét nghiệm máu tổng quát") || 
                   ContainsIgnoreCase(serviceType, "pdf") || 
                   ContainsIgnoreCase(serviceType, "tổng quát");
        }

        public static bool IsLabOrEcgService(string serviceType)
        {
            if (string.IsNullOrWhiteSpace(serviceType)) return false;
            return ContainsIgnoreCase(serviceType, "Xét nghiệm") || 
                   ContainsIgnoreCase(serviceType, "ECG") || 
                   ContainsIgnoreCase(serviceType, "Điện tâm đồ") || 
                   ContainsIgnoreCase(serviceType, "Dịch vụ");
        }

        public static string InferModality(string serviceName)
        {
            if (string.IsNullOrWhiteSpace(serviceName)) return "Imaging";
            string value = serviceName.ToLowerInvariant();
            if (value.Contains("mri")) return "MRI";
            if (value.Contains("x-quang") || value.Contains("xray") || value.Contains("x-ray")) return "X-Ray";
            if (value.Contains("siêu âm") || value.Contains("sieu am")) return "Ultrasound";
            return "Imaging";
        }
    }
}
