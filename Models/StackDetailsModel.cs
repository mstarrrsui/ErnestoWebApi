using System.Collections.Generic;

namespace ErnestoWebApi.Models
{
    public class StackDetailsModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProfitCenterId { get; set; }
        public int Count { get; set; }
        public IList<StepDetailsModel> Steps { get; set; }
    }
}