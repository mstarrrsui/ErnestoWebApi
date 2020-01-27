using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("PEOPLE_PHONE")]
    public partial class PeoplePhone
    {
        [Key]
        [Column("PEOPLE_SKEY")]
        public int PeopleSkey { get; set; }
        [Key]
        [Column("PHONE_TYPE")]
        public int PhoneType { get; set; }
        [Required]
        [Column("PHONE_NUMBER")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(PeopleSkey))]
        [InverseProperty(nameof(People.PeoplePhone))]
        public virtual People PeopleSkeyNavigation { get; set; }
        [ForeignKey(nameof(PhoneType))]
        [InverseProperty(nameof(ReferenceType.PeoplePhone))]
        public virtual ReferenceType PhoneTypeNavigation { get; set; }
    }
}
