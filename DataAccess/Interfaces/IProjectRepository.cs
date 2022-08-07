using DataAccess.Models;

namespace DataAccess.Interfaces;
public interface IProjectRepository
{
    Task AddProjectAsync(ProjectDto project);
    Task<IEnumerable<ProjectDto>> GetProjectsAsync();
    Task<ProjectDto> GetProjectByIdAsync(int projectId);
    Task UpdateProjectAsync(ProjectDto project);
    Task DeleteProjectAsync(ProjectDto project);
    Task<bool> ProjectExistsAsync(int projectId);
}

