using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Db.Table;

namespace ToDoList.Db.Query
{
    public class TaskItemRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public TaskItemRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TaskItem GetById(long id)
        {
            return _unitOfWork.Get<TaskItem>(id);
        }

        public IReadOnlyList<TaskItem> GetList()
        {
            IQueryable<TaskItem> query = _unitOfWork.Query<TaskItem>();

            List<TaskItem> result = query.ToList();
           
            return result;
        }

        public void Save(TaskItem taskItem)
        {
            _unitOfWork.SaveOrUpdate(taskItem);
        }

        public void Delete(TaskItem taskItem)
        {
            _unitOfWork.Delete(taskItem);
        }
    }
}
