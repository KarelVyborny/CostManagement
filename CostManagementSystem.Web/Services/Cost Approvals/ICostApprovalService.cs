using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;

namespace CostManagementSystem.Web.Services.Cost_Approval_Workflow
{
    public interface ICostApprovalService
    {
        Task CostApproval(string employeeId);
        Task<List<CostApprovalReadOnlyVM>> GetCostApprovalsAsync(int employeeId);
    }
}