﻿using Farming.Domain.Entities;
using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Farming.Infrastructure.EF.Config.WriteConfigurations
{
    internal sealed class PesticideWarehouseDeliveryWriteConfiguration : IEntityTypeConfiguration<PesticideWarehouseDelivery>, IWriteConfiguration
    {
        private readonly WriteDbContext _context;

        public PesticideWarehouseDeliveryWriteConfiguration(WriteDbContext context)
        {
            _context = context;
        }

        public void Configure(EntityTypeBuilder<PesticideWarehouseDelivery> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(x => x.Value, x => new PesticideWarehouseDeliveryId(x));

            builder
                .Property(x => x.PesticideId)
                .HasConversion(x => x.Value, x => new PesticideId(x));

            builder
                .Property(x => x.PesticideWarehouseStateId)
                .HasConversion(x => x.Value, x => new PesticideWarehouseStateId(x));

            builder
                .Property(x => x.UserId)
                .HasConversion(x => x.Value, x => new UserId(x));

            builder
                .Property(x => x.Quantity)
                .HasConversion(x => x.Value, x => new PesticideWarehouseDeliveryQuantity(x));

            builder
                .Property(x => x.Price)
                .HasConversion(x => x.Value, x => new PesticideWarehouseDeliveryPrice(x));

            builder
                .Property(x => x.RealizationDate)
                .HasConversion(x => x.Value, x => new PesticideWarehouseDeliveryRealizationDate(x));

            builder
                .HasOne(x => x.Pesticide)
                .WithMany(x => x.PesticideWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.PesticideDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.PesticideWarehouseState)
                .WithMany(x => x.PesticideWarehouseDeliveries)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasQueryFilter((System.Linq.Expressions.Expression<Func<PesticideWarehouseDelivery, bool>>)(x => x.TenantId == _context.TenantId.Value));

            builder.HasIndex(x => x.TenantId);

            builder.ToTable("PesticideWarehouseDeliveries");
        }
    }
}
