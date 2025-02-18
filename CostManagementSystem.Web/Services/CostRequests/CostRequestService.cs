using CostManagementSystem.Web.Models.CostRequests;

namespace CostManagementSystem.Web.Services.CostRequests
{
    public class CostRequestService : ICostRequestService

    {
        public Task CancelCostRequest(int costRequestId)
        {
            throw new NotImplementedException();
        }

        public Task CreateCostRequest(CostRequestCreateVM model)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeCostRequestListVM> GetEmployeeCostRequest()
        {
            throw new NotImplementedException();
        }

        public Task ReviewCostRequest(ReviewCostRequestVM model)
        {
            throw new NotImplementedException();
        }
    }
}
