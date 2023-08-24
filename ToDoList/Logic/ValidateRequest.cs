using Logic.Utils;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Controllers;
using ToDoList.Db.Command;
using ToDoList.Db.Query;
using ToDoList.Db.Table;

namespace ToDoList.Api.Logic
{
    public class ValidateRequest
    {
        private readonly ILogger<ToDoListController> _logger;

        public ValidateRequest(ILogger<ToDoListController> logger)
        {
            _logger = logger;
        }

        public string ValidateUser(User user)
        {
            if(user == null)
            {
                return "User is Null";
            }
            if (string.IsNullOrEmpty(user.Name))
            {
                return "User Name is Null Or Empty";
            }
            return string.Empty;
        }
        public string ValidateTask(TaskItem task)
        {
            if (task == null)
            {
                return "Task is Null";
            }
            if (string.IsNullOrEmpty(task.Title))
            {
                return "Task Title is Null Or Empty";
            }
            return string.Empty;
        }

    }
}
