using CostManagementSystem.Web.Models.Cost;

namespace CostManagementSystem.Web.Services
{
    public interface ICostsService
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(CostEditVM leaveTypeEdit);
        Task Create(CostCreateVM model);
        Task Edit(CostEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<CostReadOnlyVM>> GetAll();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}