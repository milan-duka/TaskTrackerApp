using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models;
public class ProjectTaskDto
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public Enums.TaskStatus Status { get; set; }
    public string? Description { get; set; }
    public int Priority { get; set; }
    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public ProjectDto? Project { get; set; }
}

