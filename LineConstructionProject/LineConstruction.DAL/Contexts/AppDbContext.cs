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
        public DbSet<Order> Orders { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.Restrict;
			}
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(OurServiceConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
