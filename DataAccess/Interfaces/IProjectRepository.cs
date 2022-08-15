using DataAccess.Models;
using DataAccess.QueriesModels;

namespace DataAccess.Interfaces;
public interface IProjectRepository
{
    Task AddProjectAsync(ProjectDto project);
    Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
    Task<ProjectDto?> GetProjectByIdAsync(int projectId);
    Task UpdateProjectAsync(ProjectDto project);
    Task DeleteProjectAsync(ProjectDto project);
    Task<IEnumerable<ProjectDto>> GetAllProjectsByFiltersAsync(ProjectParametersModel paramsModel);
    Task<IEnumerable<ProjectDto>> GetAllProjectsSortedAsync(ProjectSortingParametersDaModel paramsModel);
    Task<bool> ProjectExistsAsync(int projectId);
}