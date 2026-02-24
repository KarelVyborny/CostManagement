using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Application.Models.CostRequests
{
    public class EmployeeCostRequestListVM
    {
        [Display(Name = "Total Requests")]
        public int TotalRequests { get; set; }
        [Display(Name = "Pending Requests")]
        public int PendingRequests { get; set; }
        [Display(Name = "Approved Requests")]
        public int ApprovedRequests { get; set; }
        [Display(Name = "Rejected Requests")]
        public int RejectedRequests { get; set; }
        [Display(Name = "Cost Requests")]
        public List<CostRequestReadOnlyVM> CostRequests { get; set; } = new List<CostRequestReadOnlyVM>();
        // TODO: doplnit další vlastnosti, které by mohly být užitečné pro zobrazení seznamu nákladových požadavků zaměstnance, např. filtrování podle období, projektu apod.

    }
}