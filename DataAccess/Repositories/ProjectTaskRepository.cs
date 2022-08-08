using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories;
public class ProjectTaskRepository : IProjectTaskRepository
{
    private readonly TaskTrackerContext _taskTrackerContext;
    public ProjectTaskRepository(TaskTrackerContext taskTrackerContext)
    {
        _taskTrackerContext = taskTrackerContext;
    }
    public async Task AddProjectTaskAsync(ProjectTaskDto projectTask)
    {
        await _taskTrackerContext.ProjectTasks.AddAsync(projectTask);

        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProjectTaskDto>> GetAllProjectTasksAsync()
    {
        return await _taskTrackerContext.ProjectTasks.ToListAsync();
    }

    public async Task<IEnumerable<ProjectTaskDto>> GetAllProjectTasksByProjectIdAsync(int projectId)
    {
        return await _taskTrackerContext.ProjectTasks.Where(pt => pt.ProjectId == projectId).ToListAsync();
    }

    public async Task<ProjectTaskDto> GetProjectTaskByIdAsync(int projectTaskId)
    {
#pragma warning disable CS8603 // Possible null reference return.
        return await _taskTrackerContext.ProjectTasks
            .FindAsync(projectTaskId);
#pragma warning restore CS8603 // Possible null reference return.
    }

    public async Task UpdateProjectTaskAsync(ProjectTaskDto projectTask)
    {
        _taskTrackerContext.Attach(projectTask);
        _taskTrackerContext.Entry(projectTask).State = EntityState.Modified;
        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task DeleteProjectTaskAsync(ProjectTaskDto projectTask)
    {
        _taskTrackerContext.ProjectTasks.Remove(projectTask);
        await _taskTrackerContext.SaveChangesAsync();
    }

    public async Task<bool> ProjectTaskExistsAsync(int projectTaskId)
    {
        var result = await _taskTrackerContext.ProjectTasks
            .FindAsync(projectTaskId);

        if (result == null)
            return false;

        _taskTrackerContext.Entry(result).State = EntityState.Detached;
        return true;
    }
}

