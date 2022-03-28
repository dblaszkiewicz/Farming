using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PesticideWarehouseStateReadConfiguration : IEntityTypeConfiguration<PesticideWarehouseStateReadModel>, IReadConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideWarehouseStateReadModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideWarehouseStates)
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(x => x.PesticideWarehouse)
                .WithMany(x => x.States)
                .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("PesticideWarehouseStates");
        }
    }
}
