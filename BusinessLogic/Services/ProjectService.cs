using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappings;
using BusinessLogic.Models;
using DataAccess.Interfaces;

namespace BusinessLogic.Services;
public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(
        IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<int?> AddProjectAsync(ProjectModel project)
    {
        if (project == null)
            return null;

        var newProjectDto = ProjectMappings.MapProjectBlModelToProjectDto(project);

        await _projectRepository.AddProjectAsync(newProjectDto);

        return newProjectDto.Id;
    }

    public async Task<IEnumerable<ProjectModel>> GetAllProjectsAsync()
    {
        var projectDtos = await _projectRepository.GetAllProjectsAsync();

        var projects = new List<ProjectModel>();

        foreach (var projectDto in projectDtos)
        {
            projects.Add(ProjectMappings.MapProjectDtoToProjectBlModel(projectDto));
        }

        return projects;
    }

    public async Task<IEnumerable<ProjectModel>> GetAllProjectsWithTasksAsync()
    {
        var projectDtos = await _projectRepository.GetAllProjectsWithTasksAsync();

        var projects = new List<ProjectWithTasksModel>();

        foreach (var projectDto in projectDtos)
        {
            projects.Add(ProjectMappings.MapProjectDtoWithTasksToProjectBlModelWithTasks(projectDto));
        }

        return projects;
    }

    public async Task<ProjectModel> GetProjectByIdAsync(int projectId)
    {
        var projectDto = await _projectRepository.GetProjectByIdAsync(projectId);

        if (projectDto == null)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
            $"Project with Id: {projectId} not found!");

        return ProjectMappings.MapProjectDtoToProjectBlModel(projectDto);
    }

    public async Task UpdateProjectAsync(int projectId, ProjectModel project)
    {
        var projectExists = await _projectRepository.ProjectExistsAsync(projectId);

        if (!projectExists)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
                $"Project with id {projectId} can't be updated because it is not found.");

        var projectDto = ProjectMappings.MapProjectBlModelToProjectDto(project);
        projectDto.Id = projectId;

        await _projectRepository.UpdateProjectAsync(projectDto);
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        var projectDto = await _projectRepository.GetProjectByIdAsync(projectId);

        if (projectDto == null)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
                    $"Project with id {projectId} can't be deleted because it is not found.");

        await _projectRepository.DeleteProjectAsync(projectDto);
    }
}
