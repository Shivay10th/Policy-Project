using Microsoft.EntityFrameworkCore;
using PolicyProject.Models;

namespace PolicyProject.Data
{
    public class PolicyProjectContext : DbContext
    {
        public PolicyProjectContext(DbContextOptions<PolicyProjectContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(user => user.Role).HasDefaultValue("customer");
        }
        public DbSet<PolicyProject.Models.User> User { get; set; }

        public DbSet<PolicyProject.Models.Policy> Policy { get; set; }
        public DbSet<PolicyProject.Models.PolicyType> PolicyType { get; set; }
        public DbSet<PolicyProject.Models.Contact> Contact { get; set; }
    }
}
