using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;
public class ProjectTaskService : IProjectTaskService
{
    private readonly IProjectTaskRepository _projectTaskRepository;
    private readonly IMapper _mapper;

    public ProjectTaskService(
        IProjectTaskRepository projectTaskRepository, 
        IMapper mapper)
    {
        _projectTaskRepository = projectTaskRepository;
        _mapper = mapper;
    }

    public async Task<ProjectTaskModel> AddProjectTaskAsync(ProjectTaskModel projectTask)
    {
        if (projectTask == null)
            throw new Exception("There is no any project to add.");

        var newProjectTaskDto = _mapper.Map<ProjectTaskDto>(projectTask);

        await _projectTaskRepository.AddProjectTaskAsync(newProjectTaskDto);

        return _mapper.Map<ProjectTaskModel>(newProjectTaskDto);
    }

    public async Task DeleteProjectTaskAsync(int projectTaskId)
    {
        var projectTask = await GetProjectTaskAsync(projectTaskId);
        if (projectTask == null)
            throw new Exception($"Task with id {projectTaskId} can't be deleted because it is not found.");

        await _projectTaskRepository.DeleteProjectTaskAsync(projectTaskId);
    }

    public async Task<ProjectTaskModel> GetProjectTaskAsync(int projectTaskId)
    {
        var projectTaskDto = await _projectTaskRepository.GetProjectTaskAsync(projectTaskId);

        if (projectTaskDto != null)
            return _mapper.Map<ProjectTaskModel>(projectTaskDto);
        else
            throw new Exception($"Task with Id: {projectTaskId} not found!");
    }

    public async Task<IEnumerable<ProjectTaskModel>> GetProjectTasksAsync()
    {
        var projectTaskDtos = await _projectTaskRepository.GetProjectTasksAsync();
        
        if(!projectTaskDtos.Any())
            throw new Exception("There doesn't exist any task.");

        var projectTasks = new List<ProjectTaskModel>();

        foreach (var projectTask in projectTaskDtos)
        {
            projectTasks.Add(_mapper.Map<ProjectTaskModel>(projectTask));
        }
        
        return projectTasks;
    }

    public async Task<ProjectTaskModel> UpdateProjectTaskAsync(int projectTaskId, ProjectTaskModel projectTask)
    {
        var existingTask = await GetProjectTaskAsync(projectTaskId);
        if (existingTask == null)
            throw new Exception($"Task with id {projectTaskId} can't be updated because it is not found.");

        if (projectTask == null)
            throw new Exception("There are missing data for project update.");

        var projectTaskDto = _mapper.Map<ProjectTaskDto>(projectTask);
        projectTaskDto.Id = projectTaskId;

        var result = await _projectTaskRepository.UpdateProjectTaskAsync(projectTaskDto);

        if (result != null)
            return _mapper.Map<ProjectTaskModel>(result);
        else
            throw new Exception("Task is not updated because it is not found.");
    }
}
