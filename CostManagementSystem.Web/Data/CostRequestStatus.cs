using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Web.Data
{
    public class CostRequestStatus
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

    }
}