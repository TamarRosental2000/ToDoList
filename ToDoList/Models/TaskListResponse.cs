using Microsoft.AspNetCore.Mvc;
using ToDoList.Db.Table;

namespace ToDoList.Api.Models
{
    public class TaskListResponse
    {
        public IEnumerable<TaskItem> Tasks { get; set; }
        public IActionResult Status { get; set; }
    }
}
