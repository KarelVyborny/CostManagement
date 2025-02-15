using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingProjectAndEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FinalDate",
                table: "Costs",
                newName: "CostDate");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Costs",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId1",
                table: "Costs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "VAT",
                table: "Costs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    ProjectManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Employee_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_EmployeeId1",
                table: "Costs",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_ProjectId",
                table: "Costs",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectManagerId",
                table: "Project",
                column: "ProjectManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Employee_EmployeeId1",
                table: "Costs",
                column: "EmployeeId1",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Project_ProjectId",
                table: "Costs",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Employee_EmployeeId1",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Project_ProjectId",
                table: "Costs");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Costs_EmployeeId1",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_ProjectId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "VAT",
                table: "Costs");

            migrationBuilder.RenameColumn(
                name: "CostDate",
                table: "Costs",
                newName: "FinalDate");

            migrationBuilder.AlterColumn<int>(
                name: "Amount",
                table: "Costs",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
