using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
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
    public async Task CostApproval(int employeeId)
    {
        var currentDate = DateTime.Now;
      ; 
        var CostCode = await _context.CostCodes.ToListAsync();
        var period = _context.Periods.SingleAsync(q=>q.EndDate.Year == currentDate.Year);

        foreach (var item in CostCode)
        {
            var costApproval = new CostApproval
            {
                CostCodeId = item.Id,
                PeriodId = period.Id,
                EmployeeId = employeeId,
                Status = Status.Pending,
                CostDate = DateOnly.FromDateTime(currentDate)
            };
            _context.Add(costApproval);
            await _context.SaveChangesAsync();
        }

    }

    public Task CostApproval(string employeeId)
    {
        throw new NotImplementedException();
    }

    public async Task <List<CostApprovalReadOnlyVM>> GetCostApprovalsAsync(int employeeId)
    {
        var data = await _context.CostApprovals
            .Include(q=>q.CostCode)
            .Include(q => q.Period)
            .Include(q => q.Employee)
            .Where(x => x.EmployeeId == employeeId)
            .ToListAsync();
        var viewdata =  _mapper.Map<List<CostApproval>,List<CostApprovalReadOnlyVM>>(data);
        return viewdata;
    }
}
