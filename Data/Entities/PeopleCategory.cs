using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("PEOPLE_CATEGORY")]
    public partial class PeopleCategory
    {
        [Key]
        [Column("PEOPLE_SKEY")]
        public int PeopleSkey { get; set; }
        [Key]
        [Column("CATEGORY_SKEY")]
        public int CategorySkey { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(PeopleSkey))]
        [InverseProperty(nameof(People.PeopleCategory))]
        public virtual People PeopleSkeyNavigation { get; set; }
    }
}
