using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("LOCATION_XREF")]
    public partial class LocationXref
    {
        public LocationXref()
        {
            PeopleLocationXref = new HashSet<PeopleLocationXref>();
        }

        [Key]
        [Column("LOCATION_XREF_SKEY")]
        public int LocationXrefSkey { get; set; }
        [Column("LOCATION_SKEY")]
        public int? LocationSkey { get; set; }
        [Column("DEPARTMENT_NUMBER")]
        public int? DepartmentNumber { get; set; }
        [Column("BRANCH_NUMBER")]
        public int? BranchNumber { get; set; }
        [Column("ACTIVE_CODE")]
        [StringLength(1)]
        public string ActiveCode { get; set; }
        [Column("COMM_PCT_FIXED", TypeName = "numeric(5, 2)")]
        public decimal? CommPctFixed { get; set; }
        [Column("COMM_PCT_OVERRIDE", TypeName = "numeric(5, 2)")]
        public decimal? CommPctOverride { get; set; }
        [Column("OLD_COMPANY_TYPE")]
        [StringLength(60)]
        public string OldCompanyType { get; set; }
        [Column("OLD_COMPANY_NUMBER")]
        public int? OldCompanyNumber { get; set; }
        [Column("OLD_OFFICE_LOCATION")]
        public int? OldOfficeLocation { get; set; }

        [ForeignKey(nameof(LocationSkey))]
        [InverseProperty(nameof(Location.LocationXref))]
        public virtual Location LocationSkeyNavigation { get; set; }
        [InverseProperty("LocationXrefSkeyNavigation")]
        public virtual ICollection<PeopleLocationXref> PeopleLocationXref { get; set; }
    }
}
