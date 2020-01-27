using System;

namespace Shared.TaskApi.Controllers.Models
{
    public class UserDetailsModel
    {
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Token { get; set; }
        public DateTime TokenTtl { get; set; }
    }
}