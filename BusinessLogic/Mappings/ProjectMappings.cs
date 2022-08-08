using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Mappings
{
    public class ProjectMappings : IProjectMappings
    {

        public ProjectDto MapProjectBlModelToProjectDto(ProjectModel project)
        {
            return new ProjectDto
            {
                Name = project.Name,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };
        }

        public ProjectModel MapProjectDtoToProjectBlModel(ProjectDto projectDto)
        {
            return new ProjectModel
            {
                Name = projectDto.Name,
                StartDate = projectDto.StartDate.HasValue ? projectDto.StartDate.Value : null,
                CompletionDate = projectDto.CompletionDate.HasValue ? projectDto.CompletionDate.Value : null,
                Status = projectDto.Status,
                Priority = projectDto.Priority
            };
        }

        public ProjectWithTasksModel MapProjectDtoWithTasksToProjectBlModelWithTasks(ProjectDto projectDto)
        {
            return new ProjectWithTasksModel
            {
                Name = projectDto.Name,
                StartDate = projectDto.StartDate.HasValue ? projectDto.StartDate.Value : null,
                CompletionDate = projectDto.CompletionDate.HasValue ? projectDto.CompletionDate.Value : null,
                Status = projectDto.Status,
                Priority = projectDto.Priority,
                ProjectTasks = projectDto.ProjectTasks != null ? MapProjectTaskDtoCollectionToProjectTaskModelCollection(projectDto.ProjectTasks) : new List<ProjectTaskModel>()
            };
        }

        public ProjectTaskDto MapProjectTaskBlModelToProjectDto(ProjectTaskModel projectTask)
        {
            return new ProjectTaskDto
            {
                Name = projectTask.Name,
                Status = projectTask.Status,
                Description = projectTask.Description,
                Priority = projectTask.Priority,
                ProjectId = projectTask.ProjectId
            };
        }


        public ProjectTaskModel MapProjectTaskDtoToProjectTaskBlModel(ProjectTaskDto projectTaskDto)
        {
            return new ProjectTaskModel
            {
                Name = projectTaskDto.Name,
                Status = projectTaskDto.Status,
                Description = projectTaskDto.Description,
                Priority = projectTaskDto.Priority,
                ProjectId = projectTaskDto.ProjectId.HasValue ? projectTaskDto.ProjectId.Value : null
            };
        }

        public ICollection<ProjectTaskModel> MapProjectTaskDtoCollectionToProjectTaskModelCollection(ICollection<ProjectTaskDto> projectDtoCollection)
        {
            var projectTaskModels = new List<ProjectTaskModel>();
            foreach (var projectTaskDto in projectDtoCollection)
            {
                projectTaskModels.Add(MapProjectTaskDtoToProjectTaskBlModel(projectTaskDto));
            }

            return projectTaskModels;
        }
    }
}