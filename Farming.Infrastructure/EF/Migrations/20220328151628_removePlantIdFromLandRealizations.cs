using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations
{
    public partial class removePlantIdFromLandRealizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWarehouseId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropColumn(
                name: "PlantActionId",
                table: "LandRealizations");

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWarehouseId",
                table: "PesticideWarehouseStates",
                column: "PesticideWarehouseId",
                principalTable: "PesticideWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWarehouseId",
                table: "PesticideWarehouseStates");

            migrationBuilder.AddColumn<Guid>(
                name: "PlantActionId",
                table: "LandRealizations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWarehouseId",
                table: "PesticideWarehouseStates",
                column: "PesticideWarehouseId",
                principalTable: "PesticideWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
