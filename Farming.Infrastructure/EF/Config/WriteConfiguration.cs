using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<Fertilizer>, IEntityTypeConfiguration<FertilizerType>, IEntityTypeConfiguration<FertilizerWarehouse>, IEntityTypeConfiguration<FertilizerWarehouseDelivery>, IEntityTypeConfiguration<FertilizerWarehouseState>, IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Fertilizer> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.FertilizerTypeId)
                .HasConversion(x => x.Value, x => new FertilizerTypeId(x));

            builder
                .Property(x => x.RequiredAmountPerHectare)
                .HasConversion(x => x.Value, x => new FertilizerRequiredAmountPerHectare(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new FertilizerName(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new FertilizerDescription(x));

            builder
                .HasMany(x => x.SuitablePlants)
                .WithMany(x => x.SuitableFertilizers);

            builder
                .HasOne(x => x.FertilizerType)
                .WithMany(x => x.Fertilizers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Fertilizers");
        }

        public void Configure(EntityTypeBuilder<FertilizerType> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerTypeId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new FertilizerTypeName(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new FertilizerTypeDescription(x));

            builder.ToTable("FertilizerTypes");
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseId(x));

            builder.ToTable("FertilizerWarehouses");
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseDelivery> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryId(x));

            builder
                .Property(x => x.FertilizerId)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.FertilizerWarehouseStateId)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseStateId(x));

            builder
                .Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryQuantity(x));

            builder
                .Property(x => x.Price)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryPrice(x));

            builder
                .Property(x => x.RealizationDate)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseDeliveryRealizationDate(x));

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.FertilizerWarehouseState)
                .WithMany(x => x.FertilizerWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("FertilizerWarehouseDeliveries");
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseState> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseStateId(x));

            builder
                .Property(x => x.FertilizerId)
                .HasConversion(x => x.Value, x => new FertilizerId(x));

            builder
                .Property(x => x.FertilizerWarehouseId)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseQuantity(x));

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerWarehouseStates)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(x => x.FertilizerWarehouse)
                .WithMany(x => x.States)
                .OnDelete(DeleteBehavior.Restrict);


            builder.ToTable("FertilizerWarehouseStates");
        }

        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PlantName(x));

            builder
                .Property(x => x.RequiredAmountPerHectare)
                .HasConversion(x => x.Value, x => new PlantRequiredAmountPerHectare(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new PlantDescription(x));

            builder.ToTable("Plants");
        }
    }
}
