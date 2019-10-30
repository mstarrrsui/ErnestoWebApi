using System.Linq;
using AutoMapper;
using Shared.TaskApi.Data.Entities;

namespace ErnestoWebApi.Models
{
    public class StepDetailsModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? Ordinal { get; set; }
        public int ShananigansCount { get; set; }
    }
    public class StepDetailsModelProfile : Profile
    {
        public StepDetailsModelProfile()
        {
            CreateMap<TaskSubType, StepDetailsModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskSubTypeId))
                .ForMember(dest => dest.ShananigansCount, opt => opt.MapFrom(src => src.Task.Count(inst => inst.CompleteDate == null)))
                ;
        }
    }
}