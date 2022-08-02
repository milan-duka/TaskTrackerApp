﻿using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models;
public class TaskTrackerContext : DbContext
{
    public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<ProjectDto> Projects { get; set; }
    public DbSet<ProjectTaskDto> ProjectTasks { get; set; }
}

