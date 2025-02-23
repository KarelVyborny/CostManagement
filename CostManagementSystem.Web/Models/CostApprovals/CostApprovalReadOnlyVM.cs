using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostCodes;
using CostManagementSystem.Web.Models.Employee;
using CostManagementSystem.Web.Models.Period;
using CostManagementSystem.Web.Models.Project;
using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostApproval
{
    public class CostApprovalReadOnlyVM
    {
        public int Id { get; set; }
        [Display(Name = "Approval")]
        public string Name { get; set; }
        //public CostCode? CostCode { get; set; }
        [Display(Name="Cost date")]
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