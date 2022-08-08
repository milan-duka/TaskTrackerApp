using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TaskStatus = DataAccess.Enums.TaskStatus;

namespace BusinessLogic.Models;
public class ProjectTaskModel
{
    [Required]
    public string? Name { get; set; }
    public TaskStatus Status { get; set; }
    [Required]
    public string? Description { get; set; }
    public int Priority { get; set; }
    [Required]
    public int? ProjectId { get; set; }
    [JsonIgnore]
    public ProjectModel? Project { get; set; }

}
