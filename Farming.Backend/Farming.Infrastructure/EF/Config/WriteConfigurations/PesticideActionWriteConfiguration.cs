using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideActionWriteConfiguration : IEntityTypeConfiguration<PesticideAction>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public PesticideActionWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PesticideAction> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideActionId(x));

            builder
                .Property(x => x.PesticideId)
                .HasConversion(x => x.Value, x => new PesticideId(x));

            builder
                .Property(x => x.LandRealizationId)
                .HasConversion(x => x.Value, x => new LandRealizationId(x));

            builder
                .Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new PesticideActionQuantity(x));

            builder
                .Property(x => x.RealizationDate)
                .HasConversion(x => x.Value, x => new PesticideActionRealizationDate(x));

            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.LandRealization)
                .WithMany(x => x.PesticideActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.PesticideActions)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter(x => x.TenantId == _context.Tenant.Value);

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideActions");
        }
    }
}
