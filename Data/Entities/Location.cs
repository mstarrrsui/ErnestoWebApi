using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("LOCATION")]
    public partial class Location
    {
        public Location()
        {
            LocationXref = new HashSet<LocationXref>();
            Submission = new HashSet<Submission>();
        }

        [Key]
        [Column("LOCATION_SKEY")]
        public int LocationSkey { get; set; }
        [Column("COMPANY_SKEY")]
        public int? CompanySkey { get; set; }
        [Column("INTERNAL_NAME")]
        [StringLength(60)]
        public string InternalName { get; set; }
        [Column("EFFECTIVE_DATE", TypeName = "datetime")]
        public DateTime? EffectiveDate { get; set; }
        [Column("EXPIRATION_DATE", TypeName = "datetime")]
        public DateTime? ExpirationDate { get; set; }
        [Column("SPEED_DIAL_EAST", TypeName = "numeric(3, 0)")]
        public decimal? SpeedDialEast { get; set; }
        [Column("SPEED_DIAL_WEST", TypeName = "numeric(3, 0)")]
        public decimal? SpeedDialWest { get; set; }
        [Column("ROYAL_NUMBER")]
        [StringLength(5)]
        public string RoyalNumber { get; set; }
        [Column("ACTIVE_CODE")]
        [StringLength(1)]
        public string ActiveCode { get; set; }
        [Column("TREATY_FLAG")]
        [StringLength(1)]
        public string TreatyFlag { get; set; }
        [Column("OLD_COMPANY_TYPE")]
        [StringLength(60)]
        public string OldCompanyType { get; set; }
        [Column("OLD_COMPANY_NUMBER")]
        public int? OldCompanyNumber { get; set; }
        [Column("OLD_OFFICE_LOCATION")]
        public int? OldOfficeLocation { get; set; }
        [Column("OLD_RSA_LOCATION")]
        public int? OldRsaLocation { get; set; }
        [Column("LIBRARY_VERSION")]
        [StringLength(50)]
        public string LibraryVersion { get; set; }
        [Column("DOCUCORP_VERSION")]
        [StringLength(50)]
        public string DocucorpVersion { get; set; }
        [Column("HAS_MDR")]
        public bool HasMdr { get; set; }
        [Column("REQUIRES_FULL_INSTALL")]
        public bool RequiresFullInstall { get; set; }
        public int? LocationNumber { get; set; }
        [Column("AgencyManagementSystemID")]
        public int? AgencyManagementSystemId { get; set; }
        [Column("MGAIdentifier")]
        public Guid? Mgaidentifier { get; set; }
        [Column("CanAccessBAPI")]
        public bool CanAccessBapi { get; set; }
        [Column("AdmittedLiquorYN")]
        [StringLength(1)]
        public string AdmittedLiquorYn { get; set; }
        [StringLength(250)]
        public string SurplusStampSignatureText { get; set; }
        public bool IsRetailAgencyOnDec { get; set; }
        [Column("IsELANY")]
        public bool IsElany { get; set; }
        [Column("Audit_Email_Address")]
        [StringLength(60)]
        public string AuditEmailAddress { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(CompanySkey))]
        [InverseProperty(nameof(Company.Location))]
        public virtual Company CompanySkeyNavigation { get; set; }
        [InverseProperty("LocationSkeyNavigation")]
        public virtual ICollection<LocationXref> LocationXref { get; set; }
        [InverseProperty("LocationSkeyNavigation")]
        public virtual ICollection<Submission> Submission { get; set; }
    }
}
