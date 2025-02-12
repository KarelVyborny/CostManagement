using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CostManagementSystem.Web.Data;

namespace CostManagementSystem.Web.Controllers
{
    public class CostCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CostCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CostCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CostCodes.ToListAsync());
        }

        // GET: CostCodes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costCode = await _context.CostCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costCode == null)
            {
                return NotFound();
            }

            return View(costCode);
        }

        // GET: CostCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CostCodes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CostName,CostGroup")] CostCode costCode)
        {
            if (ModelState.IsValid)
            {
                _context.Add(costCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var costCode = await _context.CostCodes.FindAsync(id);
            if (costCode == null)
            {
                return NotFound();
            }
            return View(costCode);
        }

        // POST: CostCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CostName,CostGroup")] CostCode costCode)
        {
            if (id != costCode.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CostCodeExists(costCode.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(costCode);
        }

        // GET: CostCodes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var costCode = await _context.CostCodes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (costCode == null)
            {
                return NotFound();
            }

            return View(costCode);
        }

        // POST: CostCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var costCode = await _context.CostCodes.FindAsync(id);
            if (costCode != null)
            {
                _context.CostCodes.Remove(costCode);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CostCodeExists(int id)
        {
            return _context.CostCodes.Any(e => e.Id == id);
        }
    }
}
