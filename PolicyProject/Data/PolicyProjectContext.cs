using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PolicyProject.Models;

namespace PolicyProject.Data
{
    public class PolicyProjectContext : DbContext
    {
        public PolicyProjectContext (DbContextOptions<PolicyProjectContext> options)
            : base(options)
        {
        }

        public DbSet<PolicyProject.Models.User> User { get; set; }

        public DbSet<PolicyProject.Models.Policy> Policy { get; set; }
    }
}
