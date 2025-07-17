using System.Text;

namespace DevToolKit.Services
{
    public static class TextDiffService
    {
        public static string GetDiff(string text1, string text2)
        {
            // Simple line-by-line diff for demo
            var sb = new StringBuilder();
            var lines1 = text1.Split('\n');
            var lines2 = text2.Split('\n');
            int max = Math.Max(lines1.Length, lines2.Length);
            for (int i = 0; i < max; i++)
            {
                var l1 = i < lines1.Length ? lines1[i] : null;
                var l2 = i < lines2.Length ? lines2[i] : null;
                if (l1 == l2)
                {
                    if (l1 != null)
                        sb.AppendLine(System.Net.WebUtility.HtmlEncode(l1));
                }
                else
                {
                    if (l1 != null)
                        sb.AppendLine($"<del class='text-red-600 bg-red-50 dark:bg-red-900/30'>{System.Net.WebUtility.HtmlEncode(l1)}</del>");
                    if (l2 != null)
                        sb.AppendLine($"<ins class='text-green-700 bg-green-50 dark:bg-green-900/30'>{System.Net.WebUtility.HtmlEncode(l2)}</ins>");
                }
            }
            return sb.ToString();
        }
    }
} 