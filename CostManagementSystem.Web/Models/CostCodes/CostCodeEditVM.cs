using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Models.CostCodes
{
    public class CostCodeEditVM: BaseCostCodeVM
    {

        [Required]
        [Length(4, 100, ErrorMessage = "length violated")]
        public string CostName { get; set; } = string.Empty;
        [Required]
        public string CostGroup { get; set; } = string.Empty;

    }
}
