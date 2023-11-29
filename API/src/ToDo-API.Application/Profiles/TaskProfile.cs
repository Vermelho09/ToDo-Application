using AutoMapper;
using Todo_API.Domain.Inputs;
using ToDo_API.Domain;
using ToDo_API.Domain.DTO;

namespace ToDo_API.Application.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            //CreateMap<ToDoTaskDTO, ToDoTaskEntity>().ReverseMap()
            //    .ForMember(dest => dest.ToDoTaskId, opt => opt.MapFrom(src => src.ToDoTaskId))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.PriorityId, opt => opt.MapFrom(src => src.PriorityId))
            //    .ForMember(dest => dest.TargetDate, opt => opt.MapFrom(src => src.TargetDate))
            //    .ForMember(dest => dest.CompletedDate, opt => opt.MapFrom(src => src.CompletedDate));

            CreateMap<ToDoTaskDTO, ToDoTaskEntity>().ReverseMap();

            CreateMap<CreateToDoTaskInput, ToDoTaskEntity>();
        }
    }
}
