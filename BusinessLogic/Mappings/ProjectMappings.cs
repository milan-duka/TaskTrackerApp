using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using DataAccess.Models;
using DataAccess.QueriesModels;

namespace BusinessLogic.Mappings
{
    public static class ProjectMappings
    {

        public static ProjectDto MapProjectBlModelToProjectDto(ProjectModel project)
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

        public static ProjectModel MapProjectDtoToProjectBlModel(ProjectDto projectDto)
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

        public static ProjectWithTasksModel MapProjectDtoWithTasksToProjectBlModelWithTasks(ProjectDto projectDto)
        {
            return new ProjectWithTasksModel
            {
                Name = projectDto.Name,
                StartDate = projectDto.StartDate.HasValue ? projectDto.StartDate.Value : null,
                CompletionDate = projectDto.CompletionDate.HasValue ? projectDto.CompletionDate.Value : null,
                Status = projectDto.Status,
                Priority = projectDto.Priority,
                ProjectTasks = projectDto.ProjectTasks != null ? ProjectTaskMappings.MapProjectTaskDtoCollectionToProjectTaskModelCollection(projectDto.ProjectTasks) : new List<ProjectTaskModel>()
            };
        }

        public static ProjectParametersModel MapProjectFilteringParamsBlModelToProjectParametersDaModel(ProjectFilteringParamsModel project)
        {
            return new ProjectParametersModel
            {
                Name = project.Name,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Status = project.Status,
                Priority = project.Priority
            };
        }

        public static ProjectSortingParametersDaModel MapProjectSortingParamsBlModelToProjectSortingParametersDaModel(ProjectSortingParamsModel projectSortingParams)
        {
            return new ProjectSortingParametersDaModel
            {
                SortBy = projectSortingParams.SortBy,
                DescOrder = projectSortingParams.DescOrder
            };
        }
    }
}