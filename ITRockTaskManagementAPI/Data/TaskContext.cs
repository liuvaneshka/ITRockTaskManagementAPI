namespace ITRockTaskManagementAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using ITRockTaskManagementAPI.Entities;
    using System.Collections.Generic;

    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; }
    }
}
