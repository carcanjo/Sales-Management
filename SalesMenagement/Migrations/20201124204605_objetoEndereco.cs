using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesMenagement.Migrations
{
    public partial class objetoEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Seller",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Seller",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumeroCasa",
                table: "Seller",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Seller",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "NumeroCasa",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Seller");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Seller",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
