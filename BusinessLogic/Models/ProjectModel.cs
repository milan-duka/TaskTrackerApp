using DataAccess.Enums;

namespace BusinessLogic.Models;
public class ProjectModel
{
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }
    public ICollection<ProjectTaskModel> ProjectTasks { get; set; }

    public ProjectModel()
    {
        ProjectTasks = new List<ProjectTaskModel>();
    }
}
