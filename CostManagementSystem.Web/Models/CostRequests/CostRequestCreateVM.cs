using CostManagementSystem.Web.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostRequests
{
    public class CostRequestCreateVM
    {
        
        public string Name { get; set; }
        [DisplayName("Code Approval")]

        public CostCode? CostApproval { get; set; }
        public int? CostApprovalId { get; set; }
        [DisplayName("Code Date")]
        public DateOnly CostDate { get; set; }

        public SelectList CostApprovals { get; set; }

        public string? RequestComment { get; set; }
    }
}