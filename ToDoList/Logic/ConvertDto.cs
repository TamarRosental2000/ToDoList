using ToDoList.Db.Table;

namespace ToDoList.Api.Logic
{
    public class ConvertDto
    {
        public TaskItem ConvertToDto(TaskItemModel taskItemModel)
        {
            return new TaskItem
            {
                CreateDate= taskItemModel.CreateDate,
                Description= taskItemModel.Description,
                DueDate= taskItemModel.DueDate,
                IsDone= taskItemModel.IsDone,
                ParentTaskId= taskItemModel.ParentTaskId,   
                Status= taskItemModel.Status,
                TaskId= taskItemModel.TaskId,
                Title= taskItemModel.Title,
                UserId = taskItemModel.UserId
            };
        }
    }
}
