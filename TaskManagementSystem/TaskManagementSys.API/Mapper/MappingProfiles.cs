using AutoMapper;
using TaskManagementSystem.TaskManagementSys.API.Dto;
using TaskManagementSystem.TaskManagementSys.Domain.Entites;

namespace TaskManagementSystem.TaskManagementSys.API.Mapper;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Projects, opt => opt.MapFrom(src => src.Projects));

        CreateMap<UserDTO, User>();

        CreateMap<Project, ProjectDTO>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Taskses));

        CreateMap<ProjectDTO, Project>()
             .ForMember(dest => dest.Taskses, opt => opt.MapFrom(src => src.Tasks));


        CreateMap<Tasks, TaskDTO>();
        CreateMap<TaskDTO, Tasks>();
  

    }
}
