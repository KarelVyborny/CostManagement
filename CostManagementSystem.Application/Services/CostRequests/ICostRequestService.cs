using CostManagementSystem.Application.Models.CostRequests;
using Microsoft.Data.SqlClient;

namespace CostManagementSystem.Application.Services.CostRequests
{
    public interface ICostRequestService
    {
        Task<List<CostRequestReadOnlyVM>> GetCostRequestsAsync();

        Task CreateCostRequest(CostRequestCreateVM model);

        Task CancelCostRequest(int costRequestId);

        Task<EmployeeCostRequestListVM> AdminGetEmployeeCostRequest(string sortOrder);
        Task<ReviewCostRequestVM> GetCostRequestForReview(int id);
        Task ReviewCostRequest(int costRequestId, bool approved);
    }
}