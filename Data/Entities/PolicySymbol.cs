using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("POLICY_SYMBOL")]
    public partial class PolicySymbol
    {
        public PolicySymbol()
        {
            Submission = new HashSet<Submission>();
        }

        [Key]
        [Column("SYMBOL_SKEY")]
        public int SymbolSkey { get; set; }
        [Column("ORG_NUMBER")]
        public int? OrgNumber { get; set; }
        [Column("DEPARTMENT_NUMBER")]
        public int? DepartmentNumber { get; set; }
        [Required]
        [Column("POLICY_CODE")]
        [StringLength(5)]
        public string PolicyCode { get; set; }
        [Column("CODE_DESCRIPTION")]
        [StringLength(60)]
        public string CodeDescription { get; set; }
        [Column("UNDERWRITING_FLAG")]
        [StringLength(1)]
        public string UnderwritingFlag { get; set; }
        [Column("CLAIMS_FLAG")]
        [StringLength(1)]
        public string ClaimsFlag { get; set; }
        [Column("ACTIVE_FLAG")]
        [StringLength(1)]
        public string ActiveFlag { get; set; }

        [ForeignKey(nameof(DepartmentNumber))]
        [InverseProperty(nameof(Departments.PolicySymbol))]
        public virtual Departments DepartmentNumberNavigation { get; set; }
        [InverseProperty("SubPolicySymbolNavigation")]
        public virtual ICollection<Submission> Submission { get; set; }
    }
}
