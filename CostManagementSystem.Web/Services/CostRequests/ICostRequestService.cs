using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostRequests;

namespace CostManagementSystem.Web.Services.CostRequests
{
    public interface ICostRequestService
    {
        Task<List<CostRequestReadOnlyVM>> GetCostRequestsAsync();

        Task CreateCostRequest(CostRequestCreateVM model);
        Task<EmployeeCostRequestListVM> GetEmployeeCostRequest();

        Task CancelCostRequest(int costRequestId);

        Task ReviewCostRequest(ReviewCostRequestVM model);

    }
}