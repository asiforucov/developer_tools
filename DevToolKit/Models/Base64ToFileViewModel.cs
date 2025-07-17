namespace DevToolKit.Models
{
    public class Base64ToFileViewModel
    {
        public string? Base64String { get; set; }
        public string? FileName { get; set; }
        public string? DownloadFileName { get; set; }
        public byte[]? DownloadFileContent { get; set; }
        public bool? IsValid { get; set; }
    }
} 