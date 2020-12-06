using System;
using System.Collections.Generic;
using System.Linq;
using sensor_reading_backend.Models.Entities;

namespace sensor_reading_backend.Models.Repository
{
    public class EFReadingRepository : IReadingRepository
    {
        private ApplicationDbContext context;

        public EFReadingRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Reading> GetReadings(DateTime lastRequestTime)
        {
            return context.Readings.Where(x => lastRequestTime < x.Timestamp).OrderBy(x => x.Timestamp);
        }

        public void SaveReading(Reading reading)
        {
            context.Readings.Add(reading);
            context.SaveChanges();
        }
    }
}
