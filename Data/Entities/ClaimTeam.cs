using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class ClaimTeam
    {
        [Key]
        [Column("CT_Key")]
        public int CtKey { get; set; }
        [Column("CT_Descr")]
        [StringLength(50)]
        public string CtDescr { get; set; }
        [Column("CT_Order")]
        public int? CtOrder { get; set; }
        public int? ClaimUnitKey { get; set; }
    }
}
