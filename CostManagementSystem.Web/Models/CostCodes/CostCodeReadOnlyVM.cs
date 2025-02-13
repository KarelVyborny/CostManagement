namespace CostManagementSystem.Web.Models.CostCodes
{
    public class CostCodeReadOnlyVM:BaseCostCodeVM
    {
    
        public string CostName { get; set; } = string.Empty;
        public string CostGroup { get; set; } = string.Empty;

    }
}
