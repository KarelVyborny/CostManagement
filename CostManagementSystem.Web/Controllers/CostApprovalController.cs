using CostManagementSystem.Application.Models.CostApproval;
using CostManagementSystem.Application.Models.CostCodes;
using CostManagementSystem.Application.Services.Cost_Approval_Workflow;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Application.Controllers;

public class CostApprovalController(ICostApprovalService _costApprovalService, ApplicationDbContext _context) : Controller
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

        ViewBag.EmployeeList = new SelectList(_context.Employees, "Id", "LastName");

        ViewBag.CostCodeList = new SelectList(_context.CostCodes, "Id", "CostName");
        ViewBag.ProjectList = new SelectList(_context.Projects, "Id", "ProjectName");
        ViewBag.PeriodList = new SelectList(_context.Periods, "Id", "Name");


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
        ViewBag.CostCodeList = new SelectList(_context.CostCodes, "Id", "CostName");

        return View(costApprovalCreate);
    }
    // GET: CostCodes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var costCode = await _costApprovalService.GetAsync<CostCodeReadOnlyVM>(id.Value);
        if (costCode == null)
        {
            return NotFound();
        }

        return View(costCode);
    }
    // GET: CostCodes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var costApproval = await _costApprovalService.GetAsync<CostApprovalEditVM>(id.Value);
        if (costApproval == null)
        {
            return NotFound();
        }

        return View(costApproval);


    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CostApprovalEditVM costApprovalEdit)
    {
        if (id != costApprovalEdit.Id)
        {
            return NotFound();
        }
        //if (await _costCodesService.CheckIfCostCodeExistsForEdit(costCodeEdit))
        //{
        //    ModelState.AddModelError(nameof(CostCodeEditVM.CostName), "Cost Code already exists");
        //}

        if (ModelState.IsValid)
        {
            try
            {
                await _costApprovalService.EditAsync(costApprovalEdit);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
                //if (!_costApprovalService.CostCodeExists(costApprovalEdit.Id))
                //{
                //    return NotFound();
                //}
                //else
                //{
                //    throw;
                //}
            }
            return RedirectToAction(nameof(Index));
        }
        return View(costApprovalEdit);
    }

    // GET: CostCodes/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var costApproval = await _costApprovalService.GetAsync<CostApprovalReadOnlyVM>(id.Value);
        if (costApproval == null)
        {
            return NotFound();
        }


        return View(costApproval);
    }
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {

        await _costApprovalService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task ReviewAsync(int id, bool isApproved)
    {
        var entity = await _context.CostApprovals.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null) throw new Exception("Cost approval not found");

        entity.Status = isApproved ? Status.Approved : Status.Rejected;

        await _context.SaveChangesAsync();
    }

}
