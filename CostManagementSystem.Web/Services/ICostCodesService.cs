using CostManagementSystem.Web.Models.CostCodes;

namespace CostManagementSystem.Web.Services
{
    public interface ICostCodesService
    {
        Task AddAsync(CostCodeCreateVM costCodeCreate);
        Task<bool> CheckIfCostCodeExists(string name);
        Task<bool> CheckIfCostCodeExistsForEdit(CostCodeEditVM costCodeEdit);
        bool CostCodeExists(int id);
        Task EditAsync(CostCodeEditVM model);
        Task<List<CostCodeReadOnlyVM>> GetAllAsync();
        Task<T?> GetAsync<T>(int id) where T : class;
        Task Remove(int id);
    }
}