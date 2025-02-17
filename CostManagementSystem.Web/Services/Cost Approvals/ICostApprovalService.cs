using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostCodes;

namespace CostManagementSystem.Web.Services.Cost_Approval_Workflow
{
    public interface ICostApprovalService
    {
        Task<List<CostApprovalReadOnlyVM>> GetCostApprovalsAsync();

        Task AddAsync(CostApprovalCreateVM costApprovalCreate);
        Task<T?> GetAsync<T>(int id) where T : class;
        Task EditAsync(CostApprovalEditVM costApprovalEdit);
        Task Remove(int id);

    }
}