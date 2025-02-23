using CostManagementSystem.Web.Services.Projects;

using CostManagementSystem.Web.Models.Projects;

namespace CostManagementSystem.Web.Services.Projects
{
    public interface IProjectService
    {
        Task AddAsync(ProjectVM Project);
        //Task<bool> CheckIfCostCodeExists(string name);
        //Task<bool> CheckIfCostCodeExistsForEdit(CostCodeEditVM costCodeEdit);
        //bool CostCodeExists(int id);
        //Task EditAsync(CostCodeEditVM model);
        Task<List<ProjectVM>> GetAllAsync();
        //Task<T?> GetAsync<T>(int id) where T : class;
        //Task Remove(int id);
    }
}

