namespace CostManagementSystem.Web.Data
{
    public class Project
    {
        public int Id { get; set; }
        public required string ProjectName { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public Employee? ProjectManager  { get; set; }
    }
}