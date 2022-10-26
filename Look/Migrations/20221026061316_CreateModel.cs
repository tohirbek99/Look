using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Look.Migrations
{
    public partial class CreateModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costomers_Orders_OrderId",
                table: "Costomers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Employees_EmployeesEmployeeId",
                table: "Drinks");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_EmployeesEmployeeId",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "EmployeesEmployeeId",
                table: "Drinks");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Costomers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_EmploeeId",
                table: "Drinks",
                column: "EmploeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costomers_Orders_OrderId",
                table: "Costomers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Employees_EmploeeId",
                table: "Drinks",
                column: "EmploeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Costomers_Orders_OrderId",
                table: "Costomers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_Employees_EmploeeId",
                table: "Drinks");

            migrationBuilder.DropIndex(
                name: "IX_Drinks_EmploeeId",
                table: "Drinks");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesEmployeeId",
                table: "Drinks",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Costomers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_EmployeesEmployeeId",
                table: "Drinks",
                column: "EmployeesEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Costomers_Orders_OrderId",
                table: "Costomers",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_Employees_EmployeesEmployeeId",
                table: "Drinks",
                column: "EmployeesEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }
    }
}
