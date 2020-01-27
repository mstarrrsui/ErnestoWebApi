using AutoMapper;
using Shared.TaskApi.Data.Entities;

namespace Shared.TaskApi.Controllers.Models
{
    public class UserDetailsModelProfile : Profile
    {
        public UserDetailsModelProfile()
        {
            CreateMap<Employee, UserDetailsModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.EmpFirstName} {src.EmpLastName}"))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.EmpDepartmentNumber));
        }
    }
}