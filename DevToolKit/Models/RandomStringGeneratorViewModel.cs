namespace DevToolKit.Models
{
    public class RandomStringGeneratorViewModel
    {
        public int Length { get; set; } = 16;
        public bool UseNumbers { get; set; } = false;
        public bool UseLower { get; set; } = false;
        public bool UseUpper { get; set; } = false;
        public string? Result { get; set; }
    }
} 