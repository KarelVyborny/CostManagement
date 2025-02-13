using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostCodes
{
    public class CostCodeReadOnlyVM:BaseCostCodeVM
    {
        [Display(Name ="Cost Name")]
        public string CostName { get; set; } = string.Empty;
        [Display(Name = "Cost Group")]
        public string CostGroup { get; set; } = string.Empty;

    }
}
