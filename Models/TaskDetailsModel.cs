namespace Shared.TaskApi.Models
{
    public class TaskDetailsModel
    {
        public int Id { get; set; }
        public int FlowId { get; set; }
        public int StepId { get; set; }
        public string Note { get; set; }
    }
}