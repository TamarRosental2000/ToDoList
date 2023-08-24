using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
