using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BarberShop1._0._1.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
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
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
                Email = "G221210571@sakarya.edu.tr",
                NormalizedEmail = "G221210571@SAKARYA.EDU.TR",
                UserName = "G221210571@sakarya.edu.tr",
                NormalizedUserName = "G221210571@SAKARYA.EDU.TR",
                PasswordHash = hasher.HashPassword(null, "sau"),
                EmailConfirmed = true,
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "aef652d9-61d6-4240-a1d7-658e592c85fc",
                UserId = "85aa7c1d-e0ac-48b7-a71c-fbed3719020e",
            });

        }
    }
}
