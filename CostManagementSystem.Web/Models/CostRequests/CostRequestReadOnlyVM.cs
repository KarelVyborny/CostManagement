using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.Employee;
using CostManagementSystem.Web.Models.Period;
using CostManagementSystem.Web.Models.Project;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostManagementSystem.Web.Models.CostRequests
{

    public class CostRequestReadOnlyVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public CostCode? CostCode { get; set; }
        public int? CostCodeId { get; set; }
        public DateOnly CostDate { get; set; }

        public ProjectVM? Project { get; set; }
        public int? ProjectId { get; set; }

        public EmployeeVM? Employee { get; set; }
        public int? EmployeeId { get; set; }


        public PeriodVM? Period { get; set; }
        public int? PeriodId { get; set; }

        public decimal Amount { get; set; }
        public decimal VAT { get; set; }

        public CostRequestStatus? CostRequestStatus { get; set; }
        public int CostRequestStatusId { get; set; }

        public EmployeeVM Requestor { get; set; }
        public int? RequestorId { get; set; }
        public EmployeeVM? Reviewer { get; set; }
        public string? ReviewerId { get; set; }


        public string? RequestComment { get; set; }
        public List<SelectListItem> CostCodes { get; set; } = new List<SelectListItem>(); // Dropdown options
    }
}
