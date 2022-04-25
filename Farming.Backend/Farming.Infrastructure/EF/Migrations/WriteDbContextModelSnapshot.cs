﻿// <auto-generated />
using System;
using Farming.Domain.Consts;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations
{
    [DbContext(typeof(WriteDbContext))]
    partial class WriteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Farming.Domain.Entities.Fertilizer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FertilizerTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RequiredAmountPerHectare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerTypeId");

                    b.ToTable("Fertilizers", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FertilizerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LandRealizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerId");

                    b.HasIndex("LandRealizationId");

                    b.HasIndex("UserId");

                    b.ToTable("FertilzierActions", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FertilizerTypes", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FertilizerWarehouses", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouseDelivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FertilizerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FertilizerWarehouseStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerId");

                    b.HasIndex("FertilizerWarehouseStateId");

                    b.HasIndex("UserId");

                    b.ToTable("FertilizerWarehouseDeliveries", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouseState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FertilizerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FertilizerWarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerId");

                    b.HasIndex("FertilizerWarehouseId");

                    b.ToTable("FertilizerWarehouseStates", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Land", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Area")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LandCLass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<LandStatusEnum>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Lands", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.LandRealization", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LandId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LandId");

                    b.HasIndex("SeasonId");

                    b.ToTable("LandRealizations", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Pesticide", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PesticideTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("RequiredAmountPerHectare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PesticideTypeId");

                    b.ToTable("Pesticides", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LandRealizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PesticideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LandRealizationId");

                    b.HasIndex("PesticideId");

                    b.HasIndex("UserId");

                    b.ToTable("PesticideActions", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PesticideTypes", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PesticideWarehouses", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouseDelivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PesticideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PesticideWarehouseStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PesticideId");

                    b.HasIndex("PesticideWarehouseStateId");

                    b.HasIndex("UserId");

                    b.ToTable("PesticideWarehouseDeliveries", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouseState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PesticideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PesticideWarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PesticideId");

                    b.HasIndex("PesticideWarehouseId");

                    b.ToTable("PesticideWarehouseStates", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RequiredAmountPerHectare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plants", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LandRealizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LandRealizationId");

                    b.HasIndex("PlantId");

                    b.HasIndex("UserId");

                    b.ToTable("PlantActions", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("PlantWarehouses", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouseDelivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlantWarehouseStateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.HasIndex("PlantWarehouseStateId");

                    b.HasIndex("UserId");

                    b.ToTable("PlantWarehouseDeliveries", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouseState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PlantWarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.HasIndex("PlantWarehouseId");

                    b.ToTable("PlantWarehouseStates", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Seasons", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Version")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FertilizerPlant", b =>
                {
                    b.Property<Guid>("SuitableFertilizersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuitablePlantsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SuitableFertilizersId", "SuitablePlantsId");

                    b.HasIndex("SuitablePlantsId");

                    b.ToTable("PlantFertilizers", (string)null);
                });

            modelBuilder.Entity("PesticidePlant", b =>
                {
                    b.Property<Guid>("SuitablePesticidesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SuitablePlantsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SuitablePesticidesId", "SuitablePlantsId");

                    b.HasIndex("SuitablePlantsId");

                    b.ToTable("PlantPesticides", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Fertilizer", b =>
                {
                    b.HasOne("Farming.Domain.Entities.FertilizerType", "FertilizerType")
                        .WithMany("Fertilizers")
                        .HasForeignKey("FertilizerTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FertilizerType");
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerAction", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Fertilizer", "Fertilizer")
                        .WithMany("FertilizerActions")
                        .HasForeignKey("FertilizerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.LandRealization", "LandRealization")
                        .WithMany("FertilizerActions")
                        .HasForeignKey("LandRealizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.User", "User")
                        .WithMany("FertilizerActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fertilizer");

                    b.Navigation("LandRealization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouseDelivery", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Fertilizer", "Fertilizer")
                        .WithMany("FertilizerWarehouseDeliveries")
                        .HasForeignKey("FertilizerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.FertilizerWarehouseState", "FertilizerWarehouseState")
                        .WithMany("FertilizerWarehouseDeliveries")
                        .HasForeignKey("FertilizerWarehouseStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.User", "User")
                        .WithMany("FertilizerDeliveries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fertilizer");

                    b.Navigation("FertilizerWarehouseState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouseState", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Fertilizer", "Fertilizer")
                        .WithMany("FertilizerWarehouseStates")
                        .HasForeignKey("FertilizerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.FertilizerWarehouse", "FertilizerWarehouse")
                        .WithMany("States")
                        .HasForeignKey("FertilizerWarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Fertilizer");

                    b.Navigation("FertilizerWarehouse");
                });

            modelBuilder.Entity("Farming.Domain.Entities.LandRealization", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Land", "Land")
                        .WithMany("LandRealizations")
                        .HasForeignKey("LandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.Season", "Season")
                        .WithMany("LandRealizations")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Land");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("Farming.Domain.Entities.Pesticide", b =>
                {
                    b.HasOne("Farming.Domain.Entities.PesticideType", "PesticideType")
                        .WithMany("Pesticides")
                        .HasForeignKey("PesticideTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PesticideType");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideAction", b =>
                {
                    b.HasOne("Farming.Domain.Entities.LandRealization", "LandRealization")
                        .WithMany("PesticideActions")
                        .HasForeignKey("LandRealizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.Pesticide", "Pesticide")
                        .WithMany("PesticideActions")
                        .HasForeignKey("PesticideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.User", "User")
                        .WithMany("PesticideActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LandRealization");

                    b.Navigation("Pesticide");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouseDelivery", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Pesticide", "Pesticide")
                        .WithMany("PesticideWarehouseDeliveries")
                        .HasForeignKey("PesticideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.PesticideWarehouseState", "PesticideWarehouseState")
                        .WithMany("PesticideWarehouseDeliveries")
                        .HasForeignKey("PesticideWarehouseStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.User", "User")
                        .WithMany("PesticideDeliveries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pesticide");

                    b.Navigation("PesticideWarehouseState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouseState", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Pesticide", "Pesticide")
                        .WithMany("PesticideWarehouseStates")
                        .HasForeignKey("PesticideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.PesticideWarehouse", "PesticideWarehouse")
                        .WithMany("States")
                        .HasForeignKey("PesticideWarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pesticide");

                    b.Navigation("PesticideWarehouse");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantAction", b =>
                {
                    b.HasOne("Farming.Domain.Entities.LandRealization", "LandRealization")
                        .WithMany("PlantActions")
                        .HasForeignKey("LandRealizationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.Plant", "Plant")
                        .WithMany("PlantActions")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.User", "User")
                        .WithMany("PlantActions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("LandRealization");

                    b.Navigation("Plant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouseDelivery", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Plant", "Plant")
                        .WithMany("PlantWarehouseDeliveries")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.PlantWarehouseState", "PlantWarehouseState")
                        .WithMany("PlantWarehouseDeliveries")
                        .HasForeignKey("PlantWarehouseStateId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.User", "User")
                        .WithMany("PlantDeliveries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Plant");

                    b.Navigation("PlantWarehouseState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouseState", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Plant", "Plant")
                        .WithMany("PlantWarehouseStates")
                        .HasForeignKey("PlantId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.PlantWarehouse", "PlantWarehouse")
                        .WithMany("States")
                        .HasForeignKey("PlantWarehouseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Plant");

                    b.Navigation("PlantWarehouse");
                });

            modelBuilder.Entity("FertilizerPlant", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Fertilizer", null)
                        .WithMany()
                        .HasForeignKey("SuitableFertilizersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.Plant", null)
                        .WithMany()
                        .HasForeignKey("SuitablePlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PesticidePlant", b =>
                {
                    b.HasOne("Farming.Domain.Entities.Pesticide", null)
                        .WithMany()
                        .HasForeignKey("SuitablePesticidesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Farming.Domain.Entities.Plant", null)
                        .WithMany()
                        .HasForeignKey("SuitablePlantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Farming.Domain.Entities.Fertilizer", b =>
                {
                    b.Navigation("FertilizerActions");

                    b.Navigation("FertilizerWarehouseDeliveries");

                    b.Navigation("FertilizerWarehouseStates");
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerType", b =>
                {
                    b.Navigation("Fertilizers");
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouse", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouseState", b =>
                {
                    b.Navigation("FertilizerWarehouseDeliveries");
                });

            modelBuilder.Entity("Farming.Domain.Entities.Land", b =>
                {
                    b.Navigation("LandRealizations");
                });

            modelBuilder.Entity("Farming.Domain.Entities.LandRealization", b =>
                {
                    b.Navigation("FertilizerActions");

                    b.Navigation("PesticideActions");

                    b.Navigation("PlantActions");
                });

            modelBuilder.Entity("Farming.Domain.Entities.Pesticide", b =>
                {
                    b.Navigation("PesticideActions");

                    b.Navigation("PesticideWarehouseDeliveries");

                    b.Navigation("PesticideWarehouseStates");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideType", b =>
                {
                    b.Navigation("Pesticides");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouse", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouseState", b =>
                {
                    b.Navigation("PesticideWarehouseDeliveries");
                });

            modelBuilder.Entity("Farming.Domain.Entities.Plant", b =>
                {
                    b.Navigation("PlantActions");

                    b.Navigation("PlantWarehouseDeliveries");

                    b.Navigation("PlantWarehouseStates");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouse", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouseState", b =>
                {
                    b.Navigation("PlantWarehouseDeliveries");
                });

            modelBuilder.Entity("Farming.Domain.Entities.Season", b =>
                {
                    b.Navigation("LandRealizations");
                });

            modelBuilder.Entity("Farming.Domain.Entities.User", b =>
                {
                    b.Navigation("FertilizerActions");

                    b.Navigation("FertilizerDeliveries");

                    b.Navigation("PesticideActions");

                    b.Navigation("PesticideDeliveries");

                    b.Navigation("PlantActions");

                    b.Navigation("PlantDeliveries");
                });
#pragma warning restore 612, 618
        }
    }
}
