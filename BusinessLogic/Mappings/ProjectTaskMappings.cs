using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Models;

namespace BusinessLogic.Mappings
{
    public class ProjectTaskMappings
    {
        public static ProjectTaskDto MapProjectTaskBlModelToProjectTaskDto(ProjectTaskModel projectTask)
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

        public static ProjectTaskModel MapProjectTaskDtoToProjectTaskBlModel(ProjectTaskDto projectTaskDto)
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

        public static IEnumerable<ProjectTaskModel> MapProjectTaskDtoCollectionToProjectTaskModelCollection(IEnumerable<ProjectTaskDto> projectDtoCollection)
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