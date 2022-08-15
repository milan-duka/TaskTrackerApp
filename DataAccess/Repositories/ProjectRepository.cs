using DataAccess.Data;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.QueriesModels;
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
        return await _taskTrackerContext.Projects
            .Include(p => p.ProjectTasks)
            .ToListAsync();
    }

    public async Task<ProjectDto?> GetProjectByIdAsync(int projectId)
    {
        return await _taskTrackerContext.Projects
            .Include(p => p.ProjectTasks)
            .FirstOrDefaultAsync(p => p.Id == projectId);
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

    public async Task<IEnumerable<ProjectDto>> GetAllProjectsByFiltersAsync(ProjectParametersModel paramsModel)
    {
        var query = _taskTrackerContext.Projects
            .Include(p => p.ProjectTasks)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(paramsModel.Name))
            query = query.
                Where(p => !string.IsNullOrEmpty(p.Name) && p.Name.Contains(paramsModel.Name));

        if (paramsModel.StartDate.HasValue)
            query = query
            .Where(p => p.StartDate.HasValue
                        && p.StartDate.Value.Date.Equals(paramsModel.StartDate.Value.Date));

        if (paramsModel.CompletionDate.HasValue)
            query = query
            .Where(p => p.CompletionDate.HasValue
                        && p.CompletionDate.Value.Date.Equals(paramsModel.CompletionDate.Value.Date));

        if (paramsModel.Status.HasValue)
            query = query
                .Where(p => p.Status == paramsModel.Status.Value);

        if (paramsModel.Priority.HasValue)
            query = query
                .Where(p => p.Priority == paramsModel.Priority.Value);

        return await query.ToListAsync();
    }

    public async Task<IEnumerable<ProjectDto>> GetAllProjectsSortedAsync(ProjectSortingParametersDaModel paramsModel)
    {
        var query = _taskTrackerContext.Projects
            .Include(p => p.ProjectTasks)
            .AsQueryable();

        switch (paramsModel.SortBy)
        {
            case Enums.SortByOptions.Name:
                {
                    if(paramsModel.DescOrder)
                    {
                        query = query.OrderByDescending(p => p.Name);
                        break;
                    }

                    query = query.OrderBy(p => p.Name);
                }
                break;
            case Enums.SortByOptions.StartDate:
                {
                    if (paramsModel.DescOrder)
                    {
                        query = query.OrderByDescending(p => p.StartDate.HasValue)
                        .ThenByDescending(p => p.StartDate);
                        break;
                    }

                    query = query.OrderByDescending(p => p.StartDate.HasValue)
                        .ThenBy(p => p.StartDate);
                }
                break;
            case Enums.SortByOptions.CompletionDate:
                {
                    if (paramsModel.DescOrder)
                    {
                        query = query.OrderByDescending(p => p.CompletionDate.HasValue)
                        .ThenByDescending(p => p.CompletionDate);
                        break;
                    }

                    query = query.OrderByDescending(p => p.CompletionDate.HasValue)
                        .ThenBy(p => p.CompletionDate);
                }
                break;
            case Enums.SortByOptions.Status:
                {
                    if (paramsModel.DescOrder)
                    {
                        query = query.OrderByDescending(p => p.Status);
                        break;
                    }

                    query = query.OrderBy(p => p.Status);
                }
                break;
            case Enums.SortByOptions.Priority:
                {
                    if (paramsModel.DescOrder)
                    {
                        query = query.OrderByDescending(p => p.Priority);
                        break;
                    }

                    query = query.OrderBy(p => p.Priority);
                }
                break;
        }

        return await query.ToListAsync();
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

