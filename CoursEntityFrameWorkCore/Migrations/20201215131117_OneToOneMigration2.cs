using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursEntityFrameWorkCore.Migrations
{
    public partial class OneToOneMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personnes_adresses_AddressId",
                table: "personnes");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "personnes",
                newName: "adresse_id");

            migrationBuilder.RenameIndex(
                name: "IX_personnes_AddressId",
                table: "personnes",
                newName: "IX_personnes_adresse_id");

            migrationBuilder.AlterColumn<int>(
                name: "adresse_id",
                table: "personnes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_personnes_adresses_adresse_id",
                table: "personnes",
                column: "adresse_id",
                principalTable: "adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_personnes_adresses_adresse_id",
                table: "personnes");

            migrationBuilder.RenameColumn(
                name: "adresse_id",
                table: "personnes",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_personnes_adresse_id",
                table: "personnes",
                newName: "IX_personnes_AddressId");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "personnes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_personnes_adresses_AddressId",
                table: "personnes",
                column: "AddressId",
                principalTable: "adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
