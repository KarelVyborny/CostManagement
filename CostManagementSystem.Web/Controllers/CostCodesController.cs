using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostCodes;
using AutoMapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CostManagementSystem.Web.Controllers
{
    public class CostCodesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CostCodesController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        // GET: CostCodes
        public async Task<IActionResult> Index()
        {
            var data = await _context.CostCodes.ToListAsync();
            //var viewData = data.Select(x => new IndexVM
            //{
            //    Id = x.Id,
            //    CostName = x.CostName,
            //    CostGroup = x.CostGroup
            //});
            var viewdata=_mapper.Map<List<CostCodeReadOnlyVM>>(data);
            return View(viewdata);
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
            var viewdata = _mapper.Map<CostCodeReadOnlyVM>(costCode);

            return View(viewdata);
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
        //public async Task<IActionResult> Create([Bind("Id,CostName,CostGroup")] CostCode costCode)
        public async Task<IActionResult> Create(CostCodeCreateVM costCodeCreateVM)
        {
            if (ModelState.IsValid)
            {
                var costCode = _mapper.Map<CostCode>(costCodeCreateVM);
                _context.Add(costCode);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(costCodeCreateVM);
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
            var viewData = _mapper.Map<CostCodeEditVM>(costCode);
            return View(viewData);
        }

        // POST: CostCodes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CostCodeEditVM costCodeEdit )
        {
            if (id != costCodeEdit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var costCode = _mapper.Map<CostCode>(costCodeEdit);
                    _context.Update(costCode);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)`
                {
                    if (!CostCodeExists(costCodeEdit.Id))
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
            return View(costCodeEdit);
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
