using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<FertilizerReadModel>, IEntityTypeConfiguration<FertilizerWarehouseReadModel>, IEntityTypeConfiguration<FertilizerWarehouseDeliveryReadModel>, IEntityTypeConfiguration<FertilizerWarehouseStateReadModel>, IEntityTypeConfiguration<FertilizerTypeReadModel>
    {
        public void Configure(EntityTypeBuilder<PlantReadModel> builder)
        {
            builder.HasKey(p => p.Id);
            builder.ToTable("Plants");
        }

        public void Configure(EntityTypeBuilder<FertilizerReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasMany(x => x.SuitablePlants)
                .WithMany(x => x.SuitableFertilizers);

            builder
                .HasOne(x => x.FertilizerType)
                .WithMany(x => x.Fertilizers);

            builder.ToTable("Fertilizers");
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("FertilizerWarehouses");
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseDeliveryReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerWarehouseDeliveries);

            builder
                .HasOne(x => x.FertilizerWarehouseState)
                .WithMany(x => x.FertilizerWarehouseDeliveries);

            builder.ToTable("FertilizerWarehouseDeliveries");
        }

        public void Configure(EntityTypeBuilder<FertilizerTypeReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("FertilizerTypes");
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseStateReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.Fertilizer)
                .WithMany(x => x.FertilizerWarehouseStates);

            builder
                .HasOne(x => x.FertilizerWarehouse)
                .WithMany(x => x.States);

            builder.ToTable("FertilizerWarehouseStates");
        }
    }
}
