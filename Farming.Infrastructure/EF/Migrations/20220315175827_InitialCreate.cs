using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FertilizerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerWarehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerWarehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequiredAmountPerHectare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fertilizers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FertilizerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FertilizerRequiredAmountPerHectare = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fertilizers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fertilizers_FertilizerTypes_FertilizerTypeId",
                        column: x => x.FertilizerTypeId,
                        principalTable: "FertilizerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerPlant",
                columns: table => new
                {
                    SuitableFertilizersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuitablePlantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerPlant", x => new { x.SuitableFertilizersId, x.SuitablePlantsId });
                    table.ForeignKey(
                        name: "FK_FertilizerPlant_Fertilizers_SuitableFertilizersId",
                        column: x => x.SuitableFertilizersId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FertilizerPlant_Plants_SuitablePlantsId",
                        column: x => x.SuitablePlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerWarehouseStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FertilizerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FertilizerWarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerWarehouseStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizerWarehouseStates_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilizerWarehouseStates_FertilizerWarehouses_FertilizerWarehouseId",
                        column: x => x.FertilizerWarehouseId,
                        principalTable: "FertilizerWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerWarehouseDeliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FertilizerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FertilizerWarehouseStateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RealizationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerWarehouseDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilizerWarehouseDeliveries_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilizerWarehouseDeliveries_FertilizerWarehouseStates_FertilizerWarehouseStateId",
                        column: x => x.FertilizerWarehouseStateId,
                        principalTable: "FertilizerWarehouseStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerPlant_SuitablePlantsId",
                table: "FertilizerPlant",
                column: "SuitablePlantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizers_FertilizerTypeId",
                table: "Fertilizers",
                column: "FertilizerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseDeliveries_FertilizerId",
                table: "FertilizerWarehouseDeliveries",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseDeliveries_FertilizerWarehouseStateId",
                table: "FertilizerWarehouseDeliveries",
                column: "FertilizerWarehouseStateId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerWarehouseId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerWarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FertilizerPlant");

            migrationBuilder.DropTable(
                name: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "FertilizerWarehouseStates");

            migrationBuilder.DropTable(
                name: "Fertilizers");

            migrationBuilder.DropTable(
                name: "FertilizerWarehouses");

            migrationBuilder.DropTable(
                name: "FertilizerTypes");
        }
    }
}
