using AutoMapper;
using Shared.TaskApi.Data.Entities;

namespace ErnestoWebApi.Controllers.Models
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