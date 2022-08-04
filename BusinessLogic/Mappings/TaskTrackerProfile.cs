using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Mappings;

public class TaskTrackerProfile : Profile
{
    public TaskTrackerProfile()
    {
        CreateMap<ProjectTaskDto, ProjectTaskModel>();
        CreateMap<ProjectDto, ProjectModel>();
    }
}

