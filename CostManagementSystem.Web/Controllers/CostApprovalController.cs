using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostCodes;
using CostManagementSystem.Web.Services.Cost_Approval_Workflow;
using CostManagementSystem.Web.Services.CostCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Web.Controllers;

public class CostApprovalController(ICostApprovalService _costApprovalService) : Controller
{
    public async Task<IActionResult> Index()
    {
       
        var view = await _costApprovalService.GetCostApprovalsAsync();
        return View(view);
    }

    public IActionResult Create()
    {
        ViewBag.StatusList = Enum.GetValues(typeof(Status))
                         .Cast<Status>()
                         .Select(e => new SelectListItem
                         {
                             Value = ((int)e).ToString(),
                             Text = e.ToString()
                         })
                         .ToList();

        ViewBag.CostCodes = new SelectList(new SelectList(Enum.GetValues(typeof(Status))));
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


        //if (ModelState.IsValid)
        //{
        //    await _costApprovalService.AddAsync(costApprovalCreate);
        //    return RedirectToAction(nameof(Index));
        //}
        //return View(costApprovalCreate);
        //{
        if (ModelState.IsValid)
        {
            var costApproval = new CostApproval
            {
                EmployeeId = costApprovalCreate.EmployeeId,
                CostCodeId = costApprovalCreate.CostCodeId,
                ProjectId = costApprovalCreate.ProjectId,
                PeriodId = costApprovalCreate.PeriodId,
                Amount = costApprovalCreate.Amount,
                CostDate = costApprovalCreate.CostDate,
                VAT = costApprovalCreate.VAT,
                Status = costApprovalCreate.Status  // Assign Enum Value
            };

            await _costApprovalService.AddAsync(costApprovalCreate);
            
            return RedirectToAction(nameof(Index));
        }

        // If model is invalid, reload dropdowns
        ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(Status)));

        return View(costApprovalCreate);
    }

}
