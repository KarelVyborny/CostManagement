using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostRequestStatuses;
using CostManagementSystem.Web.Models.Employee;
using CostManagementSystem.Web.Models.Period;
using CostManagementSystem.Web.Models.Projects;
using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostRequests;

public class ReviewCostRequestVM : CostRequestReadOnlyVM
{
    public EmployeeVM Employee { get; set; } = new EmployeeVM();

}
