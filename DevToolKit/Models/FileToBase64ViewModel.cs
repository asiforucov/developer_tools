using Microsoft.AspNetCore.Http;

namespace DevToolKit.Models
{
    public class FileToBase64ViewModel
    {
        public IFormFile? UploadFile { get; set; }
        public string? Base64String { get; set; }
    }
} 