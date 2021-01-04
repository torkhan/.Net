using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursEntityFrameWorkCore.Migrations
{
    public partial class ManyToManyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_adresses_personnes_PersonId",
                table: "adresses");

            migrationBuilder.DropIndex(
                name: "IX_adresses_PersonId",
                table: "adresses");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "adresses");

            migrationBuilder.CreateTable(
                name: "AddressPerson",
                columns: table => new
                {
                    AddressesId = table.Column<int>(type: "int", nullable: false),
                    PersonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressPerson", x => new { x.AddressesId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_AddressPerson_adresses_AddressesId",
                        column: x => x.AddressesId,
                        principalTable: "adresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AddressPerson_personnes_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "personnes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressPerson_PersonsId",
                table: "AddressPerson",
                column: "PersonsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressPerson");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "adresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_adresses_PersonId",
                table: "adresses",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_adresses_personnes_PersonId",
                table: "adresses",
                column: "PersonId",
                principalTable: "personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
