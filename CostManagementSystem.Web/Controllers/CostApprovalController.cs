using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostCodes;
using CostManagementSystem.Web.Services.Cost_Approval_Workflow;
using CostManagementSystem.Web.Services.CostCode;
using Microsoft.AspNetCore.Mvc;

namespace CostManagementSystem.Web.Controllers;

public class CostApprovalController(ICostApprovalService _costApprovalService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var employeeId = 1;
        var view = await _costApprovalService.GetCostApprovalsAsync(employeeId);
        return View(view);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CostApprovalCreateVM costApprovalCreate)
    {
        //var employeeId = 1;
        //await _costApprovalService.CostApproval(employeeId);
        //return RedirectToAction("Index");

        //if (await _costCodesService.CheckIfCostCodeExists(costCodeCreate.CostName))
        //{
        //    ModelState.AddModelError(nameof(CostCodeCreateVM.CostName), "Cost Code already exists");
        //}


        if (ModelState.IsValid)
        {
            await _costApprovalService.AddAsync(costApprovalCreate);
            return RedirectToAction(nameof(Index));
        }
        return View(costApprovalCreate);
    }

}
