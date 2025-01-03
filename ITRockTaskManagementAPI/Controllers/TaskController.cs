using ITRockTaskManagementAPI.Entities;
using ITRockTaskManagementAPI.Filters;
using ITRockTaskManagementAPI.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace ITRockTaskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ExceptionHandlingFilter))]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _service;

        public TaskController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<TaskEntity>> CreateTask([FromBody] TaskEntity task)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

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
            try
            {
                var tasks = await _service.GetAllTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<ActionResult<TaskEntity>> GetTaskById(int id)
        {
            try
            {
                var task = await _service.GetTaskByIdAsync(id);
                if (task == null) return NotFound();
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"Internal server error: {ex.Message}");
            }
        }

    }
}
