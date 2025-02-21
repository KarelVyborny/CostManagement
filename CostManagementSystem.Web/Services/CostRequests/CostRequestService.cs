using AutoMapper;
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
            costRequest.CostRequestStatusId=(int)CostRequestStatusEnum.Canceled;//tracking
            //_context.Update(costRequest);
            await _context.SaveChangesAsync();
        }
      

        public async Task CreateCostRequest(CostRequestCreateVM model)
        {
            var data = _mapper.Map<CostRequest>(model);
            data.CostRequestStatusId = (int)CostRequestStatusEnum.Pending;
            _context.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task<EmployeeCostRequestListVM> AdminGetEmployeeCostRequest()
        {
           var costRequest = await _context.CostRequests
                .Include(q => q.CostCode)
                .Include(q => q.Period)
                .Include(q => q.Employee)
                .Include(q => q.Project)
                .Include(q => q.CostRequestStatus)
                .ToListAsync();



            var viewdata = _mapper.Map<List<CostRequest>, List<CostRequestReadOnlyVM>>(costRequest);
            var model = new EmployeeCostRequestListVM
            {
                TotalRequests = viewdata.Count,
                PendingRequests = viewdata.Count(q => q.CostRequestStatusId == (int)CostRequestStatusEnum.Pending),
                ApprovedRequests = viewdata.Count(q => q.CostRequestStatusId == (int)CostRequestStatusEnum.Approved),
                RejectedRequests = viewdata.Count(q => q.CostRequestStatusId == (int)CostRequestStatusEnum.Rejected),
                CostRequests = viewdata
            };
            return model;
        }

        public async Task<ReviewCostRequestVM> GetCostRequestForReview (int id)
        {
            var costRequest = await _context.CostRequests
               .Include(q => q.CostCode)
                .Include(q => q.Period)
                .Include(q => q.Employee)
                .Include(q => q.Project)
                .Include(q => q.CostRequestStatus)
             .FirstAsync(q => q.Id == id);

            var model = new ReviewCostRequestVM
            {
                Id = costRequest.Id,
                Name = costRequest.Name,
                CostCodeId = costRequest.CostCodeId,
                CostDate = costRequest.CostDate,
                ProjectId = costRequest.ProjectId,
                EmployeeId = costRequest.EmployeeId,
                PeriodId = costRequest.PeriodId,
                Amount = costRequest.Amount,
                VAT = costRequest.VAT,
                CostRequestStatusId = costRequest.CostRequestStatusId,
                RequestorId = costRequest.RequestorId,
                ReviewerId = costRequest.ReviewerId,
                RequestComment = costRequest.RequestComment
            };
            return model;
        }
        public async Task ReviewCostRequest (int costRequestId, bool approved)
        {
           var costRequest = await _context.CostRequests.FindAsync(costRequestId);
            if (approved)
            {
                costRequest.CostRequestStatusId = (int)CostRequestStatusEnum.Approved;
                costRequest.ReviewerId = 1;
            }
            else
            {
                costRequest.CostRequestStatusId = (int)CostRequestStatusEnum.Rejected;
            }
            await _context.SaveChangesAsync();  
                     
           
        }
      

    }
}
