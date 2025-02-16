using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Services.Cost_Approval_Workflow;
using Microsoft.AspNetCore.Mvc;

namespace CostManagementSystem.Web.Controllers
{
    public class CostApprovalController(ICostApprovalService _costApprovalService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var employeeId = 1;
            var view = await _costApprovalService.GetCostApprovalsAsync(employeeId);
            return View(view);
        }
    }
}
