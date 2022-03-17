using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal class PesticideWarehouseStateWriteConfiguration : IEntityTypeConfiguration<PesticideWarehouseState>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideWarehouseState> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideWarehouseStateId(x));

            builder
                .Property(x => x.PesticideId)
                .HasConversion(x => x.Value, x => new PesticideId(x));

            builder
                .Property(x => x.PesticideWarehouseId)
                .HasConversion(x => x.Value, x => new PesticideWarehouseId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new PesticideWarehouseQuantity(x));

            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideWarehouseStates);

            builder
                .HasOne(x => x.PesticideWarehouse)
                .WithMany(x => x.States);

            builder.ToTable("PesticideWarehouseStates");
        }
    }
}
