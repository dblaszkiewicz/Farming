using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal class FertilizerWarehouseStateReadConfiguration : IEntityTypeConfiguration<FertilizerWarehouseStateReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<FertilizerWarehouseStateReadModel> builder)
        {
            builder.HasKey(x => x.Id);

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
    }
}
