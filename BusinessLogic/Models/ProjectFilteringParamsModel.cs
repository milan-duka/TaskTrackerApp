using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Models;
public class ProjectFilteringParamsModel
{
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime? StartDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? CompletionDate { get; set; }
    public ProjectStatus? Status { get; set; }
    public int? Priority { get; set; }
}
