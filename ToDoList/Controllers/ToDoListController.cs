using Azure.Core;
using Logic.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using ToDoList.Api.Logic;
using ToDoList.Api.Models;
using ToDoList.Db.Command;
using ToDoList.Db.Query;
using ToDoList.Db.Table;

namespace ToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly UserRepository _userRepository;
        private readonly TaskItemRepository _taskItemRepository;
        private readonly TaskQuery _taskQuery;
        private readonly UserQuery _userQuery;
        private readonly ValidateRequest _ValidateRequest;
        private readonly ILogger<ToDoListController> _logger;

        public ToDoListController(ILogger<ToDoListController> logger, UnitOfWork unitOfWork, TaskQuery taskQuery, ValidateRequest validateRequest, UserQuery userQuery)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _userRepository = new UserRepository(unitOfWork);
            _taskItemRepository = new TaskItemRepository(unitOfWork);
            _taskQuery = taskQuery;
            _ValidateRequest = validateRequest;
            _userQuery = userQuery;
        }
        /// <summary>
        /// Add user.
        /// </summary>
        [Route("create/user")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> AddUser([FromBody] User request)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateUser(request);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(request);
                }
                _userRepository.Save(request);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Inactive user.
        /// </summary>
        /// <param name="userId">User ID.</param>
        [Route("user/Inactive/{userId}")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.Unused)]
        public async Task<IActionResult> InactiveUser([FromRoute] int userId)
        {
            try
            {
                var user = _userQuery.GetById(userId);
                var errMsg = _ValidateRequest.ValidateUser(user);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(user);
                }
                user.IsActive = false;
                _userRepository.Save(user);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Get user tasks.
        /// </summary>
        /// <param name="userId">userId ID.</param>
        /// <returns>List of  user tasks.</returns>
        [Route("tasks/{userId}")]
        [HttpGet]
        [ProducesResponseType(typeof(List<TaskItem>), (int)HttpStatusCode.OK)]
        public async Task<TaskListResponse> GetUserTasks([FromRoute] int userId)
        {
            try
            {
                var taskList = _taskQuery.GetByUserId(userId);
                return new TaskListResponse()
                {
                    Status = Ok(),
                    Tasks = taskList
                };
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return new TaskListResponse()
                {
                    Status = BadRequest(ex.Message),
                    Tasks = null
                };
            }
        }

        /// <summary>
        /// Add user task.
        /// </summary>
        /// <param name="request">Task list.</param>
        [Route("add/task")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            try
            {
                var errMsg = _ValidateRequest.ValidateTask(task);
                if (!string.IsNullOrEmpty(errMsg))
                {
                    _logger.Log(LogLevel.Error, errMsg);
                    return BadRequest(task);
                }
                _taskItemRepository.Save(task);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }

        }


        /// <summary>
        /// Remove user task.
        /// </summary>
        /// <param name="taskId">Task ID.</param>
        [Route("removeTask/{taskId}")]
        [HttpDelete]
        [ProducesResponseType(typeof(List<TaskItem>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> RemoveTask(
            [FromRoute] int taskId)
        {
            try
            {
                var task = _taskQuery.GetById(taskId);
                if (task != null)
                {
                    _taskItemRepository.Delete(task);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);

                return BadRequest(ex.Message);
            }

        }
    }
}