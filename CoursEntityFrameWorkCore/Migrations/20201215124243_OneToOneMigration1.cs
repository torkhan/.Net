using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursEntityFrameWorkCore.Migrations
{
    public partial class OneToOneMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "personnes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    code_postal = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_adresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personnes_AddressId",
                table: "personnes",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_personnes_adresses_AddressId",
                table: "personnes",
                column: "AddressId",
                principalTable: "adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personnes_adresses_AddressId",
                table: "personnes");

            migrationBuilder.DropTable(
                name: "adresses");

            migrationBuilder.DropIndex(
                name: "IX_personnes_AddressId",
                table: "personnes");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "personnes");
        }
    }
}
