using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations.Read
{
    public partial class InitialPostgresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FertilizerTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerWarehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilizerWarehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    LandClass = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Area = table.Column<decimal>(type: "numeric", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PesticideTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticideTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PesticideWarehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticideWarehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    RequiredAmountPerHectare = table.Column<decimal>(type: "numeric", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlantWarehouses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantWarehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fertilizers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FertilizerTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequiredAmountPerHectare = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
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
                name: "Pesticides",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PesticideTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RequiredAmountPerHectare = table.Column<decimal>(type: "numeric", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesticides", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pesticides_PesticideTypes_PesticideTypeId",
                        column: x => x.PesticideTypeId,
                        principalTable: "PesticideTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantWarehouseStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantWarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantWarehouseStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantWarehouseStates_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantWarehouseStates_PlantWarehouses_PlantWarehouseId",
                        column: x => x.PlantWarehouseId,
                        principalTable: "PlantWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LandRealizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LandId = table.Column<Guid>(type: "uuid", nullable: false),
                    SeasonId = table.Column<Guid>(type: "uuid", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LandRealizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LandRealizations_Lands_LandId",
                        column: x => x.LandId,
                        principalTable: "Lands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LandRealizations_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerWarehouseStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FertilizerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FertilizerWarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_FertilizerWarehouseStates_FertilizerWarehouses_FertilizerWa~",
                        column: x => x.FertilizerWarehouseId,
                        principalTable: "FertilizerWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantFertilizers",
                columns: table => new
                {
                    SuitableFertilizersId = table.Column<Guid>(type: "uuid", nullable: false),
                    SuitablePlantsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantFertilizers", x => new { x.SuitableFertilizersId, x.SuitablePlantsId });
                    table.ForeignKey(
                        name: "FK_PlantFertilizers_Fertilizers_SuitableFertilizersId",
                        column: x => x.SuitableFertilizersId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantFertilizers_Plants_SuitablePlantsId",
                        column: x => x.SuitablePlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PesticideWarehouseStates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PesticideId = table.Column<Guid>(type: "uuid", nullable: false),
                    PesticideWarehouseId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticideWarehouseStates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWareh~",
                        column: x => x.PesticideWarehouseId,
                        principalTable: "PesticideWarehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantPesticides",
                columns: table => new
                {
                    SuitablePesticidesId = table.Column<Guid>(type: "uuid", nullable: false),
                    SuitablePlantsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantPesticides", x => new { x.SuitablePesticidesId, x.SuitablePlantsId });
                    table.ForeignKey(
                        name: "FK_PlantPesticides_Pesticides_SuitablePesticidesId",
                        column: x => x.SuitablePesticidesId,
                        principalTable: "Pesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantPesticides_Plants_SuitablePlantsId",
                        column: x => x.SuitablePlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantWarehouseDeliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantWarehouseStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    RealizationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantWarehouseDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantWarehouseDeliveries_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantWarehouseDeliveries_PlantWarehouseStates_PlantWarehous~",
                        column: x => x.PlantWarehouseStateId,
                        principalTable: "PlantWarehouseStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantWarehouseDeliveries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FertilzierActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FertilizerId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandRealizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    RealizationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FertilzierActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FertilzierActions_Fertilizers_FertilizerId",
                        column: x => x.FertilizerId,
                        principalTable: "Fertilizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilzierActions_LandRealizations_LandRealizationId",
                        column: x => x.LandRealizationId,
                        principalTable: "LandRealizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilzierActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PesticideActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PesticideId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandRealizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    RealizationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticideActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PesticideActions_LandRealizations_LandRealizationId",
                        column: x => x.LandRealizationId,
                        principalTable: "LandRealizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PesticideActions_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PesticideActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlantId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LandRealizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    RealizationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlantActions_LandRealizations_LandRealizationId",
                        column: x => x.LandRealizationId,
                        principalTable: "LandRealizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantActions_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantActions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FertilizerWarehouseDeliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FertilizerId = table.Column<Guid>(type: "uuid", nullable: false),
                    FertilizerWarehouseStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    RealizationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
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
                        name: "FK_FertilizerWarehouseDeliveries_FertilizerWarehouseStates_Fer~",
                        column: x => x.FertilizerWarehouseStateId,
                        principalTable: "FertilizerWarehouseStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FertilizerWarehouseDeliveries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PesticideWarehouseDeliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PesticideId = table.Column<Guid>(type: "uuid", nullable: false),
                    PesticideWarehouseStateId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    RealizationDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesticideWarehouseDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PesticideWarehouseDeliveries_Pesticides_PesticideId",
                        column: x => x.PesticideId,
                        principalTable: "Pesticides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PesticideWarehouseDeliveries_PesticideWarehouseStates_Pesti~",
                        column: x => x.PesticideWarehouseStateId,
                        principalTable: "PesticideWarehouseStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PesticideWarehouseDeliveries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_FertilizerWarehouseDeliveries_UserId",
                table: "FertilizerWarehouseDeliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerWarehouseId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilzierActions_FertilizerId",
                table: "FertilzierActions",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilzierActions_LandRealizationId",
                table: "FertilzierActions",
                column: "LandRealizationId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilzierActions_UserId",
                table: "FertilzierActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LandRealizations_LandId",
                table: "LandRealizations",
                column: "LandId");

            migrationBuilder.CreateIndex(
                name: "IX_LandRealizations_SeasonId",
                table: "LandRealizations",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideActions_LandRealizationId",
                table: "PesticideActions",
                column: "LandRealizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideActions_PesticideId",
                table: "PesticideActions",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideActions_UserId",
                table: "PesticideActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesticides_PesticideTypeId",
                table: "Pesticides",
                column: "PesticideTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseDeliveries_PesticideId",
                table: "PesticideWarehouseDeliveries",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseDeliveries_PesticideWarehouseStateId",
                table: "PesticideWarehouseDeliveries",
                column: "PesticideWarehouseStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseDeliveries_UserId",
                table: "PesticideWarehouseDeliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseStates_PesticideId",
                table: "PesticideWarehouseStates",
                column: "PesticideId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseStates_PesticideWarehouseId",
                table: "PesticideWarehouseStates",
                column: "PesticideWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantActions_LandRealizationId",
                table: "PlantActions",
                column: "LandRealizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantActions_PlantId",
                table: "PlantActions",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantActions_UserId",
                table: "PlantActions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantFertilizers_SuitablePlantsId",
                table: "PlantFertilizers",
                column: "SuitablePlantsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantPesticides_SuitablePlantsId",
                table: "PlantPesticides",
                column: "SuitablePlantsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseDeliveries_PlantId",
                table: "PlantWarehouseDeliveries",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseDeliveries_PlantWarehouseStateId",
                table: "PlantWarehouseDeliveries",
                column: "PlantWarehouseStateId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseDeliveries_UserId",
                table: "PlantWarehouseDeliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseStates_PlantId",
                table: "PlantWarehouseStates",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseStates_PlantWarehouseId",
                table: "PlantWarehouseStates",
                column: "PlantWarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropTable(
                name: "FertilzierActions");

            migrationBuilder.DropTable(
                name: "PesticideActions");

            migrationBuilder.DropTable(
                name: "PesticideWarehouseDeliveries");

            migrationBuilder.DropTable(
                name: "PlantActions");

            migrationBuilder.DropTable(
                name: "PlantFertilizers");

            migrationBuilder.DropTable(
                name: "PlantPesticides");

            migrationBuilder.DropTable(
                name: "PlantWarehouseDeliveries");

            migrationBuilder.DropTable(
                name: "FertilizerWarehouseStates");

            migrationBuilder.DropTable(
                name: "PesticideWarehouseStates");

            migrationBuilder.DropTable(
                name: "LandRealizations");

            migrationBuilder.DropTable(
                name: "PlantWarehouseStates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Fertilizers");

            migrationBuilder.DropTable(
                name: "FertilizerWarehouses");

            migrationBuilder.DropTable(
                name: "Pesticides");

            migrationBuilder.DropTable(
                name: "PesticideWarehouses");

            migrationBuilder.DropTable(
                name: "Lands");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "PlantWarehouses");

            migrationBuilder.DropTable(
                name: "FertilizerTypes");

            migrationBuilder.DropTable(
                name: "PesticideTypes");
        }
    }
}
