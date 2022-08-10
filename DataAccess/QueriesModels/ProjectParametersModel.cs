using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.QueriesModels;
public class ProjectParametersModel
{
    public string? Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public ProjectStatus? Status { get; set; }
    public int? Priority { get; set; }
}

