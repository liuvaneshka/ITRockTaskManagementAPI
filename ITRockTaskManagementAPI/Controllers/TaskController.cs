using ITRockTaskManagementAPI.Entities;
using ITRockTaskManagementAPI.ServiceContracts;
using ITRockTaskManagementAPI.RepositoryContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITRockTaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TaskEntity>> CreateTask(TaskEntity task)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(task.Title)) return BadRequest("Title is required.");
                var createdTask = await _service.CreateTaskAsync(task);

                return CreatedAtRoute("GetTaskById", new { id = createdTask.Id }, createdTask);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskEntity>>> GetAllTasks()
        {
            return await _service.GetAllTasksAsync();
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<ActionResult<TaskEntity>> GetTaskById(int id)
        {
            var task = await _service.GetTaskByIdAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

    }
}
