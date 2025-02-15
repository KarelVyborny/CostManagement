using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingCostApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Employee_EmployeeId1",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_EmployeeId1",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Costs");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectManagerId",
                table: "Project",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Costs_EmployeeId",
                table: "Costs",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Employee_EmployeeId",
                table: "Costs",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Employee_EmployeeId",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_EmployeeId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Costs");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectManagerId",
                table: "Project",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Costs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_EmployeeId1",
                table: "Costs",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Employee_EmployeeId1",
                table: "Costs",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
