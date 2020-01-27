using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("PEOPLE_LOCATION_XREF")]
    public partial class PeopleLocationXref
    {
        [Key]
        [Column("PEOPLE_SKEY")]
        public int PeopleSkey { get; set; }
        [Key]
        [Column("LOCATION_XREF_SKEY")]
        public int LocationXrefSkey { get; set; }
        [Column("ACTIVE_CODE")]
        [StringLength(1)]
        public string ActiveCode { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(LocationXrefSkey))]
        [InverseProperty(nameof(LocationXref.PeopleLocationXref))]
        public virtual LocationXref LocationXrefSkeyNavigation { get; set; }
        [ForeignKey(nameof(PeopleSkey))]
        [InverseProperty(nameof(People.PeopleLocationXref))]
        public virtual People PeopleSkeyNavigation { get; set; }
    }
}
