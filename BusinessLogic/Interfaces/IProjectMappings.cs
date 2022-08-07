using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProjectMappings
    {
        ProjectDto MapProjectBlModelToProjectDto(ProjectModel project);
        ProjectModel MapProjectDtoToProjectBlModel(ProjectDto projectDto);
        //ProjectModel MapProjectDtoWithTasksToProjectBlModelWithTasks(ProjectDto projectDto);
    }
}
