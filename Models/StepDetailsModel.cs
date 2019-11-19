namespace ErnestoWebApi.Models
{
    public class StepDetailsModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Ordinal { get; set; }
        public int Count { get; set; }
    }
}