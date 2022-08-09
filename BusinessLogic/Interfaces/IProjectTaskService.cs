using BusinessLogic.Models;

namespace BusinessLogic.Interfaces;
public interface IProjectTaskService
{
    Task<int?> AddProjectTaskAsync(ProjectTaskModel projectTask);
    Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksAsync();
    Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksByProjectIdAsync(int projectId);
    Task<ProjectTaskModel> GetProjectTaskByIdAsync(int projectTaskId);
    Task UpdateProjectTaskAsync(int projectTaskId, ProjectTaskModel projectTask);
    Task DeleteProjectTaskAsync(int projectTaskId);
}

