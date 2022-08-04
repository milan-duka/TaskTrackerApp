using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
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
        public async Task<ActionResult<List<ProjectModel>>> GetProjectsAsync()
        {
            var projects = await _projectService.GetProjectsAsync();

            if (!projects.Any())
                return Ok();

            return Ok(projects);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectModel>> GetProjectAsync(int id)
        {
            var project = await _projectService.GetProjectAsync(id);

            if (project == null)
                return BadRequest("Project not found.");
            
            return Ok(project);
        }

        [HttpPost]
        public async Task<ActionResult<List<ProjectModel>>> AddProject(ProjectModel project)
        {
            var addedProject = await _projectService.AddProjectAsync(project);

            return Ok(addedProject);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<ProjectModel>>> UpdateProject(int id, ProjectModel projectForUpdate)
        {
            var updatedProject = await _projectService.UpdateProjectAsync(id, projectForUpdate);
            
            if (updatedProject == null)
                return BadRequest("Project not found.");

            return Ok(await _projectService.GetProjectsAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ProjectModel>>> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);

            return Ok(await _projectService.GetProjectsAsync());
        }

    }
}
