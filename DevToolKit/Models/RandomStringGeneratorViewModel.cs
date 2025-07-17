namespace DevToolKit.Models
{
    public class RandomStringGeneratorViewModel
    {
        public int Length { get; set; } = 16;
        public bool UseNumbers { get; set; } = true;
        public bool UseLower { get; set; } = true;
        public bool UseUpper { get; set; } = true;
        public string? Result { get; set; }
    }
} 