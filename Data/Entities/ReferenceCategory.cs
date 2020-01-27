using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("REFERENCE_CATEGORY")]
    public partial class ReferenceCategory
    {
        public ReferenceCategory()
        {
            ReferenceType = new HashSet<ReferenceType>();
        }

        [Key]
        [Column("CATEGORY_SKEY")]
        public int CategorySkey { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        [StringLength(60)]
        public string Description { get; set; }
        [Required]
        [Column("ACTIVE_FLAG")]
        [StringLength(1)]
        public string ActiveFlag { get; set; }

        [InverseProperty("CategorySkeyNavigation")]
        public virtual ICollection<ReferenceType> ReferenceType { get; set; }
    }
}
