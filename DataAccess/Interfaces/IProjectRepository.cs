using DataAccess.Models;

namespace DataAccess.Interfaces;
public interface IProjectRepository
{
    Task<ProjectDto> AddProjectAsync(ProjectDto project);
    Task<IEnumerable<ProjectDto>> GetProjectsAsync();
    Task<ProjectDto> GetProjectAsync(int projectId);
    Task<ProjectDto> UpdateProjectAsync(ProjectDto project);
    Task DeleteProjectAsync(int projectId);
    Task<bool> ProjectExistsAsync(int projectId);
}

