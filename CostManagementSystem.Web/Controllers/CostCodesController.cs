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
using CostManagementSystem.Web.Services.CostCode;

namespace CostManagementSystem.Web.Controllers;

public class CostCodesController(ICostCodesService _costCodesService) : Controller
{
    //private readonly ICostCodesService _costCodesService = costCodesService;


    // GET: CostCodes
    public async Task<IActionResult> Index()
    {
        var viewdata = await _costCodesService.GetAllAsync();

        //var data = await _context.CostCodes.ToListAsync();
        //var viewData = data.Select(x => new IndexVM
        //{
        //    Id = x.Id,
        //    CostName = x.CostName,
        //    CostGroup = x.CostGroup
        //});
        return View(viewdata);
    }

    // GET: CostCodes/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var costCode = await _costCodesService.GetAsync<CostCodeReadOnlyVM>(id.Value);
        if (costCode == null)
        {
            return NotFound();
        }

        return View(costCode);
    }

    // GET: CostCodes/Create
    public IActionResult Create()
    {
        ViewBag.StatusList = new SelectList(Enum.GetValues(typeof(Status)));
        return View();
    }

    // POST: CostCodes/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    //public async Task<IActionResult> Create([Bind("Id,CostName,CostGroup")] CostCode costCode)
    public async Task<IActionResult> Create(CostCodeCreateVM costCodeCreate)
    {
        if (await _costCodesService.CheckIfCostCodeExists(costCodeCreate.CostName))
        {
            ModelState.AddModelError(nameof(CostCodeCreateVM.CostName), "Cost Code already exists");
        }


        if (ModelState.IsValid)
        {
            await _costCodesService.AddAsync(costCodeCreate);
            return RedirectToAction(nameof(Index));
        }
        return View(costCodeCreate);
    }



    // GET: CostCodes/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var costCode = await _costCodesService.GetAsync<CostCodeEditVM>(id.Value);
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
    public async Task<IActionResult> Edit(int id, CostCodeEditVM costCodeEdit)
    {
        if (id != costCodeEdit.Id)
        {
            return NotFound();
        }
        if (await _costCodesService.CheckIfCostCodeExistsForEdit(costCodeEdit))
        {
            ModelState.AddModelError(nameof(CostCodeEditVM.CostName), "Cost Code already exists");
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _costCodesService.EditAsync(costCodeEdit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_costCodesService.CostCodeExists(costCodeEdit.Id))
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

        var costCode = await _costCodesService.GetAsync<CostCodeReadOnlyVM>(id.Value);
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

        await _costCodesService.Remove(id);
        return RedirectToAction(nameof(Index));
    }

}

    

