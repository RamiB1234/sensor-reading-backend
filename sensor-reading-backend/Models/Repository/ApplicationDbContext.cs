using Microsoft.EntityFrameworkCore;
using sensor_reading_backend.Models.Entities;

namespace sensor_reading_backend.Models.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Reading> Readings { get; set; }
    }
}
