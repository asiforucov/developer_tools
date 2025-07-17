namespace DevToolKit.Models
{
    public class XmlJsonConverterViewModel
    {
        public string Input { get; set; }
        public string Output { get; set; }
        public string Mode { get; set; } // "xml2json" or "json2xml"
        public string Error { get; set; }
    }
} 