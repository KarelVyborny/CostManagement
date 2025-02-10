using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostManagementSystem.Web.Data
{
    public class Cost
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        //public TypeOfCost Type { get; set; }//
        public DateOnly FinalDate { get; set; }

        public int Amount { get; set; }

    }
}
