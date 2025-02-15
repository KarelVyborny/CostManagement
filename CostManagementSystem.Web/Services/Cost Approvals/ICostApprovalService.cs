namespace CostManagementSystem.Web.Services.Cost_Approval_Workflow
{
    public interface ICostApprovalService
    {
        Task CostApproval(string employeeId);

    }
}