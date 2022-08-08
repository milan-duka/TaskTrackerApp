using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;
public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectMappings _projectMappings;

    public ProjectService(
        IProjectRepository projectRepository,
        IProjectMappings businessLogicHelpers)
    {
        _projectRepository = projectRepository;
        _projectMappings = businessLogicHelpers;
    }

    public async Task<ProjectModel> AddProjectAsync(ProjectModel project)
    {
        if (project == null)
            throw new Exception("There is no any project to add.");
        
        var newProjectDto = _projectMappings.MapProjectBlModelToProjectDto(project);

        await _projectRepository.AddProjectAsync(newProjectDto);

        return _projectMappings.MapProjectDtoToProjectBlModel(newProjectDto);
    }

    public async Task<IEnumerable<ProjectModel>> GetAllProjectsAsync()
    {
        var projectDtos = await _projectRepository.GetAllProjectsAsync();

        var projects = new List<ProjectModel>();

        foreach (var projectDto in projectDtos)
        {
            projects.Add(_projectMappings.MapProjectDtoToProjectBlModel(projectDto));
        }

        return projects;
    }

    public async Task<IEnumerable<ProjectModel>> GetAllProjectsWithTasksAsync()
    {
        var projectDtos = await _projectRepository.GetAllProjectsWithTasksAsync();

        var projects = new List<ProjectWithTasksModel>();

        foreach (var projectDto in projectDtos)
        {
            projects.Add(_projectMappings.MapProjectDtoWithTasksToProjectBlModelWithTasks(projectDto));
        }

        return projects;
    }

    public async Task<ProjectModel> GetProjectByIdAsync(int projectId)
    {
        var projectDto = await _projectRepository.GetProjectByIdAsync(projectId);

        if (projectDto != null)
            return _projectMappings.MapProjectDtoToProjectBlModel(projectDto);
        else
            throw new Exception($"Project with Id: {projectId} not found!");
    }

    public async Task<ProjectModel> UpdateProjectAsync(int projectId, ProjectModel project)
    {
        var projectExists = await _projectRepository.ProjectExistsAsync(projectId);
        if (!projectExists)
            throw new Exception($"Project with id {projectId} can't be updated because it is not found.");

        if (project == null)
            throw new Exception("There are missing data for project update.");

        var projectDto = _projectMappings.MapProjectBlModelToProjectDto(project);
        projectDto.Id = projectId;

        await _projectRepository.UpdateProjectAsync(projectDto);

        return _projectMappings.MapProjectDtoToProjectBlModel(projectDto);
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        var projectDto = await _projectRepository.GetProjectByIdAsync(projectId);

        if (projectDto == null)
            throw new Exception($"Project with id {projectId} can't be deleted because it is not found.");

        await _projectRepository.DeleteProjectAsync(projectDto);
    }
}
