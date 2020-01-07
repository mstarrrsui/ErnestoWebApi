namespace ErnestoWebApi.Services.Users
{
    public class ActiveUser 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int ProfitCenterId { get; set; }
        public bool CanEditTask { get; set; }
        public bool IsAppAdmin { get; set; }
    }
}