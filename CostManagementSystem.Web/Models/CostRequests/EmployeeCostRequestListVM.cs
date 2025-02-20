namespace CostManagementSystem.Web.Models.CostRequests
{
    public class EmployeeCostRequestListVM
    {
        public int TotalRequests { get; set; }
        public int PendingRequests { get; set; }
        public int ApprovedRequests { get; set; }
        public int RejectedRequests { get; set; }

        public List<CostRequestReadOnlyVM> CostRequests { get; set; } = new List<CostRequestReadOnlyVM>();


    }
}