using Logic.Utils;
using ToDoList.Db.Table;

namespace ToDoList.Db.Query
{
    public class UserQuery
    {
        private readonly UnitOfWork _unitOfWork;

        public UserQuery(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User GetById(int id)
        {
            return _unitOfWork.Get<User>(id);
        }

        public IReadOnlyList<User> GetList()
        {
            IQueryable<User> query = _unitOfWork.Query<User>();

            List<User> result = query.ToList();

            return result;
        }


    }
}
