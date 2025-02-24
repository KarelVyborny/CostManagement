using CostManagementSystem.Application.Models.Projects;

namespace CostManagementSystem.Application.Services.Projects
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

