using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CostManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedRequest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostRequestStatusId",
                table: "CostApprovals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "CostApprovals",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RequestComment",
                table: "CostApprovals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestedById",
                table: "CostApprovals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestedById1",
                table: "CostApprovals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewedById",
                table: "CostApprovals",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewedById1",
                table: "CostApprovals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CostCodeReadOnlyVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostGroup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCodeReadOnlyVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostRequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostRequestStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CostApprovalEditVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CostCodeId = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PeriodId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostApprovalEditVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostApprovalEditVM_CostCodes_CostCodeId",
                        column: x => x.CostCodeId,
                        principalTable: "CostCodes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CostApprovalEditVM_EmployeeVM_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeVM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CostApprovalEditVM_PeriodVM_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "PeriodVM",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CostApprovalEditVM_ProjectVM_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectVM",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CostApprovalReadOnlyVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CostDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VAT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PeriodId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CostCodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostApprovalReadOnlyVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostApprovalReadOnlyVM_CostCodeReadOnlyVM_CostCodeId",
                        column: x => x.CostCodeId,
                        principalTable: "CostCodeReadOnlyVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostApprovalReadOnlyVM_EmployeeVM_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "EmployeeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostApprovalReadOnlyVM_PeriodVM_PeriodId",
                        column: x => x.PeriodId,
                        principalTable: "PeriodVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CostApprovalReadOnlyVM_ProjectVM_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CostRequestStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Approved" },
                    { 3, "Declined" },
                    { 4, "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovals_CostRequestStatusId",
                table: "CostApprovals",
                column: "CostRequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovals_RequestedById1",
                table: "CostApprovals",
                column: "RequestedById1");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovals_ReviewedById1",
                table: "CostApprovals",
                column: "ReviewedById1");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalEditVM_CostCodeId",
                table: "CostApprovalEditVM",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalEditVM_EmployeeId",
                table: "CostApprovalEditVM",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalEditVM_PeriodId",
                table: "CostApprovalEditVM",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalEditVM_ProjectId",
                table: "CostApprovalEditVM",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalReadOnlyVM_CostCodeId",
                table: "CostApprovalReadOnlyVM",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalReadOnlyVM_EmployeeId",
                table: "CostApprovalReadOnlyVM",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalReadOnlyVM_PeriodId",
                table: "CostApprovalReadOnlyVM",
                column: "PeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_CostApprovalReadOnlyVM_ProjectId",
                table: "CostApprovalReadOnlyVM",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_CostApprovals_CostRequestStatuses_CostRequestStatusId",
                table: "CostApprovals",
                column: "CostRequestStatusId",
                principalTable: "CostRequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostApprovals_Employees_RequestedById1",
                table: "CostApprovals",
                column: "RequestedById1",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CostApprovals_Employees_ReviewedById1",
                table: "CostApprovals",
                column: "ReviewedById1",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CostApprovals_CostRequestStatuses_CostRequestStatusId",
                table: "CostApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_CostApprovals_Employees_RequestedById1",
                table: "CostApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_CostApprovals_Employees_ReviewedById1",
                table: "CostApprovals");

            migrationBuilder.DropTable(
                name: "CostApprovalEditVM");

            migrationBuilder.DropTable(
                name: "CostApprovalReadOnlyVM");

            migrationBuilder.DropTable(
                name: "CostRequestStatuses");

            migrationBuilder.DropTable(
                name: "CostCodeReadOnlyVM");

            migrationBuilder.DropTable(
                name: "EmployeeVM");

            migrationBuilder.DropTable(
                name: "PeriodVM");

            migrationBuilder.DropTable(
                name: "ProjectVM");

            migrationBuilder.DropIndex(
                name: "IX_CostApprovals_CostRequestStatusId",
                table: "CostApprovals");

            migrationBuilder.DropIndex(
                name: "IX_CostApprovals_RequestedById1",
                table: "CostApprovals");

            migrationBuilder.DropIndex(
                name: "IX_CostApprovals_ReviewedById1",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "CostRequestStatusId",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "RequestComment",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "RequestedById",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "RequestedById1",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "ReviewedById",
                table: "CostApprovals");

            migrationBuilder.DropColumn(
                name: "ReviewedById1",
                table: "CostApprovals");
        }
    }
}
