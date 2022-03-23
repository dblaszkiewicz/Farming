using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlantWarehouseQuantity",
                table: "PlantWarehouseStates",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "PlantWarehouseStates",
                newName: "PlantWarehouseQuantity");
        }
    }
}
