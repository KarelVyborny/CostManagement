using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCostRequestToCostApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostRequestId",
                table: "CostApprovals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovals_CostRequestId",
                table: "CostApprovals",
                column: "CostRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostApprovals_CostRequests_CostRequestId",
                table: "CostApprovals",
                column: "CostRequestId",
                principalTable: "CostRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostApprovals_CostRequests_CostRequestId",
                table: "CostApprovals");

            migrationBuilder.DropIndex(
                name: "IX_CostApprovals_CostRequestId",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "CostRequestId",
                table: "CostApprovals");
        }
    }
}
