using CostManagementSystem.Application.Models.CostApproval;

namespace CostManagementSystem.Application.Services.Cost_Approval_Workflow
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