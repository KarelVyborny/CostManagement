using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostRequests;
using CostManagementSystem.Web.Services.Cost_Approval_Workflow;
using CostManagementSystem.Web.Services.CostCode;
using CostManagementSystem.Web.Services.CostRequests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Web.Controllers
{
    [Authorize]
    public class CostRequestController(ICostRequestService _costRequestService, ApplicationDbContext _context) : Controller
    {
        //View Request
        public async Task<IActionResult> Index()
        {
            var CostRequests = await _costRequestService.GetCostRequestsAsync();
            return View(CostRequests);
        }

        //Create request

        public async Task<IActionResult> Create()
        {
            var CostRequests = await _costRequestService.GetCostRequestsAsync();

            ViewBag.CostList = new SelectList(_context.CostCodes, "Id", "CostName");
            ViewBag.EmployeeList = new SelectList(_context.Employees.Select(e => new { Id = e.Id, FullName = e.FirstName + " " + e.LastName }), "Id", "FullName"); 
            ViewBag.EmployeeList2 = new SelectList(_context.Employees.Select(e => new { Id = e.Id, FullName = e.FirstName + " " + e.LastName }), "Id", "FullName");
            ViewBag.CostCodeList = new SelectList(_context.CostCodes, "Id", "CostName");
            ViewBag.ProjectList = new SelectList(_context.Projects, "Id", "ProjectName");
            ViewBag.PeriodList = new SelectList(_context.Periods, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CostRequestCreateVM model)
        {

            if (ModelState.IsValid)
            {
                await _costRequestService.CreateCostRequest(model);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.CostList = new SelectList(_context.CostCodes, "Id", "CostName");
            ViewBag.EmployeeList = new SelectList(_context.Employees.Select(e => new { Id = e.Id, FullName = e.FirstName + " " + e.LastName }), "Id", "FullName");
            ViewBag.EmployeeList2 = new SelectList(_context.Employees.Select(e => new { Id = e.Id, FullName = e.FirstName + " " + e.LastName }), "Id", "FullName");
            ViewBag.CostCodeList = new SelectList(_context.CostCodes, "Id", "CostName");
            ViewBag.ProjectList = new SelectList(_context.Projects, "Id", "ProjectName");
            ViewBag.PeriodList = new SelectList(_context.Periods, "Id", "Name");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            await _costRequestService.CancelCostRequest(id);
           
            //if (await _costCodesService.CheckIfCostCodeExistsForEdit(costCodeEdit))
            //{
            //    ModelState.AddModelError(nameof(CostCodeEditVM.CostName), "Cost Code already exists");
            //}

                return RedirectToAction(nameof(Index));

            
        }
        //admin
        public async Task<IActionResult> ListRequests()
        {
            var CostRequests = await _costRequestService.AdminGetEmployeeCostRequest();
            return View(CostRequests);
        }
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
