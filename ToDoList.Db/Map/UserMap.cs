using FluentNHibernate.Mapping;
using ToDoList.Db.Table;

namespace ToDoList.Db.Map
{
    internal class UserMap:ClassMap<User>
    {
        public UserMap() 
        {
            Id(x => x.UserId);
            Map(x => x.IsActive);
            Map(x => x.Name);

        }
    }
}
