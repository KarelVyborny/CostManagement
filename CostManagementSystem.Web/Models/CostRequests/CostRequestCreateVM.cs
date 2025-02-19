using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.Employee;
using CostManagementSystem.Web.Models.Period;
using CostManagementSystem.Web.Models.Project;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostRequests
{
    public class CostRequestCreateVM
    {
        public string Name { get; set; }

        [DisplayName("Code Date")]

        public DateOnly CostDate { get; set; }
        [DisplayName("Code Code")]

        public CostCode? CostCode { get; set; }
        public int? CostCodeId { get; set; } // Foreign Key
        public ProjectVM? Project { get; set; }
        public int? ProjectId { get; set; } // Foreign Key
        public EmployeeVM? Employee { get; set; }
        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; } // Foreign Key  

        public PeriodVM? Period { get; set; } // Foreign Key
        [Display(Name = "Period")]
        public int? PeriodId { get; set; }
        public EmployeeVM? Requestor { get; set; }
        public int? RequestorId { get; set; }
      

        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public Status Status { get; set; } = Status.Pending;

        //public List<SelectListItem> CostCodes { get; set; } = new List<SelectListItem>(); // Dropdown options
        public int CostRequestStatusId { get; set; }= 1;
      
   

        public string? RequestComment { get; set; }
    }
}