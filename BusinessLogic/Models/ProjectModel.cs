using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models;
public class ProjectModel
{
    [Required]
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
}
