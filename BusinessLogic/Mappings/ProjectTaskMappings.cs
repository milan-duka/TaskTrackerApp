using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Mappings
{
    public class ProjectTaskMappings : IProjectTaskMappings
    {
        public ProjectTaskDto MapProjectTaskBlModelToProjectTaskDto(ProjectTaskModel projectTask)
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
                ProjectId = projectTaskDto.ProjectId
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