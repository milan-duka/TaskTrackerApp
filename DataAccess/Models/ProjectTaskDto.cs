namespace DataAccess.Models;
public class ProjectTaskDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public Enums.TaskStatus Status { get; set; }
    public string Description { get; set; }
    public int Priority { get; set; }

    public int ProjectID { get; set; }
    public virtual ProjectDto Project { get; set; }
}

