using _3lashanak.Models;
using Microsoft.EntityFrameworkCore;

namespace _3lashanak.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Messages> Messages { get; set; }
        public DbSet<Packages> Packages { get; set; }
        public DbSet<Partners> Partners { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SocialMedia> SocialMedia { get; set; }
    }
}
