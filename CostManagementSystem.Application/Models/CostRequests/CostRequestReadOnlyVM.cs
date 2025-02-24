using CostManagementSystem.Application.Models.CostRequestStatuses;
using CostManagementSystem.Application.Models.Employee;
using CostManagementSystem.Application.Models.Period;
using CostManagementSystem.Application.Models.Projects;
using CostManagementSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Application.Models.CostRequests
{

    public class CostRequestReadOnlyVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Cost Code")]
        public CostCode? CostCode { get; set; }
        public int? CostCodeId { get; set; }
        [Display(Name = "Cost Date")]
        public DateOnly CostDate { get; set; }

        public ProjectVM? Project { get; set; }
        [Display(Name = "Project")]
        public int? ProjectId { get; set; }
        public EmployeeVM? Employee { get; set; }
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }


        public PeriodVM? Period { get; set; }
        [Display(Name = "Period")]
        public int? PeriodId { get; set; }

        public decimal Amount { get; set; }
        public decimal VAT { get; set; }

        public CostRequestStatusVM? CostRequestStatus { get; set; }
        [Display(Name = "Status")]
        public int CostRequestStatusId { get; set; }

        public EmployeeVM Requestor { get; set; }
        [Display(Name = "Requestor")]
        public int? RequestorId { get; set; }
        public EmployeeVM? Reviewer { get; set; }
        [Display(Name = "Reviewer")]
        public int? ReviewerId { get; set; }

        [Display(Name = "Additional Information")]
        public string? RequestComment { get; set; }
        //public List<SelectListItem> CostCodes { get; set; } = new List<SelectListItem>(); // Dropdown options

    }
}
