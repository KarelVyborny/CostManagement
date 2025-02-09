using CostManagementSystem.Web.Models.LeaveTypes;

namespace CostManagementSystem.Web.Services
{
    public interface ILeaveTypesService
    {
        Task<bool> CheckIfLeaveTypeNameExists(string name);
        Task<bool> CheckIfLeaveTypeNameExistsForEdit(CostTypeEditVM leaveTypeEdit);
        Task Create(CostTypeCreateVM model);
        Task Edit(CostTypeEditVM model);
        Task<T?> Get<T>(int id) where T : class;
        Task<List<CostTypeReadOnlyVM>> GetAll();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}