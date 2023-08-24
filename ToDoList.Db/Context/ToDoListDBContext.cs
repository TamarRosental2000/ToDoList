using Microsoft.EntityFrameworkCore;
using ToDoList.Db.Table;
using TaskItem = ToDoList.Db.Table.TaskItem;

namespace ToDoList.Db.Context
{
    public class ToDoListDBContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Database=ToDoList;Server=ILTAMARR-LT1;Trusted_Connection=True;Encrypt=false", b => b.MigrationsAssembly("ToDoList"));
        }
    }
}
