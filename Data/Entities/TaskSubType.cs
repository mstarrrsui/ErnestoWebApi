using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class TaskSubType
    {
        public TaskSubType()
        {
            Task = new HashSet<TaskEntity>();
        }

        [Key]
        [Column("TaskSubTypeID")]
        public int TaskSubTypeId { get; set; }

        [Column("TaskTypeID")]
        public int TaskTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }
        public int? Ordinal { get; set; }
        public bool? IsSystemCreated { get; set; }

        [ForeignKey("TaskTypeId")]
        [InverseProperty("TaskSubType")]
        public virtual TaskType TaskType { get; set; }

        [InverseProperty("CurrentSubTypeNavigation")]
        public virtual ICollection<TaskEntity> Task { get; set; }
    }
}