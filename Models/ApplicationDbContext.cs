using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GigApp.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace GigApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
