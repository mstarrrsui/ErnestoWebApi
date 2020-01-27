using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("PEOPLE")]
    public partial class People
    {
        public People()
        {
            PeopleAddress = new HashSet<PeopleAddress>();
            PeopleCategory = new HashSet<PeopleCategory>();
            PeopleLocationXref = new HashSet<PeopleLocationXref>();
            PeoplePhone = new HashSet<PeoplePhone>();
            SubmissionAccountContact = new HashSet<Submission>();
            SubmissionPeopleSkeyNavigation = new HashSet<Submission>();
            Task = new HashSet<TaskEntity>();
            TaskHistoryBrokerAssignedToNavigation = new HashSet<TaskHistory>();
            TaskHistoryBrokerCreatedByNavigation = new HashSet<TaskHistory>();
        }

        [Key]
        [Column("PEOPLE_SKEY")]
        public int PeopleSkey { get; set; }
        [Column("PEOPLE_TYPE")]
        public int PeopleType { get; set; }
        [Column("LAST_NAME")]
        [StringLength(60)]
        public string LastName { get; set; }
        [Column("FIRST_NAME")]
        [StringLength(60)]
        public string FirstName { get; set; }
        [Column("NICKNAME")]
        [StringLength(20)]
        public string Nickname { get; set; }
        [Column("SEX")]
        [StringLength(1)]
        public string Sex { get; set; }
        [Column("EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column("EXPIRATION_DATE", TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        [Column("ACTIVE_CODE")]
        [StringLength(1)]
        public string ActiveCode { get; set; }
        [Column("TITLE")]
        [StringLength(60)]
        public string Title { get; set; }
        [Column("BIRTH_DATE", TypeName = "datetime")]
        public DateTime? BirthDate { get; set; }
        [Column("ANNIVERSARY_DATE", TypeName = "datetime")]
        public DateTime? AnniversaryDate { get; set; }
        [Column("ASSISTANT_NAME")]
        [StringLength(60)]
        public string AssistantName { get; set; }
        [Column("MANAGER_NAME")]
        [StringLength(60)]
        public string ManagerName { get; set; }
        [Column("SPOUSE_NAME")]
        [StringLength(60)]
        public string SpouseName { get; set; }
        [Column("COMMENTS")]
        [StringLength(60)]
        public string Comments { get; set; }
        [Column("EMAIL_ADDRESS_1")]
        [StringLength(60)]
        public string EmailAddress1 { get; set; }
        [Column("EMAIL_ADDRESS_2")]
        [StringLength(60)]
        public string EmailAddress2 { get; set; }
        [Column("EMAIL_ADDRESS_3")]
        [StringLength(60)]
        public string EmailAddress3 { get; set; }
        [Column("CHILD_NAME_1")]
        [StringLength(60)]
        public string ChildName1 { get; set; }
        [Column("CHILD_SEX_1")]
        [StringLength(1)]
        public string ChildSex1 { get; set; }
        [Column("CHILD_NAME_2")]
        [StringLength(60)]
        public string ChildName2 { get; set; }
        [Column("CHILD_SEX_2")]
        [StringLength(1)]
        public string ChildSex2 { get; set; }
        [Column("CHILD_NAME_3")]
        [StringLength(60)]
        public string ChildName3 { get; set; }
        [Column("CHILD_SEX_3")]
        [StringLength(1)]
        public string ChildSex3 { get; set; }
        [Column("CHILD_NAME_4")]
        [StringLength(60)]
        public string ChildName4 { get; set; }
        [Column("CHILD_SEX_4")]
        [StringLength(1)]
        public string ChildSex4 { get; set; }
        [Column("OLD_PEOPLE_TYPE")]
        [StringLength(60)]
        public string OldPeopleType { get; set; }
        [Column("OLD_PEOPLE_NUMBER")]
        public int? OldPeopleNumber { get; set; }
        [Column("EXTERNAL_LOGIN")]
        [StringLength(100)]
        public string ExternalLogin { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }
        public int? MainLocationSkey { get; set; }

        [ForeignKey(nameof(PeopleType))]
        [InverseProperty(nameof(ReferenceType.People))]
        public virtual ReferenceType PeopleTypeNavigation { get; set; }
        [InverseProperty("PeopleSkeyNavigation")]
        public virtual ICollection<PeopleAddress> PeopleAddress { get; set; }
        [InverseProperty("PeopleSkeyNavigation")]
        public virtual ICollection<PeopleCategory> PeopleCategory { get; set; }
        [InverseProperty("PeopleSkeyNavigation")]
        public virtual ICollection<PeopleLocationXref> PeopleLocationXref { get; set; }
        [InverseProperty("PeopleSkeyNavigation")]
        public virtual ICollection<PeoplePhone> PeoplePhone { get; set; }
        [InverseProperty(nameof(Submission.AccountContact))]
        public virtual ICollection<Submission> SubmissionAccountContact { get; set; }
        [InverseProperty(nameof(Submission.PeopleSkeyNavigation))]
        public virtual ICollection<Submission> SubmissionPeopleSkeyNavigation { get; set; }
        [InverseProperty("BrokerCurrentlyAssignedToNavigation")]
        public virtual ICollection<TaskEntity> Task { get; set; }
        [InverseProperty(nameof(TaskHistory.BrokerAssignedToNavigation))]
        public virtual ICollection<TaskHistory> TaskHistoryBrokerAssignedToNavigation { get; set; }
        [InverseProperty(nameof(TaskHistory.BrokerCreatedByNavigation))]
        public virtual ICollection<TaskHistory> TaskHistoryBrokerCreatedByNavigation { get; set; }
    }
}
