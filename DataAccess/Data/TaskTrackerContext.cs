using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;
public class TaskTrackerContext : DbContext
{
    public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options)
    {
    }
    public DbSet<ProjectDto> Projects { get; set; }
    public DbSet<ProjectTaskDto> ProjectTasks { get; set; }
}

