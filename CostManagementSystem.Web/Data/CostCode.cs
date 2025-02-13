using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Data
{
    public class CostCode
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string CostName { get; set; }

        public string CostGroup { get; set; }
    }
}
