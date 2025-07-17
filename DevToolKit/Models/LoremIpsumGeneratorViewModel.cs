using System.Collections.Generic;

namespace DevToolKit.Models
{
    public class LoremIpsumGeneratorViewModel
    {
        public int Paragraphs { get; set; } = 1;
        public List<string>? ParagraphResults { get; set; }
    }
} 