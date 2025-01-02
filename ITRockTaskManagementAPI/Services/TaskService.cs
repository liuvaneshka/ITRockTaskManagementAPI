﻿namespace ITRockTaskManagementAPI.Services
{
    using ITRockTaskManagementAPI.Entities;
    using ITRockTaskManagementAPI.ServiceContracts;
    using ITRockTaskManagementAPI.RepositoryContracts;

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
    }
}