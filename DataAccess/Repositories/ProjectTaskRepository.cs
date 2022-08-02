using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories;
public class ProjectTaskRepository : IProjectTaskRepository
{
    public ProjectTaskRepository()
    {

    }
    public Task<ProjectTaskDto> AddProjectTaskAsync(ProjectTaskDto projectTask)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProjectTaskAsync(int projectTaskId)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectTaskDto> GetProjectTaskAsync(int projectTaskId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProjectTaskDto>> GetProjectTasksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProjectTaskDto> UpdateProjectTaskAsync(ProjectTaskDto projectTask)
    {
        throw new NotImplementedException();
    }
}

