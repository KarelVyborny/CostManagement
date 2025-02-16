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
        public string Name { get; set; }
        //public CostCode? CostCode { get; set; }
      
        public DateOnly CostDate { get; set; }

        //public Project Project { get; set; }
       
        //public Employee Employee { get; set; }
     

        //public Period Period { get; set; }
       
        public double Amount { get; set; }
        public double VAT { get; set; }
        public Status Status { get; set; }

        public PeriodVM Period { get; set; } = new PeriodVM();
        public ProjectVM Project { get; set; } = new ProjectVM();
        public EmployeeVM Employee { get; set; } = new EmployeeVM();
        public CostCodeReadOnlyVM CostCodeVM { get; set; } = new CostCodeReadOnlyVM();


    }
}