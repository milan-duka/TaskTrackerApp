using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectModel>>> GetAllProjectsAsync()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsAsync();

            if (!projects.Any())
                return Ok();

            return Ok(projects);
        }
        catch (Exception e) 
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("allProjectsWithTasks")]
    public async Task<ActionResult<List<ProjectWithTasksModel>>> GetAllProjectsWithTasksAsync()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsWithTasksAsync();

            if (!projects.Any())
                return Ok();

            return Ok(projects);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectModel>> GetProjectByIdAsync(int id)
    {
        try
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            return Ok(project);
        }catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<List<ProjectModel>>> AddProject(ProjectModel project)
    {
        try
        {
            var addedProject = await _projectService.AddProjectAsync(project);

            return Ok(addedProject);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<ProjectModel>>> UpdateProject(int id, ProjectModel projectForUpdate)
    {
        try
        {
            var updatedProject = await _projectService.UpdateProjectAsync(id, projectForUpdate);

            return Ok(await _projectService.GetAllProjectsAsync());

        }catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ProjectModel>>> DeleteProject(int id)
    {
        try
        {
            await _projectService.DeleteProjectAsync(id);

            return Ok(await _projectService.GetAllProjectsAsync());
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

}
