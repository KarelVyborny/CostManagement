using CostManagementSystem.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Web.Controllers
{
    public class EmployeesController (ApplicationDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());
            
        }
    }
}
