namespace CostManagementSystem.Web.Models.CostCodes
{
    public class CostCodeReadOnlyVM
    {
        public int Id { get; set; }
        public string CostName { get; set; } = string.Empty;
        public string CostGroup { get; set; } = string.Empty;

    }
}
