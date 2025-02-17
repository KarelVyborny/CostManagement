namespace CostManagementSystem.Web.Data
{
    public class Project
    {
        public int Id { get; set; }
        public  string ProjectName { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

       //public Employee? ProjectManager  { get; set; }

        //public int? ProjectManagerId { get; set; }
        //public Employee? ProjectManager { get; set; }

    }
}