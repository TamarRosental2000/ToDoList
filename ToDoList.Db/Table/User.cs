using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Db.Table
{
    public class User
    {
        public User(string? name)
        {
            Name = name;
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [StringLength(80, MinimumLength = 1)]
        public string? Name { get; set; }
        public DateTime CreateDate { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}