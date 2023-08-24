using FluentNHibernate.Mapping;
using ToDoList.Db.Table;

namespace ToDoList.Db.Map
{
    public class TaskItemMap:ClassMap<TaskItem>
    {
        public TaskItemMap() 
        {
            Id(x => x.TaskId);
            Map(x => x.IsDone);
            Map(x => x.ParentTaskId);
            Map(x => x.Status);
            Map(x => x.DueDate);
            Map(x => x.Description);
            Map(x => x.Title);
        }
    }
}
