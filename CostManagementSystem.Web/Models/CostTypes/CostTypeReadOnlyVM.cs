using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostTypes
{
    public class CostTypeReadOnlyVM : BaseCostTypeVM
    {
        public string Name { get; set; } = string.Empty;
        
        [Display(Name = "Maximum Allocation of Days")] 
        public int Amount { get; set; }
    }
}
