using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Interfaces;
public interface IProjectTaskMappings
{
    ProjectTaskDto MapProjectTaskBlModelToProjectTaskDto(ProjectTaskModel projectTask);
    ProjectTaskModel MapProjectTaskDtoToProjectTaskBlModel(ProjectTaskDto projectTaskDto);
    ICollection<ProjectTaskModel> MapProjectTaskDtoCollectionToProjectTaskModelCollection(ICollection<ProjectTaskDto> projectDtoCollection);
}
