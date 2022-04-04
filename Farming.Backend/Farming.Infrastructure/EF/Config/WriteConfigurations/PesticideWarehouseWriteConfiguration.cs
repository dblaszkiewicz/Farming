﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideWarehouseWriteConfiguration : IEntityTypeConfiguration<PesticideWarehouse>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<PesticideWarehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideWarehouseId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new PesticideWarehouseName(x));

            builder.ToTable("PesticideWarehouses");
        }
    }
}