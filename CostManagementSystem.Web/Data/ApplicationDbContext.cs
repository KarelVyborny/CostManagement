using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Xml;

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
        public DbSet<CostCode> CostCodes { get; set; }
        public DbSet<CostApproval> Costs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Period> Periods { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data for Employees Table
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, FirstName = "John", LastName = "Doe" },
                new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" },
                new Employee { Id = 3, FirstName = "Alice", LastName = "Johnson" }
            );
       
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Period>().HasData(
                new Period { Id = 1, Name = "Year 2020", StartDate = new DateOnly(2020, 1, 1), EndDate = new DateOnly(2020, 12, 31) },
                new Period { Id = 2, Name = "Year 2021", StartDate = new DateOnly(2021, 1, 1), EndDate = new DateOnly(2021, 12, 31) },
                new Period { Id = 3, Name = "Year 2022", StartDate = new DateOnly(2022, 1, 1), EndDate = new DateOnly(2022, 12, 31) },
                new Period { Id = 4, Name = "Year 2023", StartDate = new DateOnly(2023, 1, 1), EndDate = new DateOnly(2023, 12, 31) },
                new Period { Id = 5, Name = "Year 2024", StartDate = new DateOnly(2024, 1, 1), EndDate = new DateOnly(2024, 12, 31) },
                new Period { Id = 6, Name = "Year 2025", StartDate = new DateOnly(2025, 1, 1), EndDate = new DateOnly(2025, 12, 31) }
            );
        }


    }
}
