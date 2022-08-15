using DataAccess.Enums;

namespace BusinessLogic.Models;

public class ProjectSortingParamsModel
{
    public SortByOptions SortBy { get; set; }
    public bool DescOrder { get; set; }

}
