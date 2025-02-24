using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Application.Controllers
{
    public class EmployeesController(ApplicationDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await _context.Employees.ToListAsync());

        }
    }
}
