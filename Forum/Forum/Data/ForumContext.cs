using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thread>().HasKey(x => x.Id).ForSqlServerIsClustered();
            modelBuilder.Entity<Thread>().Property(x => x.Id).UseSqlServerIdentityColumn();
        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Thread> Threads { get; set; }

    }
}
