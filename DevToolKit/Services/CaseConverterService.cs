using System.Globalization;
using System.Text.RegularExpressions;

namespace DevToolKit.Services
{
    public static class CaseConverterService
    {
        public static string ToCamelCase(string input)
        {
            var words = SplitWords(input);
            if (words.Length == 0) return string.Empty;
            return words[0].ToLowerInvariant() + string.Concat(words.Skip(1).Select(Capitalize));
        }
        public static string ToPascalCase(string input)
        {
            var words = SplitWords(input);
            return string.Concat(words.Select(Capitalize));
        }
        public static string ToKebabCase(string input)
        {
            var words = SplitWords(input);
            return string.Join("-", words).ToLowerInvariant();
        }
        public static string ToSnakeCase(string input)
        {
            var words = SplitWords(input);
            return string.Join("_", words).ToLowerInvariant();
        }
        private static string[] SplitWords(string input)
        {
            return Regex.Matches(input, "[A-Za-z0-9]+")
                .Select(m => m.Value)
                .ToArray();
        }
        private static string Capitalize(string word)
        {
            return CultureInfo.InvariantCulture.TextInfo.ToTitleCase(word.ToLowerInvariant());
        }
    }
} 