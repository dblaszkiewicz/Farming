﻿using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class PlantWarehouseReadConfiguration : IEntityTypeConfiguration<PlantWarehouseReadModel>, IReadConfiguration
    {
        private readonly ITenantGetter _tenantGetter;

        public PlantWarehouseReadConfiguration(ITenantGetter tenantGetter)
        {
            _tenantGetter = tenantGetter;
        }

        public void Configure(EntityTypeBuilder<PlantWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _tenantGetter.Tenant);

            builder.ToTable("PlantWarehouses");
        }
    }
}
