using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;
public class ProjectRepository : IProjectRepository
{
    private readonly TaskTrackerContext _taskTrackerContext;
    public ProjectRepository(TaskTrackerContext taskTrackerContext)
    {
        _taskTrackerContext = taskTrackerContext;
    }
    public async Task<ProjectDto> AddProjectAsync(ProjectDto project)
    {
        var result = await _taskTrackerContext.AddAsync(project);

        await _taskTrackerContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<ProjectDto> GetProjectAsync(int projectId)
    {
        var result = await _taskTrackerContext.Projects
            .FindAsync(projectId);

        if (result != null)
            return result;
        else
            throw new Exception($"Project with Id: {projectId} not found!");
    }

    public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
    {
        return await _taskTrackerContext.Projects.ToListAsync();
    }

    public async Task<ProjectDto> UpdateProjectAsync(ProjectDto project)
    {
        var result = await _taskTrackerContext.Projects
            .FindAsync(project.Id);

        if (project != null && result != null)
        {
            await _taskTrackerContext.SaveChangesAsync();

            return project;
        }
        else
            throw new Exception("Project is not updated because it is not found.");
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        var result = await _taskTrackerContext.Projects
            .FindAsync(projectId);

        if (result != null)
        {
            _taskTrackerContext.Projects.Remove(result);
            await _taskTrackerContext.SaveChangesAsync();
        }
    }
}

