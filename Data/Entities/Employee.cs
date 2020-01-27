using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("EMPLOYEE")]
    public partial class Employee
    {
        public Employee()
        {
            ClaimsModByNavigation = new HashSet<Claims>();
            ClaimsTpamonitorKeyNavigation = new HashSet<Claims>();
            InverseDefaultAssistantNavigation = new HashSet<Employee>();
            InverseReportingManager = new HashSet<Employee>();
            Submission = new HashSet<Submission>();
            TaskCompletedByNavigation = new HashSet<TaskEntity>();
            TaskCreatedByNavigation = new HashSet<TaskEntity>();
            TaskCurrentlyAssignedToNavigation = new HashSet<TaskEntity>();
            TaskHistoryAssignedByNavigation = new HashSet<TaskHistory>();
            TaskHistoryAssignedToNavigation = new HashSet<TaskHistory>();
            TaskSuspensedByNavigation = new HashSet<TaskEntity>();
        }

        [Key]
        [Column("EMP_RECORD_NUMBER")]
        public int EmpRecordNumber { get; set; }
        [Required]
        [Column("EMP_USER_PROFILE")]
        [StringLength(30)]
        public string EmpUserProfile { get; set; }
        [Column("EMP_LAST_NAME")]
        [StringLength(60)]
        public string EmpLastName { get; set; }
        [Column("EMP_ACTIVE_CODE")]
        [StringLength(1)]
        public string EmpActiveCode { get; set; }
        [Column("EMP_EXTENSION")]
        public int? EmpExtension { get; set; }
        [Column("EMP_FIRST_NAME")]
        [StringLength(60)]
        public string EmpFirstName { get; set; }
        [Column("EMP_MIDDLE_NAME")]
        [StringLength(60)]
        public string EmpMiddleName { get; set; }
        [Column("EMP_PREFIX")]
        [StringLength(5)]
        public string EmpPrefix { get; set; }
        [Column("EMP_BRANCH_NUMBER")]
        public int? EmpBranchNumber { get; set; }
        [Column("EMP_DEPARTMENT_NUMBER")]
        public int? EmpDepartmentNumber { get; set; }
        public Departments EmpDepartment { get; set; }
        [Column("EMP_EMAIL_ADDRESS")]
        [StringLength(60)]
        public string EmpEmailAddress { get; set; }
        [Column("EMP_FAXNUMBER")]
        [StringLength(10)]
        public string EmpFaxnumber { get; set; }
        [Column(TypeName = "money")]
        public decimal? PaymentAuthority { get; set; }
        public int? EmployeeTypeKey { get; set; }
        [Required]
        public bool? IsExempt { get; set; }
        [Required]
        public bool? IsOnPayroll { get; set; }
        public int? DefaultUnderwriter { get; set; }
        [Required]
        public bool? IsExecutive { get; set; }
        [StringLength(250)]
        public string Signature { get; set; }
        public bool? AllowCompressed { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CompressedStatusDate { get; set; }
        public bool WorkOtherDepartmentTasks { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? IndemnityReserveAuthority { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? ExpenseReserveAuthority { get; set; }
        [StringLength(5)]
        public string Initials { get; set; }
        [StringLength(255)]
        public string Address1 { get; set; }
        [StringLength(255)]
        public string Address2 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [Column("STATE_ABBREVIATION")]
        [StringLength(2)]
        public string StateAbbreviation { get; set; }
        [StringLength(10)]
        public string ZipCode { get; set; }
        public int? DefaultAssistant { get; set; }
        public bool? IsFireWarden { get; set; }
        public bool? IsFirstResponder { get; set; }
        public bool? IsNotaryPublic { get; set; }
        public bool? IsSharePointPowerUser { get; set; }
        public int? ReportingManagerId { get; set; }
        public int? BranchFloorId { get; set; }
        public int? PrimaryTeamId { get; set; }
        [StringLength(50)]
        public string AlternateEmailAddress { get; set; }
        [StringLength(10)]
        public string HomePhone { get; set; }
        [StringLength(10)]
        public string WorkPhone { get; set; }
        [Column("RSUTypePhone")]
        [StringLength(10)]
        public string RsutypePhone { get; set; }
        [Column("CELTypePhone")]
        [StringLength(10)]
        public string CeltypePhone { get; set; }
        [StringLength(10)]
        public string NotifyPhone { get; set; }
        [StringLength(20)]
        public string JobCode { get; set; }
        [StringLength(8)]
        public string UltiProEmployeeId { get; set; }
        public bool? UpdatedByUltipro { get; set; }
        [StringLength(255)]
        public string QuoteLetterSignatureText { get; set; }

        [ForeignKey(nameof(DefaultAssistant))]
        [InverseProperty(nameof(Employee.InverseDefaultAssistantNavigation))]
        public virtual Employee DefaultAssistantNavigation { get; set; }
        [ForeignKey(nameof(ReportingManagerId))]
        [InverseProperty(nameof(Employee.InverseReportingManager))]
        public virtual Employee ReportingManager { get; set; }
        [InverseProperty(nameof(Claims.ModByNavigation))]
        public virtual ICollection<Claims> ClaimsModByNavigation { get; set; }
        [InverseProperty(nameof(Claims.TpamonitorKeyNavigation))]
        public virtual ICollection<Claims> ClaimsTpamonitorKeyNavigation { get; set; }
        [InverseProperty(nameof(Employee.DefaultAssistantNavigation))]
        public virtual ICollection<Employee> InverseDefaultAssistantNavigation { get; set; }
        [InverseProperty(nameof(Employee.ReportingManager))]
        public virtual ICollection<Employee> InverseReportingManager { get; set; }
        [InverseProperty("EmpRecordNumberNavigation")]
        public virtual ICollection<Submission> Submission { get; set; }
        [InverseProperty(nameof(TaskEntity.CompletedByNavigation))]
        public virtual ICollection<TaskEntity> TaskCompletedByNavigation { get; set; }
        [InverseProperty(nameof(TaskEntity.CreatedByNavigation))]
        public virtual ICollection<TaskEntity> TaskCreatedByNavigation { get; set; }
        [InverseProperty(nameof(TaskEntity.CurrentlyAssignedToNavigation))]
        public virtual ICollection<TaskEntity> TaskCurrentlyAssignedToNavigation { get; set; }
        [InverseProperty(nameof(TaskHistory.AssignedByNavigation))]
        public virtual ICollection<TaskHistory> TaskHistoryAssignedByNavigation { get; set; }
        [InverseProperty(nameof(TaskHistory.AssignedToNavigation))]
        public virtual ICollection<TaskHistory> TaskHistoryAssignedToNavigation { get; set; }
        [InverseProperty(nameof(TaskEntity.SuspensedByNavigation))]
        public virtual ICollection<TaskEntity> TaskSuspensedByNavigation { get; set; }
    }
}
