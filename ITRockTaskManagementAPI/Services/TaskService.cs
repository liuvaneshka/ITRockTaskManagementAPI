namespace ITRockTaskManagementAPI.Services
{
    using ITRockTaskManagementAPI.Entities;
    using ITRockTaskManagementAPI.ServiceContracts;
    using ITRockTaskManagementAPI.RepositoryContracts;
    using ITRockTaskManagementAPI.Responses;

    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _repository;

        public TaskService(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskEntity>> GetAllTasksAsync()
        {
            return await _repository.GetAllTasksAsync();
        }

        public async Task<TaskEntity> CreateTaskAsync(TaskEntity task)
        {
            return await _repository.AddTaskAsync(task);
        }

        public async Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return await _repository.GetTaskByIdAsync(id);
        }

        public TaskResponse ConvertToTaskResponse(TaskEntity taskEntity)
        {
            return new TaskResponse
            {
                Id = taskEntity.Id,
                Title = taskEntity.Title,
                Description = taskEntity.Description,
                IsCompleted = taskEntity.IsCompleted,
                DueDate = taskEntity.DueDate
            };
        }
    }
}
