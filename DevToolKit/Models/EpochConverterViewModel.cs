using System;

namespace DevToolKit.Models
{
    public class EpochConverterViewModel
    {
        public string? Mode { get; set; } // "toDateTime" or "toEpoch"
        public long? Epoch { get; set; }
        public DateTime? DateTime { get; set; }
    }
} 