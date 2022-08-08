using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectTasksController : ControllerBase
{
    private readonly IProjectTaskService _projectTaskService;

    public ProjectTasksController(IProjectTaskService projectTaskService)
    {
        _projectTaskService = projectTaskService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectTaskModel>>> GetAllProjectTasksAsync()
    {
        try
        {
            var projectTasks = await _projectTaskService.GetAllProjectTasksAsync();

            if (!projectTasks.Any())
                return Ok();

            return Ok(projectTasks);
        }
        catch (Exception e) 
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("projectTasksByProjectId/{projectId}")]
    public async Task<ActionResult<List<ProjectTaskModel>>> GetAllProjectTasksByProjectIdAsync(int projectId)
    {
        try
        {
            var projectTasks = await _projectTaskService.GetAllProjectTasksByProjectIdAsync(projectId);

            if (!projectTasks.Any())
                return Ok();

            return Ok(projectTasks);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
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
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<List<ProjectTaskModel>>> AddProjectTask(ProjectTaskModel projectTask)
    {
        try
        {
            var addedProjectTask = await _projectTaskService.AddProjectTaskAsync(projectTask);

            return Ok(addedProjectTask);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<ProjectTaskModel>>> UpdateProjectTask(int id, ProjectTaskModel projectTaskForUpdate)
    {
        try
        {
            var updatedProjectTask = await _projectTaskService.UpdateProjectTaskAsync(id, projectTaskForUpdate);

            return Ok(await _projectTaskService.GetAllProjectTasksAsync());

        }catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ProjectTaskModel>>> DeleteProjectTask(int id)
    {
        try
        {
            await _projectTaskService.DeleteProjectTaskAsync(id);

            return Ok(await _projectTaskService.GetAllProjectTasksAsync());
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

}
