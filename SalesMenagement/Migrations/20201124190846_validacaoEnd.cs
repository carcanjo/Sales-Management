using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesMenagement.Migrations
{
    public partial class validacaoEnd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departments_DepartmentsId",
                table: "Seller");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Seller",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departments_DepartmentsId",
                table: "Seller",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Departments_DepartmentsId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "Seller");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentsId",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Departments_DepartmentsId",
                table: "Seller",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
