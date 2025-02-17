using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using CostManagementSystem.Web.Models.CostApproval;
using CostManagementSystem.Web.Data.Configurations;

namespace CostManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
        public DbSet<CostApproval> CostApprovals { get; set; }
        public DbSet<CostCode> CostCodes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Period> Periods { get; set; }

        public DbSet<Project> Projects { get; set; }
        public DbSet<CostRequestStatus> CostRequestStatuses { get; set; }
        public DbSet<CostRequest> CostRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data for Employees Table
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" },
                new Employee { Id = 3, FirstName = "Alice", LastName = "Johnson" }
            );
            modelBuilder.Entity<CostCode>().HasData(
                new CostCode { Id = 1, CostName = "Construction", CostGroup = "Construction" },
                new CostCode { Id = 2, CostName = "Engineering", CostGroup = "Engineering" },
                new CostCode { Id = 3, CostName = "IT Services", CostGroup = "IT" }
            );
            modelBuilder.Entity<Project>().HasData(
       new Project { Id = 1, ProjectName = "Project 1" },
       new Project { Id = 2, ProjectName = "Project 2" },
       new Project { Id = 3, ProjectName = "Project 3" }  // No manager assigned
   );

            modelBuilder.Entity<Period>().HasData(
                new Period { Id = 1, Name = "Year 2020", StartDate = new DateOnly(2020, 1, 1), EndDate = new DateOnly(2020, 12, 31) },
                new Period { Id = 2, Name = "Year 2021", StartDate = new DateOnly(2021, 1, 1), EndDate = new DateOnly(2021, 12, 31) },
                new Period { Id = 3, Name = "Year 2022", StartDate = new DateOnly(2022, 1, 1), EndDate = new DateOnly(2022, 12, 31) },
                new Period { Id = 4, Name = "Year 2023", StartDate = new DateOnly(2023, 1, 1), EndDate = new DateOnly(2023, 12, 31) },
                new Period { Id = 5, Name = "Year 2024", StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 12, 31) },
                new Period { Id = 6, Name = "Year 2025", StartDate = new DateOnly(2025, 1, 1), EndDate = new DateOnly(2025, 12, 31) }
            );

            modelBuilder.ApplyConfiguration(new CostRequestStatusConfiguration());
        }
        public DbSet<CostManagementSystem.Web.Models.CostApproval.CostApprovalEditVM> CostApprovalEditVM { get; set; } = default!;
        public DbSet<CostManagementSystem.Web.Models.CostApproval.CostApprovalReadOnlyVM> CostApprovalReadOnlyVM { get; set; } = default!;
        //public DbSet<CostManagementSystem.Web.Models.CostApproval.CostApprovalCreateVM> CostApprovalCreateVM { get; set; } = default!;
        //public DbSet<CostManagementSystem.Web.Models.CostApproval.CostApprovalReadOnlyVM> CostApprovalReadOnlyVM { get; set; } = default!;


    }
}
