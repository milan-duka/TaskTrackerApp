﻿using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Interfaces;
using DataAccess.Models;

namespace BusinessLogic.Services;
public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(
        IProjectRepository projectRepository, 
        IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<ProjectModel> AddProjectAsync(ProjectModel project)
    {
        if (project == null)
            throw new Exception("There is no any project to add.");

        var newProjectDto = _mapper.Map<ProjectDto>(project);

        await _projectRepository.AddProjectAsync(newProjectDto);

        return _mapper.Map<ProjectModel>(newProjectDto);
    }

    public async Task DeleteProjectAsync(int projectId)
    {
        var project = await GetProjectAsync(projectId);
        if (project == null)
            throw new Exception($"Project with id {projectId} can't be deleted because it is not found.");

        await _projectRepository.DeleteProjectAsync(projectId);
    }

    public async Task<ProjectModel> GetProjectAsync(int projectId)
    {
        var projectDto = await _projectRepository.GetProjectAsync(projectId);

        if (projectDto != null)
            return _mapper.Map<ProjectModel>(projectDto);
        else
            throw new Exception($"Project with Id: {projectId} not found!");
    }

    public async Task<IEnumerable<ProjectModel>> GetProjectsAsync()
    {
        var projectDtos = await _projectRepository.GetProjectsAsync();

        if (!projectDtos.Any())
            throw new Exception("There doesn't exist any project.");

        var projects = new List<ProjectModel>();

        foreach (var projectDto in projectDtos)
        {
            projects.Add(_mapper.Map<ProjectModel>(projectDto));
        }

        return projects;
    }

    public async Task<ProjectModel> UpdateProjectAsync(int projectId, ProjectModel project)
    {
        var existingProject = await GetProjectAsync(projectId);
        if (existingProject == null)
            throw new Exception($"Project with id {projectId} can't be updated because it is not found.");

        if (project == null)
            throw new Exception("There are missing data for project update.");

        var projectDto = _mapper.Map<ProjectDto>(project);
        projectDto.Id = projectId;

        var result = await _projectRepository.UpdateProjectAsync(projectDto);

        if (result != null)
            return _mapper.Map<ProjectModel>(result);
        else
            throw new Exception("Project is not updated because it is not found.");
    }
}
