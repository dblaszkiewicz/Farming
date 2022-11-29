﻿using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.ReadConfiguration
{
    internal sealed class FertilizerWarehouseReadConfiguration : IEntityTypeConfiguration<FertilizerWarehouseReadModel>, IReadConfiguration
    {
        private readonly ReadDbContext _context;

        public FertilizerWarehouseReadConfiguration(ReadDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<FertilizerWarehouseReadModel> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasQueryFilter(x => x.TenantId == _context.TenantId.Value);

            builder.HasIndex(x => x.TenantId);

            builder.Property(x => x.Version).IsConcurrencyToken();

            builder.ToTable("FertilizerWarehouses");
        }
    }
}
