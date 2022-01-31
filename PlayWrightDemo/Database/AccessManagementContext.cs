using Microsoft.EntityFrameworkCore;
using PlayWrightDemo.Database.AccessManagementModels;

namespace PlayWrightDemo.Database
{
    public class AccessManagementContext : DbContext
    {
        private readonly string _connectionString;

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(x => x.UserRole).WithOne(x => x.Role).HasForeignKey(x => x.RoleID);
        }

        public AccessManagementContext (string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
