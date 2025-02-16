using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostCodes;

namespace CostManagementSystem.Web.Services.Cost_Approval_Workflow
{
    public interface ICostApprovalService
    {
        Task CostApproval(string employeeId);
        Task<List<CostApprovalReadOnlyVM>> GetCostApprovalsAsync(int employeeId);

        Task AddAsync(CostApprovalCreateVM costApprovalCreate);
    }
}