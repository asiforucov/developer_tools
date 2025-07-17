using System;

namespace DevToolKit.Models
{
    public class JwtDecoderViewModel
    {
        public string Input { get; set; }
        public string HeaderJson { get; set; }
        public string PayloadJson { get; set; }
        public DateTime? Expiration { get; set; }
        public string Error { get; set; }
    }
} 