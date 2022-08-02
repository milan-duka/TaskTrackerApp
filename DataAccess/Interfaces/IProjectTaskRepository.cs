using DataAccess.Models;

namespace DataAccess.Interfaces;
public interface IProjectTaskRepository
{
    Task<ProjectTaskDto> AddProjectTaskAsync(ProjectTaskDto projectTask);
    Task<IEnumerable<ProjectTaskDto>> GetProjectTasksAsync();
    Task<ProjectTaskDto> GetProjectTaskAsync(int projectTaskId);
    Task<ProjectTaskDto> UpdateProjectTaskAsync(ProjectTaskDto projectTask);
    Task DeleteProjectTaskAsync(int projectTaskId);
}

