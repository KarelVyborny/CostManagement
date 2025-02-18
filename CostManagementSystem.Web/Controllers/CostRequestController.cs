using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostRequests;
using CostManagementSystem.Web.Services.Cost_Approval_Workflow;
using CostManagementSystem.Web.Services.CostCode;
using CostManagementSystem.Web.Services.CostRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CostManagementSystem.Web.Controllers
{
    [Authorize]
    public class CostRequestController (ICostApprovalService _costApprovalService) : Controller
    {
        //View Request
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //Create request

        public async Task<IActionResult> Create()
        {
            var costApprovals = await _costApprovalService.GetCostApprovalsAsync();
            var CostsList = new SelectList(costApprovals,"Id","Name");
            var model = new CostRequestCreateVM
            {
                CostDate = DateOnly.FromDateTime(DateTime.Now),
                CostApprovals = CostsList,

            };

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CostRequestCreateVM model)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cancel(int CostRequestId)
        {
            return View();
        }
        //admin
        public IActionResult Approve(int CostRequestId)
        {
            return View();
        }
        public IActionResult Reject(int CostRequestId)
        {
            return View();
        }
        public IActionResult Review(int CostRequestId)
        {
            return View();
        }

    }
}
