using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Application.Models.CostCodes
{
    public class CostCodeCreateVM
    {
        [Required]
        [Length(4, 100, ErrorMessage = "length violated")]
        public string CostName { get; set; } = string.Empty;
        [Required]
        public string CostGroup { get; set; } = string.Empty;

    }
}
