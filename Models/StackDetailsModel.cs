using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Shared.TaskApi.Data.Entities;

namespace ErnestoWebApi.Models
{
    public class StackDetailsModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ProfitCenterId { get; set; }
        public int ShananigansCount { get; set; }
        public IList<StepDetailsModel> Steps { get; set; }
    }
    public class StackDetailsModelProfile : Profile
    {
        public StackDetailsModelProfile()
        {
            CreateMap<TaskType, StackDetailsModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskTypeId))
                .ForMember(dest => dest.ProfitCenterId, opt => opt.MapFrom(src => src.ProfitCenterKey))
                .ForMember(dest => dest.Steps, opt => opt.MapFrom(src => src.TaskSubType))
                .ForMember(dest => dest.ShananigansCount, opt => opt.MapFrom(src => src.Task.Count(inst => inst.CompleteDate == null)))
                ;
        }
    }
}