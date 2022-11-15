using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Look.Migrations
{
    public partial class DotnetDatavee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Employees_EmploeeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_EmploeeId",
                table: "Categories");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Employees_EmployeesEmployeeId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_EmployeesEmployeeId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "EmployeesEmployeeId",
                table: "Categories");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_EmploeeId",
                table: "Categories",
                column: "EmploeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Employees_EmploeeId",
                table: "Categories",
                column: "EmploeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
