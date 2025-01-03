using ITRockTaskManagementAPI.Data;
using ITRockTaskManagementAPI.Entities;
using ITRockTaskManagementAPI.RepositoryContracts;
using Microsoft.EntityFrameworkCore;

namespace ITRockTaskManagementAPI.Repositories
{
    public class TaskRepository : RepositoryBase<TaskEntity, ApplicationDbContext>, ITaskRepository
    {
        public TaskRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        protected override DbSet<TaskEntity> DbSet => DbContext.Tasks;

        public async Task<List<TaskEntity>> GetAllTasksAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TaskEntity> AddTaskAsync(TaskEntity task)
        {
            var addedTask = await DbSet.AddAsync(task);
            await DbContext.SaveChangesAsync();
            return addedTask.Entity;
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}

