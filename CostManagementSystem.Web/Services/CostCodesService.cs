using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostCodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CostManagementSystem.Web.Services;

public class CostCodesService(ApplicationDbContext _context, IMapper _mapper) : ICostCodesService
{
    //private readonly ApplicationDbContext _context= context;
    //private readonly IMapper _mapper= mapper;

    public async Task<List<CostCodeReadOnlyVM>> GetAllAsync()
    {
        var data = await _context.CostCodes.ToListAsync();
        var viewdata = _mapper.Map<List<CostCodeReadOnlyVM>>(data);
        return viewdata;
    }

    public async Task<T?> GetAsync<T>(int id) where T : class
    {
        var data = await _context.CostCodes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewdata = _mapper.Map<T>(data);
        return viewdata;

    }
    public async Task Remove(int id)
    {
        var data = await _context.CostCodes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return;
        }
        _context.Remove(data);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(CostCodeEditVM model)
    {
        var CostCode = _mapper.Map<CostCode>(model);
        _context.Update(CostCode);
        await _context.SaveChangesAsync();
    }

    public async Task AddAsync(CostCodeCreateVM costCodeCreate)
    {
        var data = _mapper.Map<CostCode>(costCodeCreate);
        _context.Add(data);
        await _context.SaveChangesAsync();
    }

    public bool CostCodeExists(int id)
    {
        return _context.CostCodes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfCostCodeExists(string name)
    {
        //return _context.CostCodes.Any(q => q.CostName.Equals(name,StringComparison.InvariantCultureIgnoreCase));

        return await _context.CostCodes.AnyAsync(q => q.CostName.ToLower().Equals(name.ToLower()));
    }

    public async Task<bool> CheckIfCostCodeExistsForEdit(CostCodeEditVM costCodeEdit)
    {
        //return _context.CostCodes.Any(q => q.CostName.Equals(name,StringComparison.InvariantCultureIgnoreCase));

        return await _context.CostCodes.AnyAsync(q => q.CostName.ToLower().Equals(costCodeEdit.CostName.ToLower()) && q.Id != costCodeEdit.Id);
    }
}

