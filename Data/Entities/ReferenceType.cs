using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("REFERENCE_TYPE")]
    public partial class ReferenceType
    {
        public ReferenceType()
        {
            People = new HashSet<People>();
            PeopleAddress = new HashSet<PeopleAddress>();
            PeoplePhone = new HashSet<PeoplePhone>();
            Submission = new HashSet<Submission>();
        }

        [Key]
        [Column("TYPE_SKEY")]
        public int TypeSkey { get; set; }
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
        [Required]
        [Column("LOCKED_FLAG")]
        [StringLength(1)]
        public string LockedFlag { get; set; }
        [Column("OLD_TYPE")]
        [StringLength(60)]
        public string OldType { get; set; }

        [ForeignKey(nameof(CategorySkey))]
        [InverseProperty(nameof(ReferenceCategory.ReferenceType))]
        public virtual ReferenceCategory CategorySkeyNavigation { get; set; }
        [InverseProperty("PeopleTypeNavigation")]
        public virtual ICollection<People> People { get; set; }
        [InverseProperty("AddressTypeNavigation")]
        public virtual ICollection<PeopleAddress> PeopleAddress { get; set; }
        [InverseProperty("PhoneTypeNavigation")]
        public virtual ICollection<PeoplePhone> PeoplePhone { get; set; }
        [InverseProperty("SubCompanyTypeNavigation")]
        public virtual ICollection<Submission> Submission { get; set; }
    }
}
