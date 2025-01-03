namespace ITRockTaskManagementAPI.RepositoryContracts
{
    using ITRockTaskManagementAPI.Entities;

    public interface ITaskRepository : IRepository<TaskEntity>
    {
        Task<List<TaskEntity>> GetAllTasksAsync();
        Task<TaskEntity> AddTaskAsync(TaskEntity task);
    }
}
