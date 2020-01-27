using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("BRANCHES")]
    public partial class Branches
    {
        [Key]
        [Column("BRANCH_NUMBER")]
        public int BranchNumber { get; set; }
        [Column("BRANCH_DESCRIPTION")]
        [StringLength(60)]
        public string BranchDescription { get; set; }
        [Required]
        public bool? IsActive { get; set; }
    }
}
