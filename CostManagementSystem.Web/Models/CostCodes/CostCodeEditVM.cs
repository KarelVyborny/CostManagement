using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostCodes
{
    public class CostCodeEditVM: BaseCostCodeVM
    {

        [Required]
        [Display(Name = "Cost Name")]
        [Length(4, 100, ErrorMessage = "length violated")]
        public string CostName { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Cost Group")]
        public string CostGroup { get; set; } = string.Empty;

    }
}
