using BusinessLogic.Models;

namespace BusinessLogic.Interfaces;
public interface IProjectTaskService
{
    Task<ProjectTaskModel> AddProjectTaskAsync(ProjectTaskModel projectTask);
    Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksAsync();
    Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksByProjectIdAsync(int projectId);
    Task<ProjectTaskModel> GetProjectTaskByIdAsync(int projectTaskId);
    Task<ProjectTaskModel> UpdateProjectTaskAsync(int projectTaskId, ProjectTaskModel projectTask);
    Task DeleteProjectTaskAsync(int projectTaskId);
}

