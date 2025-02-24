using CostManagementSystem.Application.Models.Employee;

namespace CostManagementSystem.Application.Models.CostRequests;

public class ReviewCostRequestVM : CostRequestReadOnlyVM
{
    public EmployeeVM Employee { get; set; } = new EmployeeVM();

}
