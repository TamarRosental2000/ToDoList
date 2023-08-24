using Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
        public User GetById(int id)
        {
            return _unitOfWork.Get<User>(id);
        }
        public User GetByName(string name)
        {
            return _unitOfWork.Query<User>()
                .SingleOrDefault(x => x.Name == name);
        }
    }
}
