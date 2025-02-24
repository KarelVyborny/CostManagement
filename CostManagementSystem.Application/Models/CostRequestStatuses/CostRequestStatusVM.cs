using System.ComponentModel.DataAnnotations;

namespace CostManagementSystem.Application.Models.CostRequestStatuses
{
    public class CostRequestStatusVM
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }


    }
}
