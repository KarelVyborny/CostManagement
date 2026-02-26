using CostManagementSystem.Application.Models.CostRequests;
using CostManagementSystem.Application.Services.Cost_Approval_Workflow;
using CostManagementSystem.Application.Services.CostRequests;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Application.Controllers
{
    public class CostRequestController(
        ICostRequestService _costRequestService,
        ICostApprovalService _costApprovalService,
        ApplicationDbContext _context) : Controller
    {
        //View Request
        public async Task<IActionResult> Index()
        {
            var CostRequests = await _costRequestService.GetCostRequestsAsync();
            return View(CostRequests);
        }


[HttpGet]
public async Task<IActionResult> Review(int id)
{
    var req = await _context.CostRequests
        .Include(x => x.CostCode)
        .Include(x => x.Project)
        .Include(x => x.Employee)
        .Include(x => x.Period)
        .FirstOrDefaultAsync(x => x.Id == id);

    if (req == null)
        return NotFound($"CostRequest not found, id={id}");

    // pokud máš už vazbu CostApproval.CostRequestId po migraci
    var approval = await _context.CostApprovals
        .FirstOrDefaultAsync(a => a.CostRequestId == id);

            // naplň svůj ReviewCostRequestVM (uprav názvy polí podle VM)
            var vm = new ReviewCostRequestVM
            {
                Id = req.Id,
                Name = req.Name,
                CostCode = req.CostCode?.CostName,
                CostDate = req.CostDate,
                Project = req.Project?.ProjectName,
                Employee = req.Employee == null ? null : $"{req.Employee.FirstName} {req.Employee.LastName}",
                Period = req.Period?.Name,
                Amount = req.Amount,
                VAT = req.VAT
            };

            return View(vm);
}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Review(int costRequestId, bool isApproved)
        {
            var approval = await _context.CostApprovals
                .FirstOrDefaultAsync(x => x.CostRequestId == costRequestId);

            if (approval == null)
            {
                var req = await _context.CostRequests
                    .FirstOrDefaultAsync(x => x.Id == costRequestId);

                if (req == null) return NotFound();

                approval = new CostApproval
                {
                    CostRequestId = req.Id,
                    Name = req.Name,
                    CostCodeId = req.CostCodeId,
                    ProjectId = req.ProjectId,
                    EmployeeId = req.EmployeeId,
                    PeriodId = req.PeriodId,
                    CostDate = req.CostDate,
                    Amount = req.Amount,
                    VAT = req.VAT,
                    Status = Status.Pending
                };

                _context.CostApprovals.Add(approval);
            }

            // 🔹 1) nastav Approval status
            approval.Status = isApproved ? Status.Approved : Status.Rejected;

            // 🔹 2) aktualizuj i CostRequestStatusId (TOHLE JE DŮLEŽITÉ)
            var request = await _context.CostRequests
                .FirstOrDefaultAsync(x => x.Id == costRequestId);

            if (request != null)
            {
                request.CostRequestStatusId = isApproved
                    ? (int)CostRequestStatusEnum.Approved
                    : (int)CostRequestStatusEnum.Rejected;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(ListRequests));
        }// nebo Index
        
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
        public async Task<IActionResult> ListRequests(string sortOrder)
        {
            //ViewData["NameSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["ProjectSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["EmployeeSort"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSort"] = sortOrder == "date" ? "date_desc" : "date";
            //ViewData["AmountSort"] = sortOrder == "amount" ? "amount_desc" : "amount";

            var model = await _costRequestService.AdminGetEmployeeCostRequest(sortOrder);
            return View(model);
        }
        
        public IActionResult Approve(int CostRequestId)
        {
            return View();
        }
        public IActionResult Reject(int CostRequestId)
        {
            return View();
        }
        //public async Task<IActionResult> Review(int id)
        //{
        //    var model = await _costRequestService.GetCostRequestForReview(id);
        //    return View(model);
        //}
        
    }
}
