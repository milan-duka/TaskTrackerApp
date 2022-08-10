using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : TaskTrackerBaseController
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<ActionResult> AddProjectAsync(ProjectModel project)
    {
        try
        {
            var addedProjectId = await _projectService.AddProjectAsync(project);

            return Ok($"Project is successfully added with id: {addedProjectId}");
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectWithTasksModel>>> GetAllProjectsAsync()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsAsync();

            return Ok(projects);
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectModel>> GetProjectByIdAsync(int id)
    {
        try
        {
            var project = await _projectService.GetProjectByIdAsync(id);

            return Ok(project);

        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateProjectAsync(int id, ProjectModel projectForUpdate)
    {
        try
        {
            await _projectService.UpdateProjectAsync(id, projectForUpdate);

            return Ok("Project is successfully updated.");

        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProjectAsync(int id)
    {
        try
        {
            await _projectService.DeleteProjectAsync(id);

            return Ok("Project is successfully deleted.");
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpPost]
    [Route("allProjectsByFilters")]
    public async Task<ActionResult<IEnumerable<ProjectWithTasksModel>>> GetAllProjectsByFiltersAsync(
        [FromBody] ProjectFilteringParamsModel filteringParams)
    {
        try
        {
            var projects = await _projectService.GetAllProjectsByFiltersAsync(filteringParams);

            return Ok(projects);
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpGet]
    [Route("allProjectsSortedByStartDate")]
    public async Task<ActionResult<IEnumerable<ProjectWithTasksModel>>> GetAllProjectsSortedByStartDateAsync()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsSortedByStartDateAsync();

            return Ok(projects);
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

    [HttpGet]
    [Route("allProjectsSortedByPriority")]
    public async Task<ActionResult<IEnumerable<ProjectWithTasksModel>>> GetAllProjectsSortedByPriorityAsync()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsSortedByPriorityAsync();

            return Ok(projects);
        }
        catch (Exception e)
        {
            return ReturnStatusCodeWithExceptionMessage(e);
        }
    }

}
