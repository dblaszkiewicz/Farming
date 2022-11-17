using Farming.Infrastructure.EF.Config.ReadConfiguration;
using Farming.Infrastructure.EF.Config.WriteConfigurations;
using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Farming.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        private readonly ITenantGetter _tenantGetter;

        public ReadDbContext(DbContextOptions<ReadDbContext> options, ITenantGetter tenantGetter) : base(options)
        {
            _tenantGetter = tenantGetter;
        }

        public DbSet<FertilizerReadModel> Fertilizers { get; set; }
        public DbSet<FertilizerActionReadModel> FertilizerActions { get; set; }
        public DbSet<FertilizerTypeReadModel> FertilizerTypes { get; set; }
        public DbSet<FertilizerWarehouseReadModel> FertilizerWarehouses { get; set; }
        public DbSet<FertilizerWarehouseDeliveryReadModel> FertilizerWarehouseDeliveries { get; set; }
        public DbSet<FertilizerWarehouseStateReadModel> FertilizerWarehouseStates { get; set; }

        public DbSet<PesticideReadModel> Pesticides { get; set; }
        public DbSet<PesticideActionReadModel> PesticideActions { get; set; }
        public DbSet<PesticideTypeReadModel> PesticideTypes { get; set; }
        public DbSet<PesticideWarehouseReadModel> PesticideWarehouses { get; set; }
        public DbSet<PesticideWarehouseDeliveryReadModel> PesticideWarehouseDeliveries { get; set; }
        public DbSet<PesticideWarehouseStateReadModel> PesticideWarehouseStates { get; set; }

        public DbSet<PlantReadModel> Plants { get; set; }
        public DbSet<PlantActionReadModel> PlantActions { get; set; }
        public DbSet<PlantWarehouseReadModel> PlantWarehouses { get; set; }
        public DbSet<PlantWarehouseDeliveryReadModel> PlantWarehouseDeliveries { get; set; }
        public DbSet<PlantWarehouseStateReadModel> PlantWarehouseStates { get; set; }

        public DbSet<LandReadModel> Lands { get; set; }
        public DbSet<LandRealizationReadModel> LandRealizations { get; set; }

        public DbSet<SeasonReadModel> Seasons { get; set; }
        public DbSet<UserReadModel> Users { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FertilizerActionReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerTypeReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseDeliveryReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseStateReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new LandRealizationReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new LandReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideActionReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideTypeReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseDeliveryReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseStateReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantActionReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantWarehouseDeliveryReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantWarehouseStateReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantWarehouseReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new SeasonReadConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new UserReadConfiguration(_tenantGetter.Tenant));
        }
    }
}
