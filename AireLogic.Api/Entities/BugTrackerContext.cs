using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AireLogic.Api.Entities
{
    public class BugTrackerContext : DbContext
    {
        public BugTrackerContext(DbContextOptions<BugTrackerContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Person> People { get; set; }

        public DbSet<Bug> Bugs { get; set; }
    }
}
