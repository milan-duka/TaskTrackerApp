using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;
public class ProjectTaskService : IProjectTaskService
{
    private readonly IProjectTaskRepository _projectTaskRepository;
    private readonly IProjectTaskMappings _projectTaskMappings;

    public ProjectTaskService(
        IProjectTaskRepository projectTaskRepository,
        IProjectTaskMappings projectTaskMappings)
    {
        _projectTaskRepository = projectTaskRepository;
        _projectTaskMappings = projectTaskMappings;
    }

    public async Task<ProjectTaskModel> AddProjectTaskAsync(ProjectTaskModel projectTask)
    {
        if (projectTask == null)
            throw new Exception("There is no any project to add.");

        var newProjectTaskDto = _projectTaskMappings.MapProjectTaskBlModelToProjectTaskDto(projectTask);

        await _projectTaskRepository.AddProjectTaskAsync(newProjectTaskDto);

        return _projectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(newProjectTaskDto);
    }

    public async Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksAsync()
    {
        var projectTaskDtos = await _projectTaskRepository.GetAllProjectTasksAsync();

        var projectTasks = new List<ProjectTaskModel>();

        foreach (var projectTaskDto in projectTaskDtos)
        {
            projectTasks.Add(_projectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto));
        }

        return projectTasks;
    }

    public async Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksByProjectIdAsync(int projectId)
    {
        var projectTaskDtos = await _projectTaskRepository.GetAllProjectTasksByProjectIdAsync(projectId);

        var projectTasks = new List<ProjectTaskModel>();

        foreach (var projectTaskDto in projectTaskDtos)
        {
            projectTasks.Add(_projectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto));
        }

        return projectTasks;
    }

    public async Task<ProjectTaskModel> GetProjectTaskByIdAsync(int projectTaskId)
    {
        var projectTaskDto = await _projectTaskRepository.GetProjectTaskByIdAsync(projectTaskId);

        if (projectTaskDto != null)
            return _projectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto);
        else
            throw new Exception($"Task with Id: {projectTaskId} not found!");
    }

    public async Task<ProjectTaskModel> UpdateProjectTaskAsync(int projectTaskId, ProjectTaskModel projectTask)
    {
        var projectTaskExists = await _projectTaskRepository.ProjectTaskExistsAsync(projectTaskId);
        if (!projectTaskExists)
            throw new Exception($"Task with id {projectTaskId} can't be updated because it is not found.");

        if (projectTask == null)
            throw new Exception("There are missing data for project update.");

        var projectTaskDto = _projectTaskMappings.MapProjectTaskBlModelToProjectTaskDto(projectTask);
        projectTaskDto.Id = projectTaskId;

        await _projectTaskRepository.UpdateProjectTaskAsync(projectTaskDto);

        return _projectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto);
    }

    public async Task DeleteProjectTaskAsync(int projectTaskId)
    {
        var projectTaskDto = await _projectTaskRepository.GetProjectTaskByIdAsync(projectTaskId);

        if (projectTaskDto == null)
            throw new Exception($"Task with id {projectTaskId} can't be deleted because it is not found.");

        await _projectTaskRepository.DeleteProjectTaskAsync(projectTaskDto);
    }
}
