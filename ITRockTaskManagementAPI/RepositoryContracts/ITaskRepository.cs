namespace ITRockTaskManagementAPI.RepositoryContracts
{
    using ITRockTaskManagementAPI.Entities;

    public interface ITaskRepository
    {
        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns> a list of tasks</returns>
        Task<List<TaskEntity>> GetAllTasksAsync();
        /// <summary>
        ///  Create a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<TaskEntity> AddTaskAsync(TaskEntity task);
    }
}
