﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Plant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PlantWarehouseWriteConfiguration : IEntityTypeConfiguration<PlantWarehouse>, IWriteConfiguration
    {
        public void Configure(EntityTypeBuilder<PlantWarehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PlantWarehouseId(x));

            builder.ToTable("PlantWarehouses");
        }
    }
}