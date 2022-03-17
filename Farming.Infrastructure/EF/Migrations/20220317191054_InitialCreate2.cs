using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FertilizerRequiredAmountPerHectare",
                table: "Fertilizers",
                newName: "RequiredAmountPerHectare");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequiredAmountPerHectare",
                table: "Fertilizers",
                newName: "FertilizerRequiredAmountPerHectare");
        }
    }
}
