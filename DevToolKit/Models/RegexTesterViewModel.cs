using System.Collections.Generic;

namespace DevToolKit.Models
{
    public class RegexTesterViewModel
    {
        public string Pattern { get; set; }
        public string TestString { get; set; }
        public List<string> Matches { get; set; } = new List<string>();
        public List<string> Groups { get; set; } = new List<string>();
        public string Error { get; set; }
    }
} 