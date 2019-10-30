using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class Task
    {
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

        [ForeignKey("CompletedBy")]
        [InverseProperty("TaskCompletedByNavigation")]
        public virtual Employee CompletedByNavigation { get; set; }
        [ForeignKey("CreatedBy")]
        [InverseProperty("TaskCreatedByNavigation")]
        public virtual Employee CreatedByNavigation { get; set; }
        [ForeignKey("CurrentSubType")]
        [InverseProperty("Task")]
        public virtual TaskSubType CurrentSubTypeNavigation { get; set; }
        [ForeignKey("CurrentTaskType")]
        [InverseProperty("Task")]
        public virtual TaskType CurrentTaskTypeNavigation { get; set; }
        [ForeignKey("CurrentlyAssignedTo")]
        [InverseProperty("TaskCurrentlyAssignedToNavigation")]
        public virtual Employee CurrentlyAssignedToNavigation { get; set; }
        [ForeignKey("SuspensedBy")]
        [InverseProperty("TaskSuspensedByNavigation")]
        public virtual Employee SuspensedByNavigation { get; set; }
    }
}
