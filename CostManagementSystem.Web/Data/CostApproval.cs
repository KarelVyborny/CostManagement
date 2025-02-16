using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostManagementSystem.Web.Data
{
    public class CostApproval
    {
        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        public CostCode? CostCode { get; set; }
        public int CostCodeId { get; set; }
        public DateOnly CostDate { get; set; }

        public Project? Project { get; set; }
        public int ProjectId { get; set; }

        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }


        public Period? Period { get; set; }
        public int PeriodId { get; set; }

        public double Amount { get; set; }
        public double VAT { get; set; }
        public Status Status { get; set; } = Status.Pending;
    }

    public enum Status
    {
        Pending,
        Approved,
        Rejected
    }
}
