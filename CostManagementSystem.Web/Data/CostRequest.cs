using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace CostManagementSystem.Web.Data
{
    public class CostRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CostCode? CostCode { get; set; }
        public int? CostCodeId { get; set; }
        public DateOnly CostDate { get; set; }

        public Project? Project { get; set; }
        public int? ProjectId { get; set; }

        public Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }


        public Period? Period { get; set; }
        public int? PeriodId { get; set; }

        public decimal Amount { get; set; }
        public decimal VAT { get; set; }

        public CostRequestStatus? CostRequestStatus { get; set; }
        public int CostRequestStatusId { get; set; }
        
        public Employee? Requestor { get; set; }
        public int? RequestorId { get; set; } 
        public Employee? Reviewer { get; set; }
        public int? ReviewerId { get; set; }


        public string? RequestComment { get; set; }

    }
}