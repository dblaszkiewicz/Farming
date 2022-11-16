﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Identity;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class FertilizerWarehouseWriteConfiguration : IEntityTypeConfiguration<FertilizerWarehouse>, IWriteConfiguration
    {
        private readonly ITenantGetter _tenantGetter;

        public FertilizerWarehouseWriteConfiguration(ITenantGetter tenantGetter)
        {
            _tenantGetter = tenantGetter;
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouse> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseId(x));

            builder
                .Property(x => x.Name)
                .HasConversion(x => x.Value, x => new FertilizerWarehouseName(x));

            builder
                .HasQueryFilter(x => x.TenantId == _tenantGetter.Tenant);

            builder.ToTable("FertilizerWarehouses");
        }
    }
}
