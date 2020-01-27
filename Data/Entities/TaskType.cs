using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class TaskType
    {
        public TaskType()
        {
            Task = new HashSet<TaskEntity>();
            TaskHistory = new HashSet<TaskHistory>();
            TaskSubType = new HashSet<TaskSubType>();
        }

        [Key]
        [Column("TaskTypeID")]
        public int TaskTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        public int ProfitCenterKey { get; set; }

        [ForeignKey(nameof(ProfitCenterKey))]
        [InverseProperty(nameof(ProfitCenter.TaskType))]
        public virtual ProfitCenter ProfitCenterKeyNavigation { get; set; }
        [InverseProperty("CurrentTaskTypeNavigation")]
        public virtual ICollection<TaskEntity> Task { get; set; }
        [InverseProperty("TaskType")]
        public virtual ICollection<TaskHistory> TaskHistory { get; set; }
        [InverseProperty("TaskType")]
        public virtual ICollection<TaskSubType> TaskSubType { get; set; }
    }
}
