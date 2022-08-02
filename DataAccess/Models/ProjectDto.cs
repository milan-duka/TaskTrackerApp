﻿using DataAccess.Enums;

namespace DataAccess.Models;
public class ProjectDto
{
    public int ID { get; set; }
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? CompletionDate { get; set; }
    public ProjectStatus Status { get; set; }
    public int Priority { get; set; }

    public virtual ICollection<ProjectTaskDto> ProjectTasks { get; set; }
}
