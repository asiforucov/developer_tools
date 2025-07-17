using System.Text.RegularExpressions;

namespace DevToolKit.Services
{
    public static class SlugService
    {
        public static string GenerateSlug(string input)
        {
            string slug = input.ToLowerInvariant();
            slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = Regex.Replace(slug, @"[\s-]+", " ").Trim();
            slug = slug.Replace(' ', '-');
            return slug;
        }
    }
} 