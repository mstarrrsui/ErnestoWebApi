using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("claims")]
    public partial class Claims
    {
        public Claims()
        {
            InverseMasterClaimKeyNavigation = new HashSet<Claims>();
            Task = new HashSet<TaskEntity>();
        }

        [Key]
        public int ClaimKey { get; set; }
        [StringLength(7)]
        public string ClaimNumber { get; set; }
        [StringLength(3)]
        public string ClaimOffice { get; set; }
        public int? ClaimProfessional { get; set; }
        [Column("ClaimTA")]
        public int? ClaimTa { get; set; }
        [StringLength(1)]
        public string ClaimStatus { get; set; }
        [StringLength(55)]
        public string CrossRefNumber { get; set; }
        public int? CatastropheKey { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateofLoss { get; set; }
        [StringLength(60)]
        public string AccidentAddress1 { get; set; }
        [StringLength(60)]
        public string AccidentAddress2 { get; set; }
        [StringLength(60)]
        public string AccidentCity { get; set; }
        [StringLength(2)]
        public string AccidentState { get; set; }
        [StringLength(10)]
        public string AccidentZip { get; set; }
        [StringLength(200)]
        public string InsuredLocationCode { get; set; }
        [StringLength(2000)]
        public string LongDescription { get; set; }
        public int? ClaimPolicyKey { get; set; }
        [StringLength(50)]
        public string ShortDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateCreated { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal ThirdPartyDeductible { get; set; }
        [StringLength(1)]
        public string Converted { get; set; }
        [Column("AS400ClaimNumber")]
        [StringLength(10)]
        public string As400claimNumber { get; set; }
        [Column(TypeName = "numeric(4, 0)")]
        public decimal? LastProofNoticeNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateModified { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateReported { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateClosed { get; set; }
        public int? ClaimSubtypeKey { get; set; }
        [Column("LOCALC_RECORD_NO")]
        public int? LocalcRecordNo { get; set; }
        [Required]
        public bool? IsFlaggedForFraud { get; set; }
        public bool? ExcludeFromCatTreaty { get; set; }
        public int? SurplusShareOccurrence { get; set; }
        [Required]
        public bool? SplitBills { get; set; }
        [Required]
        public bool? NoDeductible { get; set; }
        [Required]
        public bool? NoPayment { get; set; }
        [Required]
        public bool? ReportToReinsurer { get; set; }
        [Required]
        public bool? Master { get; set; }
        [Required]
        public bool? Companion { get; set; }
        public int CrossOverTypeKey { get; set; }
        [Required]
        public bool? NonScanableImageStored { get; set; }
        [Required]
        public bool? ProRateExpenses { get; set; }
        [Required]
        [Column("ISOReportComplete")]
        public bool? IsoreportComplete { get; set; }
        [Required]
        public bool? RecordOnly { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ImageRightStartDate { get; set; }
        public int? RatingClassCodeKey { get; set; }
        public int? InlandMarineClassKey { get; set; }
        public int? OccupancyCodeKey { get; set; }
        [Column("ClaimsDORetentionTypeKey")]
        public int? ClaimsDoretentionTypeKey { get; set; }
        [Column("ClaimsDORetentionAmount", TypeName = "numeric(18, 2)")]
        public decimal? ClaimsDoretentionAmount { get; set; }
        [Column("ExcludeFromDOAggregate")]
        public bool ExcludeFromDoaggregate { get; set; }
        [Column("ClaimsTPAKey")]
        public int? ClaimsTpakey { get; set; }
        public bool ExpenseWithinLimits { get; set; }
        public bool IsBadFaith { get; set; }
        [Column("ClaimsDOCompanyTypeKey")]
        public int? ClaimsDocompanyTypeKey { get; set; }
        public int? MasterClaimKey { get; set; }
        public bool DeductibleIndemnityOnly { get; set; }
        public int? AdditionalInsuredTypeKey { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? RetentionAmount { get; set; }
        [StringLength(200)]
        public string InvoiceNotes { get; set; }
        public bool AllowSplitInvoice { get; set; }
        public bool HasPhysicalComponent { get; set; }
        [Column("ISOReportNumber")]
        [StringLength(25)]
        public string IsoreportNumber { get; set; }
        [Column("ClaimLOBKey")]
        public int? ClaimLobkey { get; set; }
        public int? ClaimSearchDeliveryMethodKey { get; set; }
        public bool ClaimSearchEligible { get; set; }
        public bool PerRiskTreatyApplies { get; set; }
        public bool IsSubrogation { get; set; }
        [Column("PotentialEEOCCharge")]
        public bool? PotentialEeoccharge { get; set; }
        [Column("TPAMonitorKey")]
        public int? TpamonitorKey { get; set; }
        public bool HasConfidentialProvisions { get; set; }
        public int? ClaimsLayerAllocTypeKey { get; set; }
        public bool IsClassAction { get; set; }
        public int? DeductibleRuleKey { get; set; }
        public int? PropertyLocationCodingStatusKey { get; set; }
        [Required]
        [Column("GUID")]
        [StringLength(50)]
        public string Guid { get; set; }
        public int? ModBy { get; set; }

        [ForeignKey(nameof(MasterClaimKey))]
        [InverseProperty(nameof(Claims.InverseMasterClaimKeyNavigation))]
        public virtual Claims MasterClaimKeyNavigation { get; set; }
        [ForeignKey(nameof(ModBy))]
        [InverseProperty(nameof(Employee.ClaimsModByNavigation))]
        public virtual Employee ModByNavigation { get; set; }
        [ForeignKey(nameof(TpamonitorKey))]
        [InverseProperty(nameof(Employee.ClaimsTpamonitorKeyNavigation))]
        public virtual Employee TpamonitorKeyNavigation { get; set; }
        [InverseProperty(nameof(Claims.MasterClaimKeyNavigation))]
        public virtual ICollection<Claims> InverseMasterClaimKeyNavigation { get; set; }
        [InverseProperty("ClaimKeyNavigation")]
        public virtual ICollection<TaskEntity> Task { get; set; }
    }
}
