using System.Linq;
using AutoMapper;
using Shared.TaskApi.Data.Entities;

namespace Shared.TaskApi.Models
{
    public class StepDetailsModelProfile : Profile
    {
        public StepDetailsModelProfile()
        {
            CreateMap<TaskSubType, StepDetailsModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskSubTypeId))
                .ForMember(dest => dest.Count, opt => opt.MapFrom(src => src.Task.Count(inst => inst.CompleteDate == null)))
                ;
        }
    }
}