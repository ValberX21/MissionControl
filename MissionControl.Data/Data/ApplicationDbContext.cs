using Microsoft.EntityFrameworkCore;
using MissionControl.Shared;
using MissionControl.Shared.Enum;
using MissionControl.Shared.Models;

namespace MissionControl.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Mission> Mission { get; set; }
        public DbSet<JediKnightModel> JediKnight { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum<JediRank>();
            modelBuilder.HasPostgresEnum<AccessLevel>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
