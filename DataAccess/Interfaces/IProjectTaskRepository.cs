using DataAccess.Models;

namespace DataAccess.Interfaces;
public interface IProjectTaskRepository
{
    Task AddProjectTaskAsync(ProjectTaskDto projectTask);
    Task<IEnumerable<ProjectTaskDto>> GetAllProjectTasksAsync();
    Task<IEnumerable<ProjectTaskDto>> GetAllProjectTasksByProjectIdAsync(int projectId);
    Task<ProjectTaskDto> GetProjectTaskByIdAsync(int projectTaskId);
    Task UpdateProjectTaskAsync(ProjectTaskDto projectTask);
    Task DeleteProjectTaskAsync(ProjectTaskDto projectTask);
    Task<bool> ProjectTaskExistsAsync(int projectTaskId);
}

