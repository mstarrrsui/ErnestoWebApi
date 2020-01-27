using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("COMPANY")]
    public partial class Company
    {
        public Company()
        {
            InsuranceCompanies = new HashSet<InsuranceCompanies>();
            Location = new HashSet<Location>();
            QuoteBinder = new HashSet<QuoteBinder>();
        }

        [Key]
        [Column("COMPANY_SKEY")]
        public int CompanySkey { get; set; }
        [Column("COMPANY_TYPE")]
        public int CompanyType { get; set; }
        [Column("CORP_GRP_SKEY")]
        public int? CorpGrpSkey { get; set; }
        [Column("NAME")]
        [StringLength(60)]
        public string Name { get; set; }
        [Column("ACTIVE_CODE")]
        [StringLength(1)]
        public string ActiveCode { get; set; }
        [Column("EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column("EXPIRATION_DATE", TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        [Column("REINS_TYPE")]
        public int? ReinsType { get; set; }
        [Column("WEB_PAGE")]
        [StringLength(60)]
        public string WebPage { get; set; }
        [Column("COMMENTS")]
        [StringLength(60)]
        public string Comments { get; set; }
        [Column("OLD_COMPANY_TYPE")]
        [StringLength(60)]
        public string OldCompanyType { get; set; }
        [Column("OLD_COMPANY_NUMBER")]
        public int? OldCompanyNumber { get; set; }
        [Column("PAYMENT_TERMS", TypeName = "numeric(18, 0)")]
        public decimal? PaymentTerms { get; set; }
        [Column("REPORT_DAYS", TypeName = "numeric(18, 0)")]
        public decimal? ReportDays { get; set; }
        [Column("REPORT_MONTH", TypeName = "decimal(5, 1)")]
        public decimal? ReportMonth { get; set; }
        [Column("PAYMENT_DAYS", TypeName = "numeric(18, 0)")]
        public decimal? PaymentDays { get; set; }
        [Column("PAYMENT_MONTH", TypeName = "decimal(5, 1)")]
        public decimal? PaymentMonth { get; set; }
        public bool Org2Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Org2EffectiveDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Org2ExpirationDate { get; set; }
        [Column("FederalTaxID")]
        [StringLength(10)]
        public string FederalTaxId { get; set; }
        [StringLength(2)]
        public string DomicileStateAbbr { get; set; }
        [StringLength(30)]
        public string DomicileCity { get; set; }
        [Column("NAICCompanyCode")]
        [StringLength(5)]
        public string NaiccompanyCode { get; set; }
        [Column("NAICName")]
        [StringLength(80)]
        public string Naicname { get; set; }
        [Column("IsAuthorizedInOK")]
        public bool? IsAuthorizedInOk { get; set; }
        [Column("IsAuthorizedInNH")]
        public bool? IsAuthorizedInNh { get; set; }
        [Column("HOME_DIRECTORY")]
        [StringLength(50)]
        public string HomeDirectory { get; set; }
        [Column("REFINE_LOCATION_NUMBER")]
        public bool RefineLocationNumber { get; set; }
        [Column("ReportAsCompanySKey")]
        public int? ReportAsCompanySkey { get; set; }
        [StringLength(3)]
        public string CompanyPrefix { get; set; }
        public int? NextQuoteNumber { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }

        [InverseProperty("CompanySkeyNavigation")]
        public virtual ICollection<InsuranceCompanies> InsuranceCompanies { get; set; }
        [InverseProperty("CompanySkeyNavigation")]
        public virtual ICollection<Location> Location { get; set; }
        [InverseProperty("AssumedFromCompanySkeyNavigation")]
        public virtual ICollection<QuoteBinder> QuoteBinder { get; set; }
    }
}
