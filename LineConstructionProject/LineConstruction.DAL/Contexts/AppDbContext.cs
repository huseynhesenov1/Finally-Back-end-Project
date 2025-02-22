using LineConstruction.Core.Entities;
using LineConstruction.DAL.ConfigrationsManager;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.DAL.Contexts
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions opt) :base(opt){  }
        public DbSet<OurService> OurServices { get; set; }
        public DbSet<OurTeam> OurTeams { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<AddedCV> AddedCVs { get; set; }
        public DbSet<Plaster> Plasters { get; set; }
        public DbSet<Foundation> Foundations { get; set; }
        public DbSet<Masonry> Masonries { get; set; }
        public DbSet<Roof> Roofs { get; set; }
        public DbSet<OrderCheckout> OrderCheckouts { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
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
