﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations.Read
{
    public partial class addIndexesAtTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerActions_Fertilizers_FertilizerId",
                table: "FertilizerActions");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerActions_LandRealizations_LandRealizationId",
                table: "FertilizerActions");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerActions_Users_UserId",
                table: "FertilizerActions");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerReadModelPlantReadModel_Fertilizers_SuitableFerti~",
                table: "FertilizerReadModelPlantReadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerReadModelPlantReadModel_Plants_SuitablePlantsId",
                table: "FertilizerReadModelPlantReadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Fertilizers_FertilizerTypes_FertilizerTypeId",
                table: "Fertilizers");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Fertilizers_FertilizerId",
                table: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_FertilizerWarehouseStates_Fer~",
                table: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Users_UserId",
                table: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseStates_Fertilizers_FertilizerReadModelId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseStates_FertilizerWarehouses_FertilizerWa~",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_LandRealizations_Lands_LandId",
                table: "LandRealizations");

            migrationBuilder.DropForeignKey(
                name: "FK_LandRealizations_Seasons_SeasonId",
                table: "LandRealizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideActions_LandRealizations_LandRealizationId",
                table: "PesticideActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideActions_Pesticides_PesticideId",
                table: "PesticideActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideActions_Users_UserId",
                table: "PesticideActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideReadModelPlantReadModel_Pesticides_SuitablePestici~",
                table: "PesticideReadModelPlantReadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideReadModelPlantReadModel_Plants_SuitablePlantsId",
                table: "PesticideReadModelPlantReadModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Pesticides_PesticideTypes_PesticideTypeId",
                table: "Pesticides");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Pesticides_PesticideId",
                table: "PesticideWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseDeliveries_PesticideWarehouseStates_Pesti~",
                table: "PesticideWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Users_UserId",
                table: "PesticideWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWareh~",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantActions_LandRealizations_LandRealizationId",
                table: "PlantActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantActions_Plants_PlantId",
                table: "PlantActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantActions_Users_UserId",
                table: "PlantActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseDeliveries_Plants_PlantId",
                table: "PlantWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseDeliveries_PlantWarehouseStates_PlantWarehous~",
                table: "PlantWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseDeliveries_Users_UserId",
                table: "PlantWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseStates_Plants_PlantReadModelId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseStates_PlantWarehouses_PlantWarehouseReadMode~",
                table: "PlantWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PlantWarehouseStates_PlantReadModelId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PlantWarehouseStates_PlantWarehouseReadModelId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PesticideWarehouseStates_PesticideWarehouseReadModelId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerReadModelId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerWarehouseReadModelId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PesticideReadModelPlantReadModel",
                table: "PesticideReadModelPlantReadModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FertilizerReadModelPlantReadModel",
                table: "FertilizerReadModelPlantReadModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FertilizerActions",
                table: "FertilizerActions");

            migrationBuilder.DropColumn(
                name: "PlantReadModelId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropColumn(
                name: "PlantWarehouseReadModelId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropColumn(
                name: "PesticideWarehouseReadModelId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropColumn(
                name: "FertilizerReadModelId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropColumn(
                name: "FertilizerWarehouseReadModelId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.RenameTable(
                name: "PesticideReadModelPlantReadModel",
                newName: "PlantPesticides");

            migrationBuilder.RenameTable(
                name: "FertilizerReadModelPlantReadModel",
                newName: "PlantFertilizers");

            migrationBuilder.RenameTable(
                name: "FertilizerActions",
                newName: "FertilzierActions");

            migrationBuilder.RenameIndex(
                name: "IX_PesticideReadModelPlantReadModel_SuitablePlantsId",
                table: "PlantPesticides",
                newName: "IX_PlantPesticides_SuitablePlantsId");

            migrationBuilder.RenameIndex(
                name: "IX_FertilizerReadModelPlantReadModel_SuitablePlantsId",
                table: "PlantFertilizers",
                newName: "IX_PlantFertilizers_SuitablePlantsId");

            migrationBuilder.RenameIndex(
                name: "IX_FertilizerActions_UserId",
                table: "FertilzierActions",
                newName: "IX_FertilzierActions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FertilizerActions_LandRealizationId",
                table: "FertilzierActions",
                newName: "IX_FertilzierActions_LandRealizationId");

            migrationBuilder.RenameIndex(
                name: "IX_FertilizerActions_FertilizerId",
                table: "FertilzierActions",
                newName: "IX_FertilzierActions_FertilizerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantPesticides",
                table: "PlantPesticides",
                columns: new[] { "SuitablePesticidesId", "SuitablePlantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantFertilizers",
                table: "PlantFertilizers",
                columns: new[] { "SuitableFertilizersId", "SuitablePlantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FertilzierActions",
                table: "FertilzierActions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_TenantId",
                table: "Seasons",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseStates_PlantId",
                table: "PlantWarehouseStates",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseStates_PlantWarehouseId",
                table: "PlantWarehouseStates",
                column: "PlantWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseStates_TenantId",
                table: "PlantWarehouseStates",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouses_TenantId",
                table: "PlantWarehouses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseDeliveries_TenantId",
                table: "PlantWarehouseDeliveries",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_TenantId",
                table: "Plants",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantActions_TenantId",
                table: "PlantActions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseStates_PesticideWarehouseId",
                table: "PesticideWarehouseStates",
                column: "PesticideWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseStates_TenantId",
                table: "PesticideWarehouseStates",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouses_TenantId",
                table: "PesticideWarehouses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseDeliveries_TenantId",
                table: "PesticideWarehouseDeliveries",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideTypes_TenantId",
                table: "PesticideTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Pesticides_TenantId",
                table: "Pesticides",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideActions_TenantId",
                table: "PesticideActions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Lands_TenantId",
                table: "Lands",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_LandRealizations_TenantId",
                table: "LandRealizations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerWarehouseId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_TenantId",
                table: "FertilizerWarehouseStates",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouses_TenantId",
                table: "FertilizerWarehouses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseDeliveries_TenantId",
                table: "FertilizerWarehouseDeliveries",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerTypes_TenantId",
                table: "FertilizerTypes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Fertilizers_TenantId",
                table: "Fertilizers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilzierActions_TenantId",
                table: "FertilzierActions",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fertilizers_FertilizerTypes_FertilizerTypeId",
                table: "Fertilizers",
                column: "FertilizerTypeId",
                principalTable: "FertilizerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Fertilizers_FertilizerId",
                table: "FertilizerWarehouseDeliveries",
                column: "FertilizerId",
                principalTable: "Fertilizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_FertilizerWarehouseStates_Fer~",
                table: "FertilizerWarehouseDeliveries",
                column: "FertilizerWarehouseStateId",
                principalTable: "FertilizerWarehouseStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Users_UserId",
                table: "FertilizerWarehouseDeliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseStates_Fertilizers_FertilizerId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerId",
                principalTable: "Fertilizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseStates_FertilizerWarehouses_FertilizerWa~",
                table: "FertilizerWarehouseStates",
                column: "FertilizerWarehouseId",
                principalTable: "FertilizerWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilzierActions_Fertilizers_FertilizerId",
                table: "FertilzierActions",
                column: "FertilizerId",
                principalTable: "Fertilizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilzierActions_LandRealizations_LandRealizationId",
                table: "FertilzierActions",
                column: "LandRealizationId",
                principalTable: "LandRealizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilzierActions_Users_UserId",
                table: "FertilzierActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LandRealizations_Lands_LandId",
                table: "LandRealizations",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LandRealizations_Seasons_SeasonId",
                table: "LandRealizations",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideActions_LandRealizations_LandRealizationId",
                table: "PesticideActions",
                column: "LandRealizationId",
                principalTable: "LandRealizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideActions_Pesticides_PesticideId",
                table: "PesticideActions",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideActions_Users_UserId",
                table: "PesticideActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesticides_PesticideTypes_PesticideTypeId",
                table: "Pesticides",
                column: "PesticideTypeId",
                principalTable: "PesticideTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Pesticides_PesticideId",
                table: "PesticideWarehouseDeliveries",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseDeliveries_PesticideWarehouseStates_Pesti~",
                table: "PesticideWarehouseDeliveries",
                column: "PesticideWarehouseStateId",
                principalTable: "PesticideWarehouseStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Users_UserId",
                table: "PesticideWarehouseDeliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWareh~",
                table: "PesticideWarehouseStates",
                column: "PesticideWarehouseId",
                principalTable: "PesticideWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantActions_LandRealizations_LandRealizationId",
                table: "PlantActions",
                column: "LandRealizationId",
                principalTable: "LandRealizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantActions_Plants_PlantId",
                table: "PlantActions",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantActions_Users_UserId",
                table: "PlantActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantFertilizers_Fertilizers_SuitableFertilizersId",
                table: "PlantFertilizers",
                column: "SuitableFertilizersId",
                principalTable: "Fertilizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantFertilizers_Plants_SuitablePlantsId",
                table: "PlantFertilizers",
                column: "SuitablePlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantPesticides_Pesticides_SuitablePesticidesId",
                table: "PlantPesticides",
                column: "SuitablePesticidesId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantPesticides_Plants_SuitablePlantsId",
                table: "PlantPesticides",
                column: "SuitablePlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseDeliveries_Plants_PlantId",
                table: "PlantWarehouseDeliveries",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseDeliveries_PlantWarehouseStates_PlantWarehous~",
                table: "PlantWarehouseDeliveries",
                column: "PlantWarehouseStateId",
                principalTable: "PlantWarehouseStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseDeliveries_Users_UserId",
                table: "PlantWarehouseDeliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseStates_Plants_PlantId",
                table: "PlantWarehouseStates",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseStates_PlantWarehouses_PlantWarehouseId",
                table: "PlantWarehouseStates",
                column: "PlantWarehouseId",
                principalTable: "PlantWarehouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fertilizers_FertilizerTypes_FertilizerTypeId",
                table: "Fertilizers");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Fertilizers_FertilizerId",
                table: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_FertilizerWarehouseStates_Fer~",
                table: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Users_UserId",
                table: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseStates_Fertilizers_FertilizerId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilizerWarehouseStates_FertilizerWarehouses_FertilizerWa~",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilzierActions_Fertilizers_FertilizerId",
                table: "FertilzierActions");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilzierActions_LandRealizations_LandRealizationId",
                table: "FertilzierActions");

            migrationBuilder.DropForeignKey(
                name: "FK_FertilzierActions_Users_UserId",
                table: "FertilzierActions");

            migrationBuilder.DropForeignKey(
                name: "FK_LandRealizations_Lands_LandId",
                table: "LandRealizations");

            migrationBuilder.DropForeignKey(
                name: "FK_LandRealizations_Seasons_SeasonId",
                table: "LandRealizations");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideActions_LandRealizations_LandRealizationId",
                table: "PesticideActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideActions_Pesticides_PesticideId",
                table: "PesticideActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideActions_Users_UserId",
                table: "PesticideActions");

            migrationBuilder.DropForeignKey(
                name: "FK_Pesticides_PesticideTypes_PesticideTypeId",
                table: "Pesticides");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Pesticides_PesticideId",
                table: "PesticideWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseDeliveries_PesticideWarehouseStates_Pesti~",
                table: "PesticideWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Users_UserId",
                table: "PesticideWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWareh~",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantActions_LandRealizations_LandRealizationId",
                table: "PlantActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantActions_Plants_PlantId",
                table: "PlantActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantActions_Users_UserId",
                table: "PlantActions");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantFertilizers_Fertilizers_SuitableFertilizersId",
                table: "PlantFertilizers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantFertilizers_Plants_SuitablePlantsId",
                table: "PlantFertilizers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantPesticides_Pesticides_SuitablePesticidesId",
                table: "PlantPesticides");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantPesticides_Plants_SuitablePlantsId",
                table: "PlantPesticides");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseDeliveries_Plants_PlantId",
                table: "PlantWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseDeliveries_PlantWarehouseStates_PlantWarehous~",
                table: "PlantWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseDeliveries_Users_UserId",
                table: "PlantWarehouseDeliveries");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseStates_Plants_PlantId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantWarehouseStates_PlantWarehouses_PlantWarehouseId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_Users_TenantId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_TenantId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_PlantWarehouseStates_PlantId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PlantWarehouseStates_PlantWarehouseId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PlantWarehouseStates_TenantId",
                table: "PlantWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PlantWarehouses_TenantId",
                table: "PlantWarehouses");

            migrationBuilder.DropIndex(
                name: "IX_PlantWarehouseDeliveries_TenantId",
                table: "PlantWarehouseDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_Plants_TenantId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_PlantActions_TenantId",
                table: "PlantActions");

            migrationBuilder.DropIndex(
                name: "IX_PesticideWarehouseStates_PesticideWarehouseId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PesticideWarehouseStates_TenantId",
                table: "PesticideWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_PesticideWarehouses_TenantId",
                table: "PesticideWarehouses");

            migrationBuilder.DropIndex(
                name: "IX_PesticideWarehouseDeliveries_TenantId",
                table: "PesticideWarehouseDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_PesticideTypes_TenantId",
                table: "PesticideTypes");

            migrationBuilder.DropIndex(
                name: "IX_Pesticides_TenantId",
                table: "Pesticides");

            migrationBuilder.DropIndex(
                name: "IX_PesticideActions_TenantId",
                table: "PesticideActions");

            migrationBuilder.DropIndex(
                name: "IX_Lands_TenantId",
                table: "Lands");

            migrationBuilder.DropIndex(
                name: "IX_LandRealizations_TenantId",
                table: "LandRealizations");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerWarehouseId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerWarehouseStates_TenantId",
                table: "FertilizerWarehouseStates");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerWarehouses_TenantId",
                table: "FertilizerWarehouses");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerWarehouseDeliveries_TenantId",
                table: "FertilizerWarehouseDeliveries");

            migrationBuilder.DropIndex(
                name: "IX_FertilizerTypes_TenantId",
                table: "FertilizerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Fertilizers_TenantId",
                table: "Fertilizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantPesticides",
                table: "PlantPesticides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantFertilizers",
                table: "PlantFertilizers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FertilzierActions",
                table: "FertilzierActions");

            migrationBuilder.DropIndex(
                name: "IX_FertilzierActions_TenantId",
                table: "FertilzierActions");

            migrationBuilder.RenameTable(
                name: "PlantPesticides",
                newName: "PesticideReadModelPlantReadModel");

            migrationBuilder.RenameTable(
                name: "PlantFertilizers",
                newName: "FertilizerReadModelPlantReadModel");

            migrationBuilder.RenameTable(
                name: "FertilzierActions",
                newName: "FertilizerActions");

            migrationBuilder.RenameIndex(
                name: "IX_PlantPesticides_SuitablePlantsId",
                table: "PesticideReadModelPlantReadModel",
                newName: "IX_PesticideReadModelPlantReadModel_SuitablePlantsId");

            migrationBuilder.RenameIndex(
                name: "IX_PlantFertilizers_SuitablePlantsId",
                table: "FertilizerReadModelPlantReadModel",
                newName: "IX_FertilizerReadModelPlantReadModel_SuitablePlantsId");

            migrationBuilder.RenameIndex(
                name: "IX_FertilzierActions_UserId",
                table: "FertilizerActions",
                newName: "IX_FertilizerActions_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FertilzierActions_LandRealizationId",
                table: "FertilizerActions",
                newName: "IX_FertilizerActions_LandRealizationId");

            migrationBuilder.RenameIndex(
                name: "IX_FertilzierActions_FertilizerId",
                table: "FertilizerActions",
                newName: "IX_FertilizerActions_FertilizerId");

            migrationBuilder.AddColumn<Guid>(
                name: "PlantReadModelId",
                table: "PlantWarehouseStates",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlantWarehouseReadModelId",
                table: "PlantWarehouseStates",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PesticideWarehouseReadModelId",
                table: "PesticideWarehouseStates",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FertilizerReadModelId",
                table: "FertilizerWarehouseStates",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FertilizerWarehouseReadModelId",
                table: "FertilizerWarehouseStates",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PesticideReadModelPlantReadModel",
                table: "PesticideReadModelPlantReadModel",
                columns: new[] { "SuitablePesticidesId", "SuitablePlantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FertilizerReadModelPlantReadModel",
                table: "FertilizerReadModelPlantReadModel",
                columns: new[] { "SuitableFertilizersId", "SuitablePlantsId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FertilizerActions",
                table: "FertilizerActions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseStates_PlantReadModelId",
                table: "PlantWarehouseStates",
                column: "PlantReadModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantWarehouseStates_PlantWarehouseReadModelId",
                table: "PlantWarehouseStates",
                column: "PlantWarehouseReadModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PesticideWarehouseStates_PesticideWarehouseReadModelId",
                table: "PesticideWarehouseStates",
                column: "PesticideWarehouseReadModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerReadModelId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerReadModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FertilizerWarehouseStates_FertilizerWarehouseReadModelId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerWarehouseReadModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerActions_Fertilizers_FertilizerId",
                table: "FertilizerActions",
                column: "FertilizerId",
                principalTable: "Fertilizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerActions_LandRealizations_LandRealizationId",
                table: "FertilizerActions",
                column: "LandRealizationId",
                principalTable: "LandRealizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerActions_Users_UserId",
                table: "FertilizerActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerReadModelPlantReadModel_Fertilizers_SuitableFerti~",
                table: "FertilizerReadModelPlantReadModel",
                column: "SuitableFertilizersId",
                principalTable: "Fertilizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerReadModelPlantReadModel_Plants_SuitablePlantsId",
                table: "FertilizerReadModelPlantReadModel",
                column: "SuitablePlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fertilizers_FertilizerTypes_FertilizerTypeId",
                table: "Fertilizers",
                column: "FertilizerTypeId",
                principalTable: "FertilizerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Fertilizers_FertilizerId",
                table: "FertilizerWarehouseDeliveries",
                column: "FertilizerId",
                principalTable: "Fertilizers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_FertilizerWarehouseStates_Fer~",
                table: "FertilizerWarehouseDeliveries",
                column: "FertilizerWarehouseStateId",
                principalTable: "FertilizerWarehouseStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseDeliveries_Users_UserId",
                table: "FertilizerWarehouseDeliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseStates_Fertilizers_FertilizerReadModelId",
                table: "FertilizerWarehouseStates",
                column: "FertilizerReadModelId",
                principalTable: "Fertilizers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FertilizerWarehouseStates_FertilizerWarehouses_FertilizerWa~",
                table: "FertilizerWarehouseStates",
                column: "FertilizerWarehouseReadModelId",
                principalTable: "FertilizerWarehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandRealizations_Lands_LandId",
                table: "LandRealizations",
                column: "LandId",
                principalTable: "Lands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LandRealizations_Seasons_SeasonId",
                table: "LandRealizations",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideActions_LandRealizations_LandRealizationId",
                table: "PesticideActions",
                column: "LandRealizationId",
                principalTable: "LandRealizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideActions_Pesticides_PesticideId",
                table: "PesticideActions",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideActions_Users_UserId",
                table: "PesticideActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideReadModelPlantReadModel_Pesticides_SuitablePestici~",
                table: "PesticideReadModelPlantReadModel",
                column: "SuitablePesticidesId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideReadModelPlantReadModel_Plants_SuitablePlantsId",
                table: "PesticideReadModelPlantReadModel",
                column: "SuitablePlantsId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pesticides_PesticideTypes_PesticideTypeId",
                table: "Pesticides",
                column: "PesticideTypeId",
                principalTable: "PesticideTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Pesticides_PesticideId",
                table: "PesticideWarehouseDeliveries",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseDeliveries_PesticideWarehouseStates_Pesti~",
                table: "PesticideWarehouseDeliveries",
                column: "PesticideWarehouseStateId",
                principalTable: "PesticideWarehouseStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseDeliveries_Users_UserId",
                table: "PesticideWarehouseDeliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_Pesticides_PesticideId",
                table: "PesticideWarehouseStates",
                column: "PesticideId",
                principalTable: "Pesticides",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PesticideWarehouseStates_PesticideWarehouses_PesticideWareh~",
                table: "PesticideWarehouseStates",
                column: "PesticideWarehouseReadModelId",
                principalTable: "PesticideWarehouses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantActions_LandRealizations_LandRealizationId",
                table: "PlantActions",
                column: "LandRealizationId",
                principalTable: "LandRealizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantActions_Plants_PlantId",
                table: "PlantActions",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantActions_Users_UserId",
                table: "PlantActions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseDeliveries_Plants_PlantId",
                table: "PlantWarehouseDeliveries",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseDeliveries_PlantWarehouseStates_PlantWarehous~",
                table: "PlantWarehouseDeliveries",
                column: "PlantWarehouseStateId",
                principalTable: "PlantWarehouseStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseDeliveries_Users_UserId",
                table: "PlantWarehouseDeliveries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseStates_Plants_PlantReadModelId",
                table: "PlantWarehouseStates",
                column: "PlantReadModelId",
                principalTable: "Plants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantWarehouseStates_PlantWarehouses_PlantWarehouseReadMode~",
                table: "PlantWarehouseStates",
                column: "PlantWarehouseReadModelId",
                principalTable: "PlantWarehouses",
                principalColumn: "Id");
        }
    }
}