using MakersLoanSystem.User.API.Core.Entities.MakersLoanSystem.User.API.Core.Entities;
using MakersLoanSystem.User.API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MakersLoanSystem.User.API.Infrastructure.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
