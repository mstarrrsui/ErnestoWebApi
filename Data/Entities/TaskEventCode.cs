using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class TaskEventCode
    {
        public TaskEventCode()
        {
            TaskHistory = new HashSet<TaskHistory>();
        }

        [Key]
        [Column("TaskEventID")]
        public int TaskEventId { get; set; }
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [InverseProperty("TaskEvent")]
        public virtual ICollection<TaskHistory> TaskHistory { get; set; }
    }
}
