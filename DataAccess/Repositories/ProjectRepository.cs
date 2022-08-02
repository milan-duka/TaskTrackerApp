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
        return await _taskTrackerContext.Projects
            .FindAsync(projectId);
    }

    public async Task<IEnumerable<ProjectDto>> GetProjectsAsync()
    {
        return await _taskTrackerContext.Projects.ToListAsync();
    }

    public async Task<ProjectDto> UpdateProjectAsync(ProjectDto project)
    {
        var result = await _taskTrackerContext.Projects
            .FindAsync(project.ID);

        if (result != null)
        {
            result.Name = project.Name;
            result.StartDate = project.StartDate;
            result.CompletionDate = project.CompletionDate;
            result.Status = project.Status;
            result.Priority = project.Priority;

            await _taskTrackerContext.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        var result = await _taskTrackerContext.Projects
            .FirstOrDefaultAsync(p => p.ID == projectId);
        if (result != null)
        {
            _taskTrackerContext.Projects.Remove(result);
            await _taskTrackerContext.SaveChangesAsync();
        }
    }
}

