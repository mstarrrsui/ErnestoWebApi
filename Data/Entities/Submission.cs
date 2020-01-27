using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("SUBMISSION")]
    public partial class Submission
    {
        public Submission()
        {
            QuoteBinder = new HashSet<QuoteBinder>();
            Task = new HashSet<TaskEntity>();
        }

        [Key]
        [Column("SUB_RECORD_NUMBER")]
        public int SubRecordNumber { get; set; }
        [Column("DEPARTMENT_NUMBER")]
        public int? DepartmentNumber { get; set; }
        [Column("BRANCH_NUMBER")]
        public int? BranchNumber { get; set; }
        [Column("STATUS_CODE")]
        [StringLength(20)]
        public string StatusCode { get; set; }
        [Column("PEOPLE_SKEY")]
        public int? PeopleSkey { get; set; }
        [Column("LOCATION_SKEY")]
        public int? LocationSkey { get; set; }
        [Column("EMP_RECORD_NUMBER")]
        public int? EmpRecordNumber { get; set; }
        [Column("COMPANY_RECORD_NUMBER")]
        public int? CompanyRecordNumber { get; set; }
        [Column("PRIOR_SUB_RECORD_NUMBER")]
        public int? PriorSubRecordNumber { get; set; }
        [Column("SUB_SUBMISSION_NUMBER")]
        public int? SubSubmissionNumber { get; set; }
        [Column("SUB_VERSION_NUMBER")]
        public byte? SubVersionNumber { get; set; }
        [Column("SUB_RECEIVED_DATE", TypeName = "datetime")]
        public DateTime? SubReceivedDate { get; set; }
        [Column("SUB_EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime? SubEffectiveDate { get; set; }
        [Column("SUB_EXPIRATION_DATE", TypeName = "datetime")]
        public DateTime? SubExpirationDate { get; set; }
        [Column("SUB_POLICY_SYMBOL")]
        public int? SubPolicySymbol { get; set; }
        [Column("SUB_POLICY_NUMBER", TypeName = "numeric(6, 0)")]
        public decimal? SubPolicyNumber { get; set; }
        [Column("SUB_POLICY_SUFFIX", TypeName = "numeric(2, 0)")]
        public decimal? SubPolicySuffix { get; set; }
        [Column("SUB_POLICY_TYPE")]
        public int? SubPolicyType { get; set; }
        [Column("SUB_RENEWAL_FLAG")]
        [StringLength(1)]
        public string SubRenewalFlag { get; set; }
        [Column("SUB_REINS_SPREADER_VERSION_NO")]
        public int? SubReinsSpreaderVersionNo { get; set; }
        [Column("SUB_REINS_SPREADER_PRINT_DATE", TypeName = "datetime")]
        public DateTime? SubReinsSpreaderPrintDate { get; set; }
        [Column("SUB_CANCELLATION_DATE", TypeName = "datetime")]
        public DateTime? SubCancellationDate { get; set; }
        [Column("SUB_EXTENSION_DATE", TypeName = "datetime")]
        public DateTime? SubExtensionDate { get; set; }
        [Column("SUB_DO_PROFIT_OR_NON_PROFIT")]
        [StringLength(1)]
        public string SubDoProfitOrNonProfit { get; set; }
        [Column("SUB_RENEWAL_CODE")]
        [StringLength(1)]
        public string SubRenewalCode { get; set; }
        [Column("SUB_CURRENT_EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime? SubCurrentEffectiveDate { get; set; }
        [Column("SUB_CURRENT_EXPIRATION_DATE", TypeName = "datetime")]
        public DateTime? SubCurrentExpirationDate { get; set; }
        [Column("SUB_TRANSMISSION_DATE", TypeName = "datetime")]
        public DateTime? SubTransmissionDate { get; set; }
        [Column("SUB_COVERAGE_IN_FORCE")]
        [StringLength(1)]
        public string SubCoverageInForce { get; set; }
        [Column("SUB_DO_PROGRAM_APPLIES")]
        [StringLength(1)]
        public string SubDoProgramApplies { get; set; }
        [Column("SUB_DO_PROGRAM_ID")]
        public byte? SubDoProgramId { get; set; }
        [Column("SUB_NOTICE_SENT")]
        [StringLength(1)]
        public string SubNoticeSent { get; set; }
        [Column("SUB_INSURED_NAME")]
        [StringLength(200)]
        public string SubInsuredName { get; set; }
        [Column("SUB_INSURED_CITY")]
        [StringLength(60)]
        public string SubInsuredCity { get; set; }
        [Column("INSURED_STATE")]
        [StringLength(2)]
        public string InsuredState { get; set; }
        [Column("SUB_PURGE_DATE", TypeName = "datetime")]
        public DateTime? SubPurgeDate { get; set; }
        [Column("SUB_PURGE_FLAG")]
        [StringLength(1)]
        public string SubPurgeFlag { get; set; }
        [Column("QB_SEQUENCE_NO")]
        public int? QbSequenceNo { get; set; }
        [Column("SUB_COMMENT")]
        public string SubComment { get; set; }
        [Column("BBNI_SKEY")]
        public int? BbniSkey { get; set; }
        [Column("USI_IND")]
        [StringLength(1)]
        public string UsiInd { get; set; }
        [Column("NUMBER_OF_LOCATIONS")]
        public int? NumberOfLocations { get; set; }
        [Column("PRIOR_STATUS_CODE")]
        [StringLength(20)]
        public string PriorStatusCode { get; set; }
        [Column("SIC_SKEY")]
        public int? SicSkey { get; set; }
        [Column("TranUISDailySkey")]
        public int? TranUisdailySkey { get; set; }
        [Column("REBIND_POLICY_NUMBER", TypeName = "numeric(6, 0)")]
        public decimal? RebindPolicyNumber { get; set; }
        [Column("CancelRewrite_Endorsement_Skey")]
        public int? CancelRewriteEndorsementSkey { get; set; }
        public bool? IsCancelRewrite { get; set; }
        public bool? PremiumTrackingChanged { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModDate { get; set; }
        public int? ModifiedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? IssuedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? BoundDate { get; set; }
        [Column("SUB_COMPANY_TYPE")]
        public int? SubCompanyType { get; set; }
        [StringLength(60)]
        public string ClientSubmissionId { get; set; }
        [StringLength(121)]
        public string LocationAppointedBrokerName { get; set; }
        public bool ProblemWatchFlag { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AuditDate { get; set; }
        public int? DecInsuredAddressKey { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime VersionTimestamp { get; set; }
        public int? CompanionPolicyGroupNbr { get; set; }
        public int? ProgramKey { get; set; }
        public int? BusinessClassKey { get; set; }
        public bool NonRenewalNoticeSent { get; set; }
        public bool UseDifferentDecPageDates { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NewDecEffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NewDecExpirationDate { get; set; }
        [StringLength(2)]
        public string HomeState { get; set; }
        public int? AltStructBusTypeId { get; set; }
        [Column("SICSubCodesXRefId")]
        public int? SicsubCodesXrefId { get; set; }
        public bool HasMidtermBrokerChange { get; set; }
        [Column("IsUnderNDA")]
        public bool? IsUnderNda { get; set; }
        public bool UseDifferentInsuredInfo { get; set; }
        public int? AccountContactId { get; set; }

        [ForeignKey(nameof(AccountContactId))]
        [InverseProperty(nameof(People.SubmissionAccountContact))]
        public virtual People AccountContact { get; set; }
        [ForeignKey(nameof(CompanyRecordNumber))]
        [InverseProperty(nameof(InsuranceCompanies.Submission))]
        public virtual InsuranceCompanies CompanyRecordNumberNavigation { get; set; }
        [ForeignKey(nameof(EmpRecordNumber))]
        [InverseProperty(nameof(Employee.Submission))]
        public virtual Employee EmpRecordNumberNavigation { get; set; }
        [ForeignKey(nameof(LocationSkey))]
        [InverseProperty(nameof(Location.Submission))]
        public virtual Location LocationSkeyNavigation { get; set; }
        [ForeignKey(nameof(PeopleSkey))]
        [InverseProperty(nameof(People.SubmissionPeopleSkeyNavigation))]
        public virtual People PeopleSkeyNavigation { get; set; }
        [ForeignKey(nameof(SubCompanyType))]
        [InverseProperty(nameof(ReferenceType.Submission))]
        public virtual ReferenceType SubCompanyTypeNavigation { get; set; }
        [ForeignKey(nameof(SubPolicySymbol))]
        [InverseProperty(nameof(PolicySymbol.Submission))]
        public virtual PolicySymbol SubPolicySymbolNavigation { get; set; }
        [InverseProperty("SubRecordNumberNavigation")]
        public virtual ICollection<QuoteBinder> QuoteBinder { get; set; }
        [InverseProperty("SubRecordNumberNavigation")]
        public virtual ICollection<TaskEntity> Task { get; set; }
    }
}
