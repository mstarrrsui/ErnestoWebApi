using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.TaskApi.Data.Entities
{
    public partial class ProfitCenter
    {
        public ProfitCenter()
        {
            TaskType = new HashSet<TaskType>();
        }

        [Key]
        public int ProfitCenterKey { get; set; }
        [StringLength(60)]
        public string ProfitCenterName { get; set; }
        [StringLength(2)]
        public string UltiProCode { get; set; }

        [InverseProperty("ProfitCenterKeyNavigation")]
        public virtual ICollection<TaskType> TaskType { get; set; }
    }
}
