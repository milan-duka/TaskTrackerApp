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
    public async Task AddProjectAsync(ProjectDto project)
    {
        await _taskTrackerContext.AddAsync(project);

        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
    {
        return await _taskTrackerContext.Projects.ToListAsync();
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjectsWithTasksAsync()
    {
        return await _taskTrackerContext.Projects
            .Include(p => p.ProjectTasks)
            .ToListAsync();
    }

    public async Task<ProjectDto> GetProjectByIdAsync(int projectId)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _taskTrackerContext.Projects
            .FindAsync(projectId);
#pragma warning restore CS8603 // Possible null reference return.

    }

    public async Task UpdateProjectAsync(ProjectDto project)
    {
        _taskTrackerContext.Attach(project);
        _taskTrackerContext.Entry(project).State = EntityState.Modified;
        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task DeleteProjectAsync(ProjectDto project)
    {
        _taskTrackerContext.Projects.Remove(project);
        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task<bool> ProjectExistsAsync(int projectId)
    {
        var result = await _taskTrackerContext.Projects
            .FindAsync(projectId);

        if (result == null)
            return false;

        _taskTrackerContext.Entry(result).State = EntityState.Detached;
        return true;
    }
}

