using LineConstruction.Core.Entities;
using LineConstruction.DAL.ConfigrationsManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LineConstruction.DAL.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions opt) : base(opt) { }

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
            #region Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "8aad637d-42e5-4586-a140-697cd3ee8498", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "792af7b1-45f7-4238-b547-107355540960", Name = "Users", NormalizedName = "USERS" },
                new IdentityRole { Id = "a923f5d6-8127-4f92-b34d-91f5a8c6a788", Name = "HR", NormalizedName = "HR" } // Unikal Id verdim
            );
            #endregion

            #region Users
            AppUser admin = new()
            {
                Id = "be30629f-0508-461a-8fa1-0e905705e1f5",
                UserName = "Admin",
                LastName = "Hesenov",
                FirstName = "Huseyn",
                EmailConfirmed = true,
                Email = "Admin12@lineconstruction.com",
                NormalizedUserName = "ADMIN"
            };

            AppUser hr = new()
            {
                Id = "be10629f-0508-451a-8fv1-0e905705e1f5",
                UserName = "HR",
                LastName = "Hesenov",
                FirstName = "Huseyn",
                EmailConfirmed = true,
                Email = "Hr12@lineconstruction.com",
                NormalizedUserName = "HR"
            };

            PasswordHasher<AppUser> hasher = new();
            admin.PasswordHash = hasher.HashPassword(admin, "Admin123!");
            hr.PasswordHash = hasher.HashPassword(hr, "Hr12345!"); // Düzəliş etdim

            modelBuilder.Entity<AppUser>().HasData(admin, hr);
            #endregion

            #region Assign Roles
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = admin.Id, RoleId = "8aad637d-42e5-4586-a140-697cd3ee8498" }, // Admin roluna əlavə
                new IdentityUserRole<string> { UserId = hr.Id, RoleId = "a923f5d6-8127-4f92-b34d-91f5a8c6a788" } // HR roluna əlavə
            );
            #endregion

            // Foreign Key-lərin silinmə davranışını tənzimləmək
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                if (relationship.DeleteBehavior == DeleteBehavior.Cascade)
                {
                    relationship.DeleteBehavior = DeleteBehavior.Restrict;
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OurServiceConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
