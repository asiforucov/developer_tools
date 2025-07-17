using System.Xml;

namespace DevToolKit.Services
{
    public static class XmlFormatterService
    {
        public static string Format(string input)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(input);
                using var stringWriter = new StringWriter();
                using var xmlTextWriter = new XmlTextWriter(stringWriter) { Formatting = Formatting.Indented };
                doc.WriteContentTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.ToString();
            }
            catch (Exception ex)
            {
                return $"Invalid XML: {ex.Message}";
            }
        }
    }
} 