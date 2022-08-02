using DataAccess.Interfaces;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories;
public class ProjectRepository : IProjectRepository
{
    public Task<ProjectDto> AddProjectAsync(ProjectDto project)
    {
        throw new NotImplementedException();
    }

    public Task DeleteProjectAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    public Task<ProjectDto> GetProjectAsync(int projectId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ProjectDto>> GetProjectsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ProjectDto> UpdateProjectAsync(ProjectDto project)
    {
        throw new NotImplementedException();
    }
}

