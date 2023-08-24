using Logic.Utils;
using ToDoList.Db.Table;

namespace ToDoList.Db.Command
{
    public class TaskItemRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public TaskItemRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public void Save(TaskItem taskItem)
        {
            _unitOfWork.SaveOrUpdate(taskItem);
            _unitOfWork.Commit();
        }

        public void Delete(TaskItem taskItem)
        {
            _unitOfWork.Delete(taskItem);
            _unitOfWork.Commit();
        }

    }
}
