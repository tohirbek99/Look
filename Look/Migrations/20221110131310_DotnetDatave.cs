using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Look.Migrations
{
    public partial class DotnetDatave : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Employees_EmployeesEmployeeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_EmployeesEmployeeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EmploeeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EmployeesEmployeeId",
                table: "Categories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmploeeId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeesEmployeeId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EmployeesEmployeeId",
                table: "Categories",
                column: "EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Employees_EmployeesEmployeeId",
                table: "Categories",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
