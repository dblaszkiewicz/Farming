using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideTypeWriteConfiguration : IEntityTypeConfiguration<PesticideType>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideType> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideTypeId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PesticideTypeName(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new PesticideTypeDescription(x));

            builder.ToTable("PesticideTypes");
        }
    }
}
