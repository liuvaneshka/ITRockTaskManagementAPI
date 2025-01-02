namespace ITRockTaskManagementAPI.Repositories
{
    using ITRockTaskManagementAPI.Data;
    using ITRockTaskManagementAPI.Entities;
    using ITRockTaskManagementAPI.RepositoryContracts;
    using Microsoft.EntityFrameworkCore;

    public class TaskRepository : ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context)
        {
            _context = context;
        }

        public async Task<List<TaskEntity>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskEntity> AddTaskAsync(TaskEntity task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
    }
}
