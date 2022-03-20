﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Pesticide;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideWriteConfiguration : IEntityTypeConfiguration<Pesticide>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<Pesticide> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideId(x));

            builder
                .Property(x => x.PesticideTypeId)
                .HasConversion(x => x.Value, x => new PesticideTypeId(x));

            builder
                .Property(x => x.RequiredAmountPerHectare)
                .HasConversion(x => x.Value, x => new PesticideRequiredAmountPerHectare(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PesticideName(x));

            builder
                .Property(x => x.Description)
                .HasConversion(x => x.Value, x => new PesticideDescription(x));

            builder
                .HasOne(x => x.PesticideType)
                .WithMany(x => x.Pesticides)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.SuitablePlants)
                .WithMany(x => x.SuitablePesticides);

            builder.ToTable("Pesticides");
        }
    }
}
