using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursEntityFrameWorkCore.Migrations
{
    public partial class OneToManyMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personnes_adresses_adresse_id",
                table: "personnes");

            migrationBuilder.DropIndex(
                name: "IX_personnes_adresse_id",
                table: "personnes");

            migrationBuilder.DropColumn(
                name: "adresse_id",
                table: "personnes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "adresse_id",
                table: "personnes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_personnes_adresse_id",
                table: "personnes",
                column: "adresse_id");

            migrationBuilder.AddForeignKey(
                name: "FK_personnes_adresses_adresse_id",
                table: "personnes",
                column: "adresse_id",
                principalTable: "adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
