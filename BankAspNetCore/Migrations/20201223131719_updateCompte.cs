using Microsoft.EntityFrameworkCore.Migrations;

namespace BankAspNetCore.Migrations
{
    public partial class updateCompte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Solde",
                table: "Comptes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Solde",
                table: "Comptes");
        }
    }
}
