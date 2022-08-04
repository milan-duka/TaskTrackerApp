using TaskStatus = DataAccess.Enums.TaskStatus;

namespace BusinessLogic.Models;
public class ProjectTaskModel
{
    public string Name { get; set; }
    public TaskStatus Status { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }
    public int ProjectId { get; set; }
    public ProjectModel Project { get; set; }
}
