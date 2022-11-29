﻿// <auto-generated />
using System;
using Farming.Domain.Consts;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Farming.Infrastructure.EF.Migrations.Write
{
    [DbContext(typeof(WriteDbContext))]
    [Migration("20221129185753_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Farming.Domain.Entities.Fertilizer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("FertilizerTypeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("RequiredAmountPerHectare")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerTypeId");

                    b.HasIndex("TenantId");

                    b.ToTable("Fertilizers", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FertilizerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LandRealizationId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerId");

                    b.HasIndex("LandRealizationId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("FertilzierActions", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("FertilizerTypes", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("FertilizerWarehouses", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouseDelivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FertilizerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FertilizerWarehouseStateId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerId");

                    b.HasIndex("FertilizerWarehouseStateId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("FertilizerWarehouseDeliveries", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.FertilizerWarehouseState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FertilizerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("FertilizerWarehouseId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerId");

                    b.HasIndex("FertilizerWarehouseId");

                    b.HasIndex("TenantId");

                    b.ToTable("FertilizerWarehouseStates", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Land", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Area")
                        .HasColumnType("numeric");

                    b.Property<string>("LandClass")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<LandStatusEnum>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Lands", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.LandRealization", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LandId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SeasonId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LandId");

                    b.HasIndex("SeasonId");

                    b.HasIndex("TenantId");

                    b.ToTable("LandRealizations", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Pesticide", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PesticideTypeId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("RequiredAmountPerHectare")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PesticideTypeId");

                    b.HasIndex("TenantId");

                    b.ToTable("Pesticides", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LandRealizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PesticideId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LandRealizationId");

                    b.HasIndex("PesticideId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("PesticideActions", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("PesticideTypes", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("PesticideWarehouses", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouseDelivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PesticideId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PesticideWarehouseStateId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PesticideId");

                    b.HasIndex("PesticideWarehouseStateId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("PesticideWarehouseDeliveries", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PesticideWarehouseState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PesticideId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PesticideWarehouseId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PesticideId");

                    b.HasIndex("PesticideWarehouseId");

                    b.HasIndex("TenantId");

                    b.ToTable("PesticideWarehouseStates", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("RequiredAmountPerHectare")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Plants", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantAction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LandRealizationId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LandRealizationId");

                    b.HasIndex("PlantId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("PlantActions", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("PlantWarehouses", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouseDelivery", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlantWarehouseStateId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("RealizationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.HasIndex("PlantWarehouseStateId");

                    b.HasIndex("TenantId");

                    b.HasIndex("UserId");

                    b.ToTable("PlantWarehouseDeliveries", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.PlantWarehouseState", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlantId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlantWarehouseId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.HasIndex("PlantWarehouseId");

                    b.HasIndex("TenantId");

                    b.ToTable("PlantWarehouseStates", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("Seasons", (string)null);
                });

            modelBuilder.Entity("Farming.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("TenantId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("FertilizerPlant", b =>
                {
                    b.Property<Guid>("SuitableFertilizersId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SuitablePlantsId")
                        .HasColumnType("uuid");

                    b.HasKey("SuitableFertilizersId", "SuitablePlantsId");

                    b.HasIndex("SuitablePlantsId");

                    b.ToTable("PlantFertilizers", (string)null);
                });

            modelBuilder.Entity("PesticidePlant", b =>
                {
                    b.Property<Guid>("SuitablePesticidesId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SuitablePlantsId")
                        .HasColumnType("uuid");

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
