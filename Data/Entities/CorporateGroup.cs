using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    [Table("CORPORATE_GROUP")]
    public partial class CorporateGroup
    {
        [Key]
        [Column("CORP_GRP_SKEY")]
        public int CorpGrpSkey { get; set; }
        [Required]
        [Column("NAME")]
        [StringLength(60)]
        public string Name { get; set; }
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
        [Column("CONTACT_NAME")]
        [StringLength(60)]
        public string ContactName { get; set; }
        [Column("CONTACT_TITLE")]
        [StringLength(60)]
        public string ContactTitle { get; set; }
        [Column("PHONE_NUMBER")]
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [Column("FAX_NUMBER")]
        [StringLength(10)]
        public string FaxNumber { get; set; }
        [Column("WEB_PAGE")]
        [StringLength(60)]
        public string WebPage { get; set; }
        [Column("OLD_CORPGROUP_NUMBER")]
        public int? OldCorpgroupNumber { get; set; }
    }
}
