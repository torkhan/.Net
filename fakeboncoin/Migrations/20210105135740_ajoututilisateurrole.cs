using Microsoft.EntityFrameworkCore.Migrations;

namespace fakeboncoin.Migrations
{
    public partial class ajoututilisateurrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Utilisateurs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Utilisateurs");
        }
    }
}
