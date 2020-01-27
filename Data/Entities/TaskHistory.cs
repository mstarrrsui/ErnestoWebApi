using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class TaskHistory
    {
        [Key]
        [Column("TaskHistoryID")]
        public int TaskHistoryId { get; set; }
        [Column("TaskTypeID")]
        public int TaskTypeId { get; set; }
        [Column("TaskSubTypeID")]
        public int TaskSubTypeId { get; set; }
        [Column("TaskEventID")]
        public int TaskEventId { get; set; }
        [Column("TaskID")]
        public int TaskId { get; set; }
        public int? AssignedTo { get; set; }
        public int AssignedBy { get; set; }
        public string Note { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime VersionTimestamp { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SuspenseDate { get; set; }
        [Column("SentToIR")]
        public bool? SentToIr { get; set; }
        public int? BrokerAssignedTo { get; set; }
        public string BrokerNote { get; set; }
        public int? BrokerCreatedBy { get; set; }

        [ForeignKey(nameof(AssignedBy))]
        [InverseProperty(nameof(Employee.TaskHistoryAssignedByNavigation))]
        public virtual Employee AssignedByNavigation { get; set; }
        [ForeignKey(nameof(AssignedTo))]
        [InverseProperty(nameof(Employee.TaskHistoryAssignedToNavigation))]
        public virtual Employee AssignedToNavigation { get; set; }
        [ForeignKey(nameof(BrokerAssignedTo))]
        [InverseProperty(nameof(People.TaskHistoryBrokerAssignedToNavigation))]
        public virtual People BrokerAssignedToNavigation { get; set; }
        [ForeignKey(nameof(BrokerCreatedBy))]
        [InverseProperty(nameof(People.TaskHistoryBrokerCreatedByNavigation))]
        public virtual People BrokerCreatedByNavigation { get; set; }
        [ForeignKey(nameof(TaskId))]
        [InverseProperty("TaskHistory")]
        public virtual TaskEntity Task { get; set; }
        [ForeignKey(nameof(TaskEventId))]
        [InverseProperty(nameof(TaskEventCode.TaskHistory))]
        public virtual TaskEventCode TaskEvent { get; set; }
        [ForeignKey(nameof(TaskSubTypeId))]
        [InverseProperty("TaskHistory")]
        public virtual TaskSubType TaskSubType { get; set; }
        [ForeignKey(nameof(TaskTypeId))]
        [InverseProperty("TaskHistory")]
        public virtual TaskType TaskType { get; set; }
    }
}
