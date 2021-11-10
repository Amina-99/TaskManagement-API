using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskmanagementAPI_Beta.EntityConfiguration;
using TaskmanagementAPI_Beta.Models;

namespace TaskmanagementAPI_Beta
{
    public class TaskmanagementDbContext : DbContext
    {
        public DbSet<Models.Task> Task { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Status> Status { get; set; }
        public TaskmanagementDbContext(DbContextOptions<TaskmanagementDbContext> options)
       : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
