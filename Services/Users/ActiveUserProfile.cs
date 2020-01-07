using AutoMapper;
using ErnestoWebApi.Controllers.Models;
using Shared.TaskApi.Data.Entities;

namespace ErnestoWebApi.Services.Users
{
    public class ActiveUserProfile : Profile 
    {
        public ActiveUserProfile()
        {
            CreateMap<Employee, ActiveUser>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EmpRecordNumber))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.EmpFirstName} {src.EmpLastName}"))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.EmpRecordNumber))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.EmpDepartment.DepartmentDescription))
                .ForMember(dest => dest.ProfitCenterId, opt => opt.MapFrom(src => src.EmpRecordNumber))
                .ForMember(dest => dest.CanEditTask, opt => opt.MapFrom(src => true)) // TODO retrieve a role and set this value
                .ForMember(dest => dest.IsAppAdmin, opt => opt.MapFrom(src => false)) // TODO retrieve a role and set this value
                ;
            CreateMap<ActiveUser, UserDetailsModel>();
        }
    }
}