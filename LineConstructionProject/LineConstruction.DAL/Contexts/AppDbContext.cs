using LineConstruction.Core.Entities;
using LineConstruction.DAL.ConfigrationsManager;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.DAL.Contexts
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions opt) :base(opt){  }
        public DbSet<OurService> OurServices { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OurServiceConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
