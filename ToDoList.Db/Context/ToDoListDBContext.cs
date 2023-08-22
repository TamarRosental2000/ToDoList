using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Db.Table;
using Microsoft.EntityFrameworkCore;
using Task = ToDoList.Db.Table.Task;
using Microsoft.Extensions.Options;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ToDoList.Db.Context
{
    public class ToDoListDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Database=ToDoList;Server=ILTAMARR-LT1;Trusted_Connection=True;Encrypt=false", b => b.MigrationsAssembly("ToDoList"));
        }
    }
}
