using sensor_reading_backend.Models.Entities;

namespace sensor_reading_backend.Models.Repository
{
    public interface IReadingRepository
    {
        void SaveReading(Reading reading);
    }
}
