using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostCodes;
using CostManagementSystem.Web.Services.CostCode;
using Microsoft.EntityFrameworkCore;
using System;
using static CostManagementSystem.Web.Data.CostApproval;

namespace CostManagementSystem.Web.Services.Cost_Approval_Workflow;

public class CostApprovalService(ApplicationDbContext _context, IMapper _mapper) : ICostApprovalService
{
    //public async Task<List<CostApprovalVM>> GetAllAsync()
    //{
    //    var data = await _context.CostApprovals.ToListAsync();
    //    var viewdata = _mapper.Map<List<CostApprovalVM>>(data);
    //    return viewdata;


    //}
    //public async Task<T?> GetAsync<T>(int id) where T : class
    //{
    //    var data = await _context.CostApprovals.FirstOrDefaultAsync(x => x.Id == id);
    //    if (data == null)
    //    {
    //        return null;
    //    }
    //    var viewdata = _mapper.Map<T>(data);
    //    return viewdata;
    //}

    //public interface ICostApprovalService
    //{
    //    Task<List<CostApprovalVM>> GetAllAsync();
    //}   
    public async Task CostApproval()
    {
        var currentDate = DateTime.Now;
      ; 
        var CostApproval = await _context.CostApprovals.ToListAsync();
        var period = _context.Periods.SingleAsync(q=>q.EndDate.Year == currentDate.Year);

        foreach (var item in CostApproval)
        {
            var costApproval = new CostApproval
            {
                CostCodeId = item.Id,
                PeriodId = period.Id,
                Status = Status.Pending,
                CostDate = DateOnly.FromDateTime(currentDate)
            };
            _context.Add(costApproval);
            await _context.SaveChangesAsync();
        }

    }

 

    public async Task <List<CostApprovalReadOnlyVM>> GetCostApprovalsAsync()
    {
        var data = await _context.CostApprovals
            .Include(q=>q.CostCode)
            .Include(q => q.Period)
            .Include(q => q.Employee)
            .Include(q => q.Project)
            .ToListAsync();
        var viewdata =  _mapper.Map<List<CostApproval>,List<CostApprovalReadOnlyVM>>(data);
        return viewdata;
    }

    public async Task AddAsync(CostApprovalCreateVM costApprovalCreate)
    {
        var data = _mapper.Map<CostApproval>(costApprovalCreate);
        _context.Add(data);
        await _context.SaveChangesAsync();
    }
    public async Task<T?> GetAsync<T>(int id) where T : class
    {
        var data = await _context.CostApprovals.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewdata = _mapper.Map<T>(data);
        return viewdata;

    }
    public async Task EditAsync(CostApprovalEditVM model)
    {
        var CostApproval = _mapper.Map<CostApproval>(model);
        _context.Update(CostApproval);
        await _context.SaveChangesAsync();
    }
    public async Task Remove(int id)
    {
        var data = await _context.CostApprovals.FirstOrDefaultAsync(x => x.Id == id);
        if (data == null)
        {
            return;
        }
        _context.Remove(data);
        await _context.SaveChangesAsync();
    }
}
