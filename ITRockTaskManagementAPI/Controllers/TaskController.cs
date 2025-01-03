using ITRockTaskManagementAPI.Entities;
using ITRockTaskManagementAPI.Filters;
using ITRockTaskManagementAPI.Requests;
using ITRockTaskManagementAPI.Responses;
using ITRockTaskManagementAPI.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ITRockTaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ExceptionHandlingFilter))]
    [ServiceFilter(typeof(ApiKeyFilter))]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateRequest taskRequest)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var taskEntity = new TaskEntity
            {
                Title = taskRequest.Title,
                Description = taskRequest.Description,
                IsCompleted = taskRequest.IsCompleted,
                DueDate = taskRequest.DueDate
            };

            var createdTask = await _service.CreateTaskAsync(taskEntity);

            var taskResponse = new TaskResponse
            {
                Id = createdTask.Id,
                Title = createdTask.Title,
                Description = createdTask.Description,
                IsCompleted = createdTask.IsCompleted,
                DueDate = createdTask.DueDate
            };

            return CreatedAtRoute("GetTaskById", new { id = createdTask.Id }, taskResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _service.GetAllTasksAsync();
            var taskResponses = tasks.Select(task => _service.ConvertToTaskResponse(task)).ToList();

            return Ok(taskResponses);
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            if (task == null) return NotFound($"Task with ID {id} not found.");

            var taskResponse = _service.ConvertToTaskResponse(task);

            return Ok(taskResponse);
        }
    }
}
