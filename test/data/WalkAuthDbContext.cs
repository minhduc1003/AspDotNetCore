using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace test.data
{
    public class WalkAuthDbContext : IdentityDbContext
    {
        public WalkAuthDbContext(DbContextOptions<WalkAuthDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            string userId = "1acc8054-07dd-4086-aac7-65353b427816";
            string adminId = "1b80173d-dc32-494e-8054-3fce8c756cfb";
            var role = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userId,
                    ConcurrencyStamp =userId,
                    Name = "USER",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Id = adminId,
                    ConcurrencyStamp =adminId,
                    Name = "ADMIN",
                    NormalizedName = "ADMIN"
                },
            };
            builder.Entity<IdentityRole>().HasData(role);
        }
    }
}
