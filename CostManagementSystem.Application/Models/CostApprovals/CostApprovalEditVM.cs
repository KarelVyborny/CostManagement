using CostManagementSystem.Application.Models.Employee;
using CostManagementSystem.Application.Models.Period;
using CostManagementSystem.Application.Models.Projects;
using CostManagementSystem.Data;

namespace CostManagementSystem.Application.Models.CostApproval
{
    public class CostApprovalEditVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
        //public CostCode? CostCode { get; set; }

        public DateOnly CostDate { get; set; }
        public CostCode? CostCode { get; set; }
        public int? CostCodeId { get; set; } // Foreign Key
        public ProjectVM? Project { get; set; }
        public int? ProjectId { get; set; } // Foreign Key
        public EmployeeVM? Employee { get; set; }
        public int? EmployeeId { get; set; } // Foreign Key  

        public PeriodVM? Period { get; set; } // Foreign Key
        public int? PeriodId { get; set; }

        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public Status Status { get; set; } = Status.Pending;

        //public List<SelectListItem> CostCodes { get; set; } = new List<SelectListItem>(); // Dropdown options

        //public PeriodVM Period { get; set; } = new PeriodVM();
        //public ProjectVM Project { get; set; } = new ProjectVM();
        //public EmployeeVM Employee { get; set; } = new EmployeeVM();
        //public CostCodeReadOnlyVM CostCodeVM { get; set; } = new CostCodeReadOnlyVM();




    }
}