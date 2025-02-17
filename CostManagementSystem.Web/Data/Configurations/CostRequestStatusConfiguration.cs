using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CostManagementSystem.Web.Data.Configurations;

public class CostRequestStatusConfiguration : IEntityTypeConfiguration<CostRequestStatus>
{
    public void Configure(EntityTypeBuilder<CostRequestStatus> builder)
    {
        builder.HasData(
            new CostRequestStatus { Id = 1, Name = "Pending" },
            new CostRequestStatus { Id = 2, Name = "Approved" },
            new CostRequestStatus { Id = 3, Name = "Declined" },
            new CostRequestStatus { Id = 4, Name = "Canceled" }

);
    }
}
