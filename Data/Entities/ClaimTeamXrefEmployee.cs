using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class ClaimTeamXrefEmployee
    {
        [Key]
        [Column("CTXE_Key")]
        public int CtxeKey { get; set; }
        [Column("EMP_RECORD_NUMBER")]
        public int? EmpRecordNumber { get; set; }
        [Column("CT_Key")]
        public int? CtKey { get; set; }
        public bool? IsLeader { get; set; }
    }
}
