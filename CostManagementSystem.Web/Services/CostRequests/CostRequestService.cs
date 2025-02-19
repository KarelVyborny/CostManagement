﻿using AutoMapper;
using CostManagementSystem.Web.Data;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Models.CostRequests;
using Microsoft.EntityFrameworkCore;

namespace CostManagementSystem.Web.Services.CostRequests
{
    public class CostRequestService(ApplicationDbContext _context, IMapper _mapper) : ICostRequestService

    {
        public async Task<List<CostRequestReadOnlyVM>> GetCostRequestsAsync()
        {
            var currentDate = DateTime.Now;

            //var CostApproval = await _context.CostRequests.ToListAsync();
            //var period = _context.Periods.SingleAsync(q => q.EndDate.Year == currentDate.Year);


            var data = await _context.CostRequests
           .Include(q => q.CostCode)
           .Include(q => q.Period)
           .Include(q => q.Employee)
           .Include(q => q.Project)
           .Include(q => q.CostRequestStatus)
           .ToListAsync();
            var viewdata = _mapper.Map<List<CostRequest>, List<CostRequestReadOnlyVM>>(data);
            return viewdata;
        }
        public async Task CancelCostRequest (int costRequestId)
        {
            if (costRequestId == 0)
            {
                return;
            }
            var costRequest = await _context.CostRequests.FindAsync(costRequestId);
            costRequest.CostRequestStatusId=(int)CostRequestStatusEnum.Canceled;
            _context.Update(costRequest);
            await _context.SaveChangesAsync();
        }
      

        public async Task CreateCostRequest(CostRequestCreateVM model)
        {
            var data = _mapper.Map<CostRequest>(model);
            data.CostRequestStatusId = (int)CostRequestStatusEnum.Pending;
            _context.Add(data);
            await _context.SaveChangesAsync();
        }

        public Task<EmployeeCostRequestListVM> GetEmployeeCostRequest()
        {
            throw new NotImplementedException();
        }

        public Task ReviewCostRequest(ReviewCostRequestVM model)
        {
            throw new NotImplementedException();
        }

     

    }
}
