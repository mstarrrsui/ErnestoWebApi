using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class TaskEntity
    {
        public TaskEntity()
        {
            TaskHistory = new HashSet<TaskHistory>();
        }

        [Key]
        [Column("TaskID")]
        public int TaskId { get; set; }
        public int CurrentTaskType { get; set; }
        [Column("Sub_Record_Number")]
        public int? SubRecordNumber { get; set; }
        public int CurrentlyAssignedTo { get; set; }
        public int CurrentSubType { get; set; }
        public int CreatedBy { get; set; }
        public int? CompletedBy { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompleteDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SuspenseDate { get; set; }
        public bool IsHighPriority { get; set; }
        public bool IsRead { get; set; }
        [Column("DocRefNUmber")]
        [StringLength(36)]
        public string DocRefNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime VersionTimestamp { get; set; }
        public int? SuspensedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SuspensedOn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastModifiedDate { get; set; }
        public string LastNote { get; set; }
        public int? AuditKey { get; set; }
        public int? ClaimKey { get; set; }
        [Column("DocumentID")]
        public int? DocumentId { get; set; }
        [Column("PageID")]
        public int? PageId { get; set; }
        public string LastBrokerNote { get; set; }
        public int? BrokerCurrentlyAssignedTo { get; set; }
        public bool? ClosedWithNoIssue { get; set; }

        [ForeignKey(nameof(BrokerCurrentlyAssignedTo))]
        [InverseProperty(nameof(People.Task))]
        public virtual People BrokerCurrentlyAssignedToNavigation { get; set; }
        [ForeignKey(nameof(ClaimKey))]
        [InverseProperty(nameof(Claims.Task))]
        public virtual Claims ClaimKeyNavigation { get; set; }
        [ForeignKey(nameof(CompletedBy))]
        [InverseProperty(nameof(Employee.TaskCompletedByNavigation))]
        public virtual Employee CompletedByNavigation { get; set; }
        [ForeignKey(nameof(CreatedBy))]
        [InverseProperty(nameof(Employee.TaskCreatedByNavigation))]
        public virtual Employee CreatedByNavigation { get; set; }
        [ForeignKey(nameof(CurrentSubType))]
        [InverseProperty(nameof(TaskSubType.Task))]
        public virtual TaskSubType CurrentSubTypeNavigation { get; set; }
        [ForeignKey(nameof(CurrentTaskType))]
        [InverseProperty(nameof(TaskType.Task))]
        public virtual TaskType CurrentTaskTypeNavigation { get; set; }
        [ForeignKey(nameof(CurrentlyAssignedTo))]
        [InverseProperty(nameof(Employee.TaskCurrentlyAssignedToNavigation))]
        public virtual Employee CurrentlyAssignedToNavigation { get; set; }
        [ForeignKey(nameof(SubRecordNumber))]
        [InverseProperty(nameof(Submission.Task))]
        public virtual Submission SubRecordNumberNavigation { get; set; }
        [ForeignKey(nameof(SuspensedBy))]
        [InverseProperty(nameof(Employee.TaskSuspensedByNavigation))]
        public virtual Employee SuspensedByNavigation { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<TaskHistory> TaskHistory { get; set; }
    }
}
