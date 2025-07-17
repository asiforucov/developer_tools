using Microsoft.AspNetCore.Http;

namespace DevToolKit.Models
{
    public class ImageDiffViewModel
    {
        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public string? Result { get; set; }
    }
} 