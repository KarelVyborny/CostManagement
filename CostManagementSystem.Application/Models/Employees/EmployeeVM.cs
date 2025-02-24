using CostManagementSystem.Application.Models.CostApproval;

namespace CostManagementSystem.Application.Models.Employee
{
    public class EmployeeVM
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        public List<CostApprovalReadOnlyVM> CostApprovals { get; set; }
    }
}
