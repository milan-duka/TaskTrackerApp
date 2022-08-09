using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectTasksController : TaskTrackerBaseController
{
    private readonly IProjectTaskService _projectTaskService;

    public ProjectTasksController(IProjectTaskService projectTaskService)
    {
        _projectTaskService = projectTaskService;
    }

    [HttpPost]
    public async Task<ActionResult> AddProjectTaskAsync(ProjectTaskModel projectTask)
    {
        try
        {
            var addedProjectTaskId = await _projectTaskService.AddProjectTaskAsync(projectTask);

            return Ok($"Project task is successfully added with id: {addedProjectTaskId}");
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectTaskModel>>> GetAllProjectTasksAsync()
    {
        try
        {
            var projectTasks = await _projectTaskService.GetAllProjectTasksAsync();

            return Ok(projectTasks);
        }
        catch (Exception e) 
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpGet("projectTasksByProjectId/{projectId}")]
    public async Task<ActionResult<IEnumerable<ProjectTaskModel>>> GetAllProjectTasksByProjectIdAsync(int projectId)
    {
        try
        {
            var projectTasks = await _projectTaskService.GetAllProjectTasksByProjectIdAsync(projectId);

            return Ok(projectTasks);
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectTaskModel>> GetProjectTaskByIdAsync(int id)
    {
        try
        {
            var projectTask = await _projectTaskService.GetProjectTaskByIdAsync(id);

            return Ok(projectTask);

        }catch(Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProjectTaskAsync(int id, ProjectTaskModel projectTaskForUpdate)
    {
        try
        {
            await _projectTaskService.UpdateProjectTaskAsync(id, projectTaskForUpdate);

            return Ok("Project task successfully updated.");

        }catch(Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProjectTaskAsync(int id)
    {
        try
        {
            await _projectTaskService.DeleteProjectTaskAsync(id);

            return Ok("Project task deleted successfully.");
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

}
