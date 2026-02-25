using CostManagementSystem.Application.Models.Employee;
using CostManagementSystem.Data;

namespace CostManagementSystem.Application.Models.CostRequests;

public class ReviewCostRequestVM
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? CostCode { get; set; }
    public DateOnly CostDate { get; set; }
    public string? Project { get; set; }
    public string? Employee { get; set; }
    public string? Period { get; set; }
    public decimal Amount { get; set; }
    public decimal VAT { get; set; }
    public string? RequestComment { get; set; }
}