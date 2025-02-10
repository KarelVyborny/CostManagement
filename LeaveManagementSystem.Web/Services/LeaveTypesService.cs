using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostTypes;
using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Web.Services;

public class CostTypesService(ApplicationDbContext _context, IMapper _mapper) : ICostTypesService
{
    public async Task<List<CostTypeReadOnlyVM>> GetAll()
    {
        // var data = SELECT * FROM CostTypes
        var data = await _context.CostTypes.ToListAsync();
        // convert the datamodel into a view model - Use AutoMapper
        var viewData = _mapper.Map<List<CostTypeReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T?> Get<T>(int id) where T : class
    {
        var data = await _context.CostTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }

        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.CostTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (data != null)
        {
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(CostTypeEditVM model)
    {
        var leaveType = _mapper.Map<Cost>(model);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }

    public async Task Create(CostTypeCreateVM model)
    {
        var leaveType = _mapper.Map<Cost>(model);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }


    public bool LeaveTypeExists(int id)
    {
        return _context.CostTypes.Any(e => e.Id == id);
    }

    public async Task<bool> CheckIfLeaveTypeNameExists(string name)
    {
        var lowercaseName = name.ToLower();
        return await _context.CostTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName));
    }

    public async Task<bool> CheckIfLeaveTypeNameExistsForEdit(CostTypeEditVM leaveTypeEdit)
    {
        var lowercaseName = leaveTypeEdit.Name.ToLower();
        return await _context.CostTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercaseName)
            && q.Id != leaveTypeEdit.Id);
    }
}
