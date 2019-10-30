using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("DEPARTMENTS")]
    public partial class Departments
    {
        [Key]
        [Column("DEPARTMENT_NUMBER")]
        public int DepartmentNumber { get; set; }
        [Column("DEPARTMENT_DESCRIPTION")]
        [StringLength(60)]
        public string DepartmentDescription { get; set; }
        [Column("UNDERWRITING_FLAG")]
        [StringLength(1)]
        public string UnderwritingFlag { get; set; }
        [Column("CLAIMS_FLAG")]
        [StringLength(1)]
        public string ClaimsFlag { get; set; }
        [Column("PROGRAM_FLAG")]
        [StringLength(1)]
        public string ProgramFlag { get; set; }
        [Column("DEDUCTIBLE_BILLING_FLAG")]
        public int? DeductibleBillingFlag { get; set; }
        [Column("PROFITCENTERKEY")]
        public int? Profitcenterkey { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public int? AccountingGroupTypeKey { get; set; }
        public bool? CreateNewSubmissions { get; set; }
        public bool SystemManagesFees { get; set; }
        public bool ExternalAccessToForms { get; set; }
        [StringLength(10)]
        public string ShortDescription { get; set; }
    }
}
