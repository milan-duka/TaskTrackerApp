using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Mappings;

public class TaskTrackerProfile : Profile
{
    public TaskTrackerProfile()
    {
        CreateMap<ProjectModel, ProjectDto>().ReverseMap();
            //.ForMember(dest => dest.ProjectTasks, act => act.Ignore());
        CreateMap<ProjectTaskModel, ProjectTaskDto>().ReverseMap()
            .ForMember(dest => dest.Project, act => act.Ignore());
        //.ForSourceMember(source => source.Project, o => o.DoNotValidate());
    }
}

