using Microsoft.EntityFrameworkCore;
using MissionControl.Shared;
using MissionControl.Shared.Models;


namespace MissionControl.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Mission> Mission { get; set; }
        public DbSet<JediKnight> JediKnight { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
