using CostManagementSystem.Web.Data;

namespace CostManagementSystem.Web.Models.Projects;

public class ProjectVM
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

}
