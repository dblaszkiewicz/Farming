using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations
{
    public partial class InitialCreate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Lands",
                newName: "LandCLass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LandCLass",
                table: "Lands",
                newName: "Class");
        }
    }
}
