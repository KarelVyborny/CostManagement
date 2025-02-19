using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.Employee;
using CostManagementSystem.Web.Models.Period;
using CostManagementSystem.Web.Models.Project;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostRequests
{
    public class CostRequestCreateVM:IValidatableObject
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
        public int? RequestorId { get; set; }// Foreign Key
        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        //public Status Status { get; set; } = Status.Pending;
        //public List<SelectListItem> CostCodes { get; set; } = new List<SelectListItem>(); // Dropdown options
        //public int CostRequestStatusId { get; set; }= 1;
        [Display(Name = "Additional Information")]
        public string? RequestComment { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (CostDate < DateOnly.FromDateTime(DateTime.Now))
            {
                yield return new ValidationResult("Cost Date cannot be in the past", new[] { nameof(CostDate) });
            }
            if (Amount <= 0)
            {
                yield return new ValidationResult("Amount must be greater than 0", new[] { nameof(Amount) });
            }
            if (VAT < 0)
            {
                yield return new ValidationResult("VAT must be greater than or equal to 0", new[] { nameof(VAT) });
            }
           
        }
    }
}