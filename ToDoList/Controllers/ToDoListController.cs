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
        /// Add user.
        /// </summary>
        [Route("create/user")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUser(
            [FromBody] UserModel request)
        {
            //await _mediator.Send(new PlaceUserTaskCommand(userId, request.Products, request.Currency));

            return Created(string.Empty, null);
        }

        /// <summary>
        /// Get user tasks.
        /// </summary>
        /// <param name="userId">userId ID.</param>
        /// <returns>List of  user tasks.</returns>
        [Route("tasks/{userId}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<TaskItem>), (int)HttpStatusCode.OK)]
        public async Task< IEnumerable<TaskItem> >GetUserTask([FromRoute] Guid userId)
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
        [Route("tasks/detail/{taskId}")]
        [HttpGet]
        [ProducesResponseType(typeof(TaskItem), (int)HttpStatusCode.OK)]
        public async Task<TaskItem> GetTaskDetails([FromRoute] Guid taskId)
        {
            return null;
        }
        /// <summary>
        /// Add user task.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="request">Task list.</param>
        [Route("add/task/{userId}")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUserTask(
            [FromRoute] Guid userId,
            [FromBody] TaskItem request)
        {
            //await _mediator.Send(new PlaceUserTaskCommand(userId, request.Products, request.Currency));

            return Created(string.Empty, null);
        }
        /// <summary>
        /// Change user task.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="taskId">Task ID.</param>
        /// <param name="request">List of products.</param>
        [Route("{userId}/tasks/edit/{taskId}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangeUserTask(
            [FromRoute] Guid userId,
            [FromRoute] Guid taskId,
            [FromBody] TaskItem request)
        {
            //await _mediator.Send(new ChangeUserTaskCommand(userId, taskId, request.Products, request.Currency));

            return Ok();
        }
        /// <summary>
        /// Remove user task.
        /// </summary>
        /// <param name="userId">User ID.</param>
        /// <param name="taskId">Task ID.</param>
        [Route("{userId}/orders/{taskId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<TaskItem>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveCustomerOrder(
            [FromRoute] Guid userId,
            [FromRoute] Guid taskId)
        {
            //await _mediator.Send(new RemoveCustomerOrderCommand(userId, taskId));

            return Ok();
        }
    }
}