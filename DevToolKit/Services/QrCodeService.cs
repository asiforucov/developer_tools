using System;
using System.IO;
using QRCoder;

namespace DevToolKit.Services
{
    public static class QrCodeService
    {
        public static string GenerateQrCode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;
            try
            {
                var qrGenerator = new QRCodeGenerator();
                var qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);
                var qrCode = new BitmapByteQRCode(qrCodeData);
                var pngBytes = qrCode.GetGraphic(20);
                return "data:image/png;base64," + Convert.ToBase64String(pngBytes);
            }
            catch
            {
                return null;
            }
        }
    }
} 