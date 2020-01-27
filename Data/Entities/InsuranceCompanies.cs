using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("INSURANCE_COMPANIES")]
    public partial class InsuranceCompanies
    {
        public InsuranceCompanies()
        {
            QuoteBinder = new HashSet<QuoteBinder>();
            Submission = new HashSet<Submission>();
        }

        [Key]
        [Column("COMPANY_RECORD_NUMBER")]
        public int CompanyRecordNumber { get; set; }
        [Column("ORG_NUMBER")]
        public int? OrgNumber { get; set; }
        [Column("COMPANY_CODE")]
        [StringLength(2)]
        public string CompanyCode { get; set; }
        [Column("COMPANY_NAME")]
        [StringLength(60)]
        public string CompanyName { get; set; }
        [Column("EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column("EXPIRATION_DATE", TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        [Column("ADMITTED")]
        [StringLength(1)]
        public string Admitted { get; set; }
        [Column("COMPANY_SKEY")]
        public int? CompanySkey { get; set; }
        public int? InsuranceCompanyBankAccountKey { get; set; }
        [Column("AMBestRatingKey")]
        public int? AmbestRatingKey { get; set; }
        [StringLength(255)]
        public string SecondaryDescription { get; set; }
        [Required]
        [Column("CedeToRIC")]
        public bool? CedeToRic { get; set; }
        [StringLength(500)]
        public string DecCompanyDescription { get; set; }
        [Column("SAndPRatingID")]
        public int? SandPratingId { get; set; }

        [ForeignKey(nameof(CompanySkey))]
        [InverseProperty(nameof(Company.InsuranceCompanies))]
        public virtual Company CompanySkeyNavigation { get; set; }
        [InverseProperty("CompanyRecordNumberNavigation")]
        public virtual ICollection<QuoteBinder> QuoteBinder { get; set; }
        [InverseProperty("CompanyRecordNumberNavigation")]
        public virtual ICollection<Submission> Submission { get; set; }
    }
}
