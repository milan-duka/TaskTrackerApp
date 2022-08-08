using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProjectMappings
    {
        ProjectDto MapProjectBlModelToProjectDto(ProjectModel project);
        ProjectModel MapProjectDtoToProjectBlModel(ProjectDto projectDto);
        ProjectWithTasksModel MapProjectDtoWithTasksToProjectBlModelWithTasks(ProjectDto projectDto);
    }
}
