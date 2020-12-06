using sensor_reading_backend.Models.Entities;
using System;
using System.Collections.Generic;

namespace sensor_reading_backend.Models.Repository
{
    public interface IReadingRepository
    {
        void SaveReading(Reading reading);
        IEnumerable<Reading> GetReadings(DateTime lastRequestTime);
    }
}
