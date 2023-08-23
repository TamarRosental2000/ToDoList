using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Db.Table
{
    public class TaskItem
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public int? ParentTaskId { get; set; }

        [StringLength(80, MinimumLength = 1)]
        public string Title { get; set; }
        [StringLength(500, MinimumLength = 1)]
        public string Description { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Status { get; set; }



        [DefaultValue(false)]
        public bool IsDone { get; set; }
    }
}
