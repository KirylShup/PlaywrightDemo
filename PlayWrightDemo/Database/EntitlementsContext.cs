using Microsoft.EntityFrameworkCore;
using PlayWrightDemo.Database.Models;

namespace PlayWrightDemo.Database
{
    public class EntitlementsContext : DbContext
    {
        private readonly string _connectionString;
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString, providerOptions => { providerOptions.EnableRetryOnFailure(); });
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.InvitationToJoin).WithOne(x => x.User).HasForeignKey(x => x.InviterUserID);
        }

        public EntitlementsContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<InviteToJoin> InviteToJoin { get; set; }
        public DbSet<User> User { get; set; }
    }
}
