using Domain.Core;
using Microsoft.EntityFrameworkCore;
using Persistence.EF.DummyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    /// <summary>
    /// ORM context for EF we saying there we want using task model object inside database
    /// </summary>
    public class TaskManagerContext : DbContext
    {
        public TaskManagerContext(DbContextOptions<TaskManagerContext> options) : base(options)
        {
            
        }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagerContext).Assembly);
            foreach(var task in DummyTasks.Get())
            {
                modelBuilder.Entity<TaskModel>().HasData(task);
            }
        }
    }
}
