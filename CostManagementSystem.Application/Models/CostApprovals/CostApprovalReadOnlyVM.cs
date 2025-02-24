using CostManagementSystem.Application.Models.CostCodes;
using CostManagementSystem.Application.Models.Employee;
using CostManagementSystem.Application.Models.Period;
using CostManagementSystem.Application.Models.Projects;
using CostManagementSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Application.Models.CostApproval
{
    public class CostApprovalReadOnlyVM
    {
        public int Id { get; set; }
        [Display(Name = "Approval")]
        public string Name { get; set; }
        //public CostCode? CostCode { get; set; }
        [Display(Name = "Cost date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}")]
        public DateOnly CostDate { get; set; }

        //public Project Project { get; set; }

        //public Employee Employee { get; set; }


        //public Period Period { get; set; }

        public decimal Amount { get; set; }
        public decimal VAT { get; set; }
        public Status Status { get; set; }

        public PeriodVM Period { get; set; } = new PeriodVM();
        public ProjectVM Project { get; set; } = new ProjectVM();
        public EmployeeVM Employee { get; set; } = new EmployeeVM();
        public CostCodeReadOnlyVM CostCode { get; set; } = new CostCodeReadOnlyVM();


    }
}