using System.Linq;
using AutoMapper;
using Shared.TaskApi.Data.Entities;

namespace Shared.TaskApi.Models
{
    public class StackDetailsModelProfile : Profile
    {
        public StackDetailsModelProfile()
        {
            CreateMap<TaskType, StackDetailsModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskTypeId))
                .ForMember(dest => dest.ProfitCenterId, opt => opt.MapFrom(src => src.ProfitCenterKey))
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(src => src.TaskSubType))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Task.Count(inst => inst.CompleteDate == null)))
                ;
        }
    }
}