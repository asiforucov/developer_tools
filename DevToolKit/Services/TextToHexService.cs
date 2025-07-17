using System.Text;

namespace DevToolKit.Services
{
    public static class TextToHexService
    {
        public static string ToHex(string input)
        {
            var sb = new StringBuilder();
            foreach (char c in input)
            {
                sb.AppendFormat("{0:x2}", (int)c);
            }
            return sb.ToString();
        }
    }
} 