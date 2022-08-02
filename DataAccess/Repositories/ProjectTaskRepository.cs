﻿using DataAccess.Interfaces;
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
    public async Task<ProjectTaskDto> AddProjectTaskAsync(ProjectTaskDto projectTask)
    {
        var result = await _taskTrackerContext.ProjectTasks.AddAsync(projectTask);

        await _taskTrackerContext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<ProjectTaskDto> GetProjectTaskAsync(int projectTaskId)
    {
        return await _taskTrackerContext.ProjectTasks
            .FindAsync(projectTaskId);
    }

    public async Task<IEnumerable<ProjectTaskDto>> GetProjectTasksAsync()
    {
        return await _taskTrackerContext.ProjectTasks.ToListAsync();
    }

    public async Task<ProjectTaskDto> UpdateProjectTaskAsync(ProjectTaskDto projectTask)
    {
        var result = await _taskTrackerContext.ProjectTasks
            .FindAsync(projectTask.ID);

        if (result != null)
        {
            result.Name = projectTask.Name;
            result.Status = projectTask.Status;
            result.Description = projectTask.Description;
            result.Priority = projectTask.Priority;
            result.ProjectID = projectTask.ProjectID;

            await _taskTrackerContext.SaveChangesAsync();

            return result;
        }

        return null;
    }

    public async Task DeleteProjectTaskAsync(int projectTaskId)
    {
        var result = await _taskTrackerContext.ProjectTasks
            .FindAsync(projectTaskId);
        if (result != null)
        {
            _taskTrackerContext.ProjectTasks.Remove(result);
            await _taskTrackerContext.SaveChangesAsync();
        }
    }
}
