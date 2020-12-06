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

        public void SaveReading(Reading reading)
        {
            context.Readings.Add(reading);
            context.SaveChanges();
        }
    }
}
