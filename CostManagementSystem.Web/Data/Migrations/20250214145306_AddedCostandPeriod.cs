using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CostManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCostandPeriod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostCodeId",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodId",
                table: "Costs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "CostName",
                table: "CostCodes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Periods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periods", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Costs_CostCodeId",
                table: "Costs",
                column: "CostCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Costs_PeriodId",
                table: "Costs",
                column: "PeriodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_CostCodes_CostCodeId",
                table: "Costs",
                column: "CostCodeId",
                principalTable: "CostCodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Costs_Periods_PeriodId",
                table: "Costs",
                column: "PeriodId",
                principalTable: "Periods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costs_CostCodes_CostCodeId",
                table: "Costs");

            migrationBuilder.DropForeignKey(
                name: "FK_Costs_Periods_PeriodId",
                table: "Costs");

            migrationBuilder.DropTable(
                name: "Periods");

            migrationBuilder.DropIndex(
                name: "IX_Costs_CostCodeId",
                table: "Costs");

            migrationBuilder.DropIndex(
                name: "IX_Costs_PeriodId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "CostCodeId",
                table: "Costs");

            migrationBuilder.DropColumn(
                name: "PeriodId",
                table: "Costs");

            migrationBuilder.AlterColumn<string>(
                name: "CostName",
                table: "CostCodes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
