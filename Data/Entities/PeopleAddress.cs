using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("PEOPLE_ADDRESS")]
    public partial class PeopleAddress
    {
        [Key]
        [Column("PEOPLE_SKEY")]
        public int PeopleSkey { get; set; }
        [Key]
        [Column("ADDRESS_TYPE")]
        public int AddressType { get; set; }
        [Column("ADDRESS_LINE_1")]
        [StringLength(60)]
        public string AddressLine1 { get; set; }
        [Column("ADDRESS_LINE_2")]
        [StringLength(60)]
        public string AddressLine2 { get; set; }
        [Column("CITY")]
        [StringLength(30)]
        public string City { get; set; }
        [Column("STATE")]
        [StringLength(2)]
        public string State { get; set; }
        [Column("ZIP_CODE")]
        [StringLength(10)]
        public string ZipCode { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }

        [ForeignKey(nameof(AddressType))]
        [InverseProperty(nameof(ReferenceType.PeopleAddress))]
        public virtual ReferenceType AddressTypeNavigation { get; set; }
        [ForeignKey(nameof(PeopleSkey))]
        [InverseProperty(nameof(People.PeopleAddress))]
        public virtual People PeopleSkeyNavigation { get; set; }
    }
}
