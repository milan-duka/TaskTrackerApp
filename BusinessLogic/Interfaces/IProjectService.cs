﻿using BusinessLogic.Models;

namespace BusinessLogic.Interfaces;
public interface IProjectService
{
    Task<int?> AddProjectAsync(ProjectModel project);
    Task<IEnumerable<ProjectModel>> GetAllProjectsAsync();
    Task<IEnumerable<ProjectModel>> GetAllProjectsWithTasksAsync();
    Task<ProjectModel> GetProjectByIdAsync(int projectId);
    Task UpdateProjectAsync(int projectId, ProjectModel project);
    Task DeleteProjectAsync(int projectId);
}

