using System;

namespace sensor_reading_backend.Models.Entities
{
    public class Reading
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public bool Alert { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
