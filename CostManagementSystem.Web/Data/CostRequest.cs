using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace CostManagementSystem.Web.Data
{
    public class CostRequest:CostApproval
    {
      

        public CostRequestStatus? CostRequestStatus { get; set; }
        public int CostRequestStatusId { get; set; }
        
        public Employee RequestedBy { get; set; }
        public string RequestedById { get; set; } =default!;
        public Employee? ReviewedBy { get; set; }
        public string? ReviewedById { get; set; }


        public string? RequestComment { get; set; }

    }
}