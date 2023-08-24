using Logic.Utils;
using ToDoList.Db.Table;

namespace ToDoList.Db.Query
{
    public class TaskQuery
    {
        private readonly UnitOfWork _unitOfWork;

        public TaskQuery(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public TaskItem GetById(int id)
        {
            return _unitOfWork.Get<TaskItem>(id);
        }

        public IReadOnlyList<TaskItem> GetList()
        {
            IQueryable<TaskItem> query = _unitOfWork.Query<TaskItem>();

            List<TaskItem> result = query.ToList();

            return result;
        }

        public IReadOnlyList<TaskItem> GetByUserId(int userId)
        {
            return GetList().Where(t => t.UserId == userId).ToList();
        }

    }
}
