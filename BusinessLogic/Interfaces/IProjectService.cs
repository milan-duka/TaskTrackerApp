using BusinessLogic.Models;

namespace BusinessLogic.Interfaces;
public interface IProjectService
{
    Task<ProjectModel> AddProjectAsync(ProjectModel project);
    Task<IEnumerable<ProjectModel>> GetAllProjectsAsync();
    Task<ProjectModel> GetProjectByIdAsync(int projectId);
    Task<ProjectModel> UpdateProjectAsync(int projectId, ProjectModel project);
    Task DeleteProjectAsync(int projectId);
}

