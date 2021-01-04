using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelWPFMVVM.Migrations
{
    public partial class secondmigrationbis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NbPerson",
                table: "Reservations",
                newName: "NbPersons");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NbPersons",
                table: "Reservations",
                newName: "NbPerson");
        }
    }
}
