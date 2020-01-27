using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("QUOTE_BINDER")]
    public partial class QuoteBinder
    {
        [Key]
        [Column("SUB_RECORD_NUMBER")]
        public int SubRecordNumber { get; set; }
        [Key]
        [Column("QB_SEQUENCE_NO")]
        public int QbSequenceNo { get; set; }
        [Column("COMPANY_RECORD_NUMBER")]
        public int? CompanyRecordNumber { get; set; }
        [Column("QB_LIMIT", TypeName = "numeric(12, 0)")]
        public decimal? QbLimit { get; set; }
        [Column("Y2K_COMMENT_SKEY")]
        public int? Y2kCommentSkey { get; set; }
        [Column("QB_UNDERLYING_LIMIT", TypeName = "numeric(12, 0)")]
        public decimal? QbUnderlyingLimit { get; set; }
        [Column("QB_PART_OF", TypeName = "numeric(12, 0)")]
        public decimal? QbPartOf { get; set; }
        [Column("QB_FLAT_CHARGE", TypeName = "money")]
        public decimal? QbFlatCharge { get; set; }
        [Column("QB_MINIMUM_PREMIUM", TypeName = "money")]
        public decimal? QbMinimumPremium { get; set; }
        [Column("QB_ADJUSTABLE_RATE_OF", TypeName = "numeric(19, 3)")]
        public decimal? QbAdjustableRateOf { get; set; }
        [Column("QB_ADJUSTABLE_PER")]
        public string QbAdjustablePer { get; set; }
        [Column("QB_GROSS_PREMIUM", TypeName = "money")]
        public decimal? QbGrossPremium { get; set; }
        [Column("QB_COMMISSION_AMOUNT", TypeName = "money")]
        public decimal? QbCommissionAmount { get; set; }
        [Column("QB_COMMISSION_PERCENT", TypeName = "numeric(5, 2)")]
        public decimal? QbCommissionPercent { get; set; }
        [Column("QB_NET_AMOUNT_DUE", TypeName = "money")]
        public decimal? QbNetAmountDue { get; set; }
        [Column("QB_REVISION_NUMBER")]
        public int? QbRevisionNumber { get; set; }
        [Column("QB_DAYS_VALID")]
        public int? QbDaysValid { get; set; }
        [Column("QB_MINIMUM_EARNED_PREMIUM", TypeName = "money")]
        public decimal? QbMinimumEarnedPremium { get; set; }
        [Column("QB_MINIMUM_EARNED_PREMIUM_PCT", TypeName = "numeric(5, 2)")]
        public decimal? QbMinimumEarnedPremiumPct { get; set; }
        [Column("QB_LEAD_COMPANY_NAME")]
        [StringLength(60)]
        public string QbLeadCompanyName { get; set; }
        [Column("QB_PRINT_TBD_FLAG")]
        [StringLength(1)]
        public string QbPrintTbdFlag { get; set; }
        [Column("QB_PRINT_DATE", TypeName = "datetime")]
        public DateTime? QbPrintDate { get; set; }
        [Column("QB_PURGE_DATE", TypeName = "datetime")]
        public DateTime? QbPurgeDate { get; set; }
        [Column("QB_PURGE_FLAG")]
        [StringLength(1)]
        public string QbPurgeFlag { get; set; }
        [Column("QB_CREATION_DATE", TypeName = "datetime")]
        public DateTime? QbCreationDate { get; set; }
        [Column("QB_INVOICE_DAYS")]
        public int? QbInvoiceDays { get; set; }
        [Column("QB_REMARKS")]
        public string QbRemarks { get; set; }
        [Column("QB_ADDITIONAL_INFO")]
        public string QbAdditionalInfo { get; set; }
        [Column("QB_EXCESS_COMMENT")]
        public string QbExcessComment { get; set; }
        [Column("QB_PREMIUM_COMMENT")]
        public string QbPremiumComment { get; set; }
        [Column("QB_REVISION_COMMENT")]
        public string QbRevisionComment { get; set; }
        [Column("QB_LIMIT_COMMENT")]
        public string QbLimitComment { get; set; }
        [Column("QB_COVERAGE_COMMENT")]
        public string QbCoverageComment { get; set; }
        [Column("QB_DEDUCTIBLE_COMMENT")]
        public string QbDeductibleComment { get; set; }
        [Column("QB_OTHER_COMMENT")]
        public string QbOtherComment { get; set; }
        [Column("UNDERLYING_FORM_TYPE")]
        [StringLength(1)]
        public string UnderlyingFormType { get; set; }
        [Column("QB_NAME")]
        [StringLength(60)]
        public string QbName { get; set; }
        [Column("QB_TYPE")]
        [StringLength(60)]
        public string QbType { get; set; }
        [Column("UNDERLYING_RETROACTIVE_DATE", TypeName = "datetime")]
        public DateTime? UnderlyingRetroactiveDate { get; set; }
        [Required]
        [Column("QB_STATUS")]
        [StringLength(1)]
        public string QbStatus { get; set; }
        [Column("UNDERLYING_FORM_NAME")]
        [StringLength(255)]
        public string UnderlyingFormName { get; set; }
        [Column("RSUI_FORM_NAME")]
        [StringLength(255)]
        public string RsuiFormName { get; set; }
        [Column("INSTALL_FLAG")]
        [StringLength(1)]
        public string InstallFlag { get; set; }
        [Column("UNDERLYINGSKEY")]
        public int? Underlyingskey { get; set; }
        [Column("QB_TERRORISM_PREMIUM", TypeName = "money")]
        public decimal? QbTerrorismPremium { get; set; }
        [Column("RejectTRIA")]
        [StringLength(1)]
        public string RejectTria { get; set; }
        [Required]
        [Column("NYFreeTradeZone")]
        public bool? NyfreeTradeZone { get; set; }
        [Column("AMBestRatingKey")]
        public int? AmbestRatingKey { get; set; }
        public int? AssumedFromCompanySkey { get; set; }
        [Column("SLLicenseKey")]
        public int? SllicenseKey { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? DepositPremium { get; set; }
        [StringLength(200)]
        public string DecPagePath { get; set; }
        [StringLength(60)]
        public string DecPageFileName { get; set; }
        [StringLength(200)]
        public string FormSchedulePath { get; set; }
        [StringLength(60)]
        public string FormScheduleFileName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime VersionTimestamp { get; set; }
        [Column("RejectUIM")]
        [StringLength(1)]
        public string RejectUim { get; set; }
        [Required]
        public bool? Coastal { get; set; }
        [Column(TypeName = "numeric(5, 2)")]
        public decimal? MinEarnedPremiumPctWind { get; set; }
        [Column(TypeName = "numeric(5, 2)")]
        public decimal? MinEarnedPremiumPctNonWind { get; set; }
        [Column("NYFTZClassCodeKey")]
        public int? NyftzclassCodeKey { get; set; }
        [Required]
        public bool? IsIndication { get; set; }
        [Required]
        public bool? IsExcess { get; set; }
        [StringLength(200)]
        public string DecPageTwoPath { get; set; }
        [StringLength(200)]
        public string DecPageTwoFilename { get; set; }
        [StringLength(200)]
        public string ImportantNoticePath { get; set; }
        [StringLength(200)]
        public string ImportantNoticeFilename { get; set; }
        public int? TriaFormsTypeId { get; set; }
        public bool IsQuotaShare { get; set; }
        public bool UseUnderlyingLayerMap { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CommissionIncomePercent { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? CommissionIncomeAmount { get; set; }
        [Column("SAndPRatingID")]
        public int? SandPratingId { get; set; }

        [ForeignKey(nameof(AssumedFromCompanySkey))]
        [InverseProperty(nameof(Company.QuoteBinder))]
        public virtual Company AssumedFromCompanySkeyNavigation { get; set; }
        [ForeignKey(nameof(CompanyRecordNumber))]
        [InverseProperty(nameof(InsuranceCompanies.QuoteBinder))]
        public virtual InsuranceCompanies CompanyRecordNumberNavigation { get; set; }
        [ForeignKey(nameof(SubRecordNumber))]
        [InverseProperty(nameof(Submission.QuoteBinder))]
        public virtual Submission SubRecordNumberNavigation { get; set; }
    }
}
