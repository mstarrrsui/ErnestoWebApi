using System;

namespace ErnestoWebApi.Controllers.Models
{
    public class UserDetailsModel
    {
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Token { get; set; }
        public DateTime TokenTtl { get; set; }
    }
}