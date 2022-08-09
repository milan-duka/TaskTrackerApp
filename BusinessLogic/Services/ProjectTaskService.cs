using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Mappings;
using BusinessLogic.Models;
using DataAccess.Interfaces;

namespace BusinessLogic.Services;
public class ProjectTaskService : IProjectTaskService
{
    private readonly IProjectTaskRepository _projectTaskRepository;
    private readonly IProjectRepository _projectRepository;

    public ProjectTaskService(
        IProjectTaskRepository projectTaskRepository,
        IProjectRepository projectRepository)
    {
        _projectTaskRepository = projectTaskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<int?> AddProjectTaskAsync(ProjectTaskModel projectTask)
    {
        if (projectTask == null || !projectTask.ProjectId.HasValue)
            return null;

        var projectDto = _projectRepository.GetProjectByIdAsync(projectTask.ProjectId.Value);

        if (projectDto.Result == null)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
                $"Project task can't be added because related project with id {projectTask.ProjectId.Value} doesn't exist.");

        var newProjectTaskDto = ProjectTaskMappings.MapProjectTaskBlModelToProjectTaskDto(projectTask);

        await _projectTaskRepository.AddProjectTaskAsync(newProjectTaskDto);

        return newProjectTaskDto.Id;
    }

    public async Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksAsync()
    {
        var projectTaskDtos = await _projectTaskRepository.GetAllProjectTasksAsync();

        var projectTasks = new List<ProjectTaskModel>();

        foreach (var projectTaskDto in projectTaskDtos)
        {
            projectTasks.Add(ProjectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto));
        }

        return projectTasks;
    }

    public async Task<IEnumerable<ProjectTaskModel>> GetAllProjectTasksByProjectIdAsync(int projectId)
    {
        var projectTasks = new List<ProjectTaskModel>();

        var projectDto = _projectRepository.GetProjectByIdAsync(projectId);

        if (projectDto.Result == null)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
            $"Project with id {projectId} doesn't exist.");

        var projectTaskDtos = await _projectTaskRepository.GetAllProjectTasksByProjectIdAsync(projectId);

        foreach (var projectTaskDto in projectTaskDtos)
        {
            projectTasks.Add(ProjectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto));
        }

        return projectTasks;
    }

    public async Task<ProjectTaskModel> GetProjectTaskByIdAsync(int projectTaskId)
    {
        var projectTaskDto = await _projectTaskRepository.GetProjectTaskByIdAsync(projectTaskId);

        if (projectTaskDto == null)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
            $"Task with Id: {projectTaskId} not found!");

        return ProjectTaskMappings.MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto);
    }

    public async Task UpdateProjectTaskAsync(int projectTaskId, ProjectTaskModel projectTask)
    {
        var projectTaskExists = await _projectTaskRepository.ProjectTaskExistsAsync(projectTaskId);

        if (!projectTaskExists)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
                    $"Task with id {projectTaskId} can't be updated because it is not found.");

        if (projectTask.ProjectId.HasValue)
        {
            var projectDto = _projectRepository.GetProjectByIdAsync(projectTask.ProjectId.Value);

            if (projectDto.Result == null)
                throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
                $"Related project with id {projectTask.ProjectId.Value} doesn't exist so this project task can't be updated.");

        }

        var projectTaskDto = ProjectTaskMappings.MapProjectTaskBlModelToProjectTaskDto(projectTask);
        projectTaskDto.Id = projectTaskId;

        await _projectTaskRepository.UpdateProjectTaskAsync(projectTaskDto);
    }

    public async Task DeleteProjectTaskAsync(int projectTaskId)
    {
        var projectTaskDto = await _projectTaskRepository.GetProjectTaskByIdAsync(projectTaskId);

        if (projectTaskDto == null)
            throw ExceptionHandlingHelper.ExceptionWithCustomCodeAndMessage(404,
                    $"Task with id {projectTaskId} can't be deleted because it is not found.");

        await _projectTaskRepository.DeleteProjectTaskAsync(projectTaskDto);
    }
}
