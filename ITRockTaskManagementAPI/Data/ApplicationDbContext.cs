namespace ITRockTaskManagementAPI.Data
{
    using Microsoft.EntityFrameworkCore;
    using ITRockTaskManagementAPI.Entities;
    using System.Collections.Generic;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks { get; set; } = null!;
    }
}
