using BusinessLogic.Models;

namespace BusinessLogic.Interfaces;
public interface IProjectTaskService
{
    Task<ProjectTaskModel> AddProjectTaskAsync(ProjectTaskModel projectTask);
    Task<IEnumerable<ProjectTaskModel>> GetProjectTasksAsync();
    Task<ProjectTaskModel> GetProjectTaskAsync(int projectTaskId);
    Task<ProjectTaskModel> UpdateProjectTaskAsync(int projectTaskId, ProjectTaskModel projectTask);
    Task DeleteProjectTaskAsync(int projectTaskId);
}

