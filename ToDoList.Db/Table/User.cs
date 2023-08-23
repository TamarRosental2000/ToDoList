using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Db.Table
{
    public class User
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [StringLength(80, MinimumLength = 1)]
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
        private readonly IList<TaskItem> _userTask = new List<TaskItem>();

        public virtual IReadOnlyList<TaskItem> UserTask => _userTask.ToList();
        public virtual TaskItem FirstTask => GetTask(0);
        protected User() { }
        private TaskItem GetTask(int index)
        {
            if (_userTask.Count > index)
                return _userTask[index];

            return null;
        }
        public virtual void RemoveTask(TaskItem task)
        {
            _userTask.Remove(task);
        }
        public virtual void AddTask(TaskItem task)
        {
            _userTask.Add(task);
        }
    }
}