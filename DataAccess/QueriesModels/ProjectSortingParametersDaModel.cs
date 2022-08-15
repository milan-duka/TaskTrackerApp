using DataAccess.Enums;

namespace DataAccess.QueriesModels;

public class ProjectSortingParametersDaModel
{
    public SortByOptions SortBy { get; set; }
    public bool DescOrder { get; set; }

}
