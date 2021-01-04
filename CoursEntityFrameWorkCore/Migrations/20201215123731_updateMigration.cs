using Microsoft.EntityFrameworkCore.Migrations;

namespace CoursEntityFrameWorkCore.Migrations
{
    public partial class updateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "personnes");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "personnes",
                newName: "telephone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "personnes",
                newName: "prenom");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "personnes",
                newName: "nom");

            migrationBuilder.AlterColumn<string>(
                name: "telephone",
                table: "personnes",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_personnes",
                table: "personnes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_personnes",
                table: "personnes");

            migrationBuilder.RenameTable(
                name: "personnes",
                newName: "Persons");

            migrationBuilder.RenameColumn(
                name: "telephone",
                table: "Persons",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "prenom",
                table: "Persons",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "nom",
                table: "Persons",
                newName: "FirstName");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");
        }
    }
}
