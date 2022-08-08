using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
    public class ProjectWithTasksModel : ProjectModel
    {
        public ICollection<ProjectTaskModel> ProjectTasks { get; set; }

        public ProjectWithTasksModel()
        {
            ProjectTasks = new List<ProjectTaskModel>();
        }
    }
}
