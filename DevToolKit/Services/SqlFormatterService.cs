using System.Text.RegularExpressions;

namespace DevToolKit.Services
{
    public static class SqlFormatterService
    {
        private static readonly string[] Keywords = new[] { "SELECT", "FROM", "WHERE", "GROUP BY", "ORDER BY", "INSERT", "UPDATE", "DELETE", "VALUES", "SET", "JOIN", "ON", "AND", "OR", "IN", "AS", "LEFT", "RIGHT", "INNER", "OUTER", "LIMIT", "OFFSET" };
        public static string Format(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            string sql = input;
            foreach (var kw in Keywords)
            {
                sql = Regex.Replace(sql, $"\\b{kw}\\b", kw, RegexOptions.IgnoreCase);
            }
            // Simple formatting: new line before keywords
            foreach (var kw in Keywords)
            {
                sql = Regex.Replace(sql, $"\\b{kw}\\b", m => "\n" + m.Value, RegexOptions.IgnoreCase);
            }
            return sql.Trim();
        }
    }
} 