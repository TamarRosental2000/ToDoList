using Logic.Utils;
using ToDoList.Db.Table;

namespace ToDoList.Db.Command
{
    public sealed class UserRepository
    {
        private readonly UnitOfWork _unitOfWork;

        public UserRepository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Save(User taskItem)
        {
            _unitOfWork.SaveOrUpdate(taskItem);
            _unitOfWork.Commit();
        }
       
    }
}
