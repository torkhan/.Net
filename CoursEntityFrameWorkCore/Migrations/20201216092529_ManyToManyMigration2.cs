using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursEntityFrameWorkCore.Migrations
{
    public partial class ManyToManyMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_adresses_AddressesId",
                table: "AddressPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_personnes_PersonsId",
                table: "AddressPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressPerson",
                table: "AddressPerson");

            migrationBuilder.RenameColumn(
                name: "PersonsId",
                table: "AddressPerson",
                newName: "PersonId");

            migrationBuilder.RenameColumn(
                name: "AddressesId",
                table: "AddressPerson",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressPerson_PersonsId",
                table: "AddressPerson",
                newName: "IX_AddressPerson_PersonId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AddressPerson",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressPerson",
                table: "AddressPerson",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AddressPerson_AddressId",
                table: "AddressPerson",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_adresses_AddressId",
                table: "AddressPerson",
                column: "AddressId",
                principalTable: "adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_personnes_PersonId",
                table: "AddressPerson",
                column: "PersonId",
                principalTable: "personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_adresses_AddressId",
                table: "AddressPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_AddressPerson_personnes_PersonId",
                table: "AddressPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddressPerson",
                table: "AddressPerson");

            migrationBuilder.DropIndex(
                name: "IX_AddressPerson_AddressId",
                table: "AddressPerson");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AddressPerson");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "AddressPerson",
                newName: "PersonsId");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "AddressPerson",
                newName: "AddressesId");

            migrationBuilder.RenameIndex(
                name: "IX_AddressPerson_PersonId",
                table: "AddressPerson",
                newName: "IX_AddressPerson_PersonsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddressPerson",
                table: "AddressPerson",
                columns: new[] { "AddressesId", "PersonsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_adresses_AddressesId",
                table: "AddressPerson",
                column: "AddressesId",
                principalTable: "adresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AddressPerson_personnes_PersonsId",
                table: "AddressPerson",
                column: "PersonsId",
                principalTable: "personnes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
