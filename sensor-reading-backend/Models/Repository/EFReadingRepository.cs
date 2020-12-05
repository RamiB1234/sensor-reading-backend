namespace sensor_reading_backend.Models.Repository
{
    public class EFReadingRepository : IReadingRepository
    {
        private ApplicationDbContext context;

        public EFReadingRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
    }
}
