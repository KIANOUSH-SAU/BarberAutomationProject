using BarberShop1._0._1.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BarberShop1._0._1.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<BarberAvailability> BarberAvailabilities { get; set; }

        public DbSet<AppointmentRecords> AppointmentRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<AppointmentRecords>()
            .HasOne(ar => ar.Barber)
            .WithMany()
            .HasForeignKey(ar => ar.BarberId);

            builder.Entity<AppointmentRecords>()
            .HasOne(ar => ar.Service)
            .WithMany()
            .HasForeignKey(ar => ar.ServiceId);



            builder.Entity<ServiceModel>()
            .HasMany(s => s.Barbers)  
            .WithMany(b => b.Services)
            .UsingEntity<Dictionary<string, object>>(
                "ServiceBarber",
                sb => sb.HasOne<Barber>().WithMany().HasForeignKey("BarberId"),
                sb => sb.HasOne<ServiceModel>().WithMany().HasForeignKey("ServiceId")
            );

            builder.Entity<BarberAvailability>()
            .HasOne(ba => ba.Barber)
            .WithMany(b => b.Availabilities)
            .HasForeignKey(ba => ba.BarberId);



            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "fbbf89f1-abde-4855-96e3-6c1084e2799f",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER",

                },
                new IdentityRole
                {
                    Id = "ce7244ce-71f0-49b5-9db3-9bf987f93be1",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                },
                new IdentityRole
                {
                    Id = "aef652d9-61d6-4240-a1d7-658e592c85fc",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                });
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                Email = "G221210571@sakarya.edu.tr",
                NormalizedEmail = "G221210571@SAKARYA.EDU.TR",
                UserName = "G221210571@sakarya.edu.tr",
                NormalizedUserName = "G221210571@SAKARYA.EDU.TR",
                PasswordHash = hasher.HashPassword(null, "sau"),
                EmailConfirmed = true,
                FirstName = "Default",
                LastName = "Admin"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "aef652d9-61d6-4240-a1d7-658e592c85fc",
                UserId = "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
            });

        }
    }
}
