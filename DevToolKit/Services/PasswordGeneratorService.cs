using System;
using System.Text;

namespace DevToolKit.Services
{
    public static class PasswordGeneratorService
    {
        public static string Generate(int length, bool useNumbers, bool useLower, bool useUpper, bool useSymbols)
        {
            const string numbers = "0123456789";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string symbols = "!@#$%^&*()-_=+[]{}|;:,.<>?";
            var chars = "";
            if (useNumbers) chars += numbers;
            if (useLower) chars += lower;
            if (useUpper) chars += upper;
            if (useSymbols) chars += symbols;
            if (string.IsNullOrEmpty(chars)) chars = lower;
            var sb = new StringBuilder();
            var rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                sb.Append(chars[rnd.Next(chars.Length)]);
            }
            return sb.ToString();
        }
    }
} 