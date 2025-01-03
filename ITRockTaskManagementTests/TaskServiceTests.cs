using ITRockTaskManagementAPI.Entities;
using ITRockTaskManagementAPI.RepositoryContracts;
using ITRockTaskManagementAPI.Services;
using Moq;

namespace ITRockTaskManagementAPI.Tests
{
    [TestFixture]
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _mockRepository;
        private readonly TaskService _taskService;

        // Setup
        public TaskServiceTests()
        {
            _mockRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_mockRepository.Object);
        }

        [Test]
        public async Task GetAllTasksAsync_ReturnsTaskList()
        {
            // Arrange
            var tasks = new List<TaskEntity>
            {
                new TaskEntity { Id = 1, Title = "Task 1", IsCompleted = false },
                new TaskEntity { Id = 2, Title = "Task 2", IsCompleted = true }
            };

            _mockRepository.Setup(repo => repo.GetAllTasksAsync()).ReturnsAsync(tasks);

            // Act
            var result = await _taskService.GetAllTasksAsync();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Task 1", result[0].Title);
        }

        [Test]
        public async Task CreateTaskAsync_CreatesTask_ReturnsTask()
        {
            // Arrange
            var newTask = new TaskEntity
            {
                Title = "New Task",
                Description = "Task Description",
                IsCompleted = false,
                DueDate = null
            };

            var createdTask = new TaskEntity
            {
                Id = 1,
                Title = "New Task",
                Description = "Task Description",
                IsCompleted = false,
                DueDate = null
            };

            _mockRepository.Setup(repo => repo.AddTaskAsync(It.IsAny<TaskEntity>())).ReturnsAsync(createdTask);

            // Act
            var result = await _taskService.CreateTaskAsync(newTask);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("New Task", result.Title);
        }


        [Test]
        public async Task GetTaskByIdAsync_ReturnsTask()
        {
            // Arrange
            var task = new TaskEntity { Id = 1, Title = "Task 1", IsCompleted = true };
            _mockRepository.Setup(repo => repo.GetTaskByIdAsync(1)).ReturnsAsync(task);

            // Act
            var result = await _taskService.GetTaskByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual("Task 1", result.Title);
            Assert.AreEqual(1, result.Id);
        }


        [Test]
        public void ConvertToTaskResponse_ConvertsTaskEntityToTaskResponse()
        {
            // Arrange
            var taskEntity = new TaskEntity
            {
                Id = 1,
                Title = "Task 1",
                Description = "Description",
                IsCompleted = true,
                DueDate = null
            };

            // Act
            var response = _taskService.ConvertToTaskResponse(taskEntity);

            // Assert
            Assert.NotNull(response);
            Assert.AreEqual(taskEntity.Id, response.Id);
            Assert.AreEqual(taskEntity.Title, response.Title);
            Assert.AreEqual(taskEntity.Description, response.Description);
            Assert.AreEqual(taskEntity.IsCompleted, response.IsCompleted);
            Assert.AreEqual(taskEntity.DueDate, response.DueDate);
        }
    }
}
