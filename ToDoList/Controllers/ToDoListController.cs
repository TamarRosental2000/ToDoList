using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoList.Db.Table;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ToDoListController> _logger;

        public ToDoListController(ILogger<ToDoListController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// Get user tasks.
        /// </summary>
        /// <param name="userId">userId ID.</param>
        /// <returns>List of  user tasks.</returns>
        [Route("{userId}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<TaskItem>), (int)HttpStatusCode.OK)]
        public async Task< IEnumerable<TaskItem> >GetUserTask(Guid userId)
        {
            return Enumerable.Range(1, 5).Select(index => new TaskItem
            {
                //Date = DateTime.Now.AddDays(index),
                //TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        /// <summary>
        /// Get task details.
        /// </summary>
        /// <param name="taskId">TaskId ID.</param>
        [Route("orders/{taskId}")]
        [HttpGet]
        [ProducesResponseType(typeof(TaskItem), (int)HttpStatusCode.OK)]
        public async Task<TaskItem> GetTaskDetails()
        {
            return null;
        }
    }
}