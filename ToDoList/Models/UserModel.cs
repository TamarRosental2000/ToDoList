using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Db.Table
{
    public class UserModel:User
    {
        private readonly IList<User> _userTask = new List<User>();

        public UserModel(string? name) : base(name)
        {
        }

        public virtual IReadOnlyList<User> UserTask => _userTask.ToList();
        public virtual User FirstTask => GetTask(0);
        private User GetTask(int index)
        {
            if (_userTask.Count > index)
                return _userTask[index];

            return null;
        }
        public virtual void RemoveTask(User task)
        {
            _userTask.Remove(task);
        }
        public virtual void AddTask(User task)
        {
            _userTask.Add(task);
        }
    }
}