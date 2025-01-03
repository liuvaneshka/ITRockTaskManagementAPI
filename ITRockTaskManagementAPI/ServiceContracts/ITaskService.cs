namespace ITRockTaskManagementAPI.ServiceContracts
{
    using ITRockTaskManagementAPI.Entities;

    public interface ITaskService
    {
        /// <summary>
        /// Get all tasks
        /// </summary>
        /// <returns> a list of tasks</returns>
        Task<List<TaskEntity>> GetAllTasksAsync();
        /// <summary>
        /// Creates a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<TaskEntity> CreateTaskAsync(TaskEntity task);

        /// <summary>
        /// Get a Task by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> a task </returns>
        Task<TaskEntity?> GetTaskByIdAsync(int id);
    }
}
