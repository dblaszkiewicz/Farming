using Farming.Domain.Entities;
using Farming.Infrastructure.EF.Config.WriteConfigurations;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        private readonly ITenantGetter _tenantGetter;

        public WriteDbContext(DbContextOptions<WriteDbContext> options, ITenantGetter tenantGetter) : base(options)
        {
            _tenantGetter = tenantGetter;
        }

        public DbSet<Fertilizer> Fertilizers { get; set; }
        public DbSet<FertilizerAction> FertilizerActions { get; set; }
        public DbSet<FertilizerType> FertilizerTypes { get; set; }
        public DbSet<FertilizerWarehouse> FertilizerWarehouses { get; set; }
        public DbSet<FertilizerWarehouseDelivery> FertilizerWarehouseDeliveries { get; set; }
        public DbSet<FertilizerWarehouseState> FertilizerWarehouseStates { get; set; }

        public DbSet<Pesticide> Pesticides { get; set; }
        public DbSet<PesticideAction> PesticideActions { get; set; }
        public DbSet<PesticideType> PesticideTypes { get; set; }
        public DbSet<PesticideWarehouse> PesticideWarehouses { get; set; }
        public DbSet<PesticideWarehouseDelivery> PesticideWarehouseDeliveries { get; set; }
        public DbSet<PesticideWarehouseState> PesticideWarehouseStates { get; set; }

        public DbSet<Plant> Plants { get; set; }
        public DbSet<PlantAction> PlantActions { get; set; }
        public DbSet<PlantWarehouse> PlantWarehouses { get; set; }
        public DbSet<PlantWarehouseDelivery> PlantWarehouseDeliveries { get; set; }
        public DbSet<PlantWarehouseState> PlantWarehouseStates { get; set; }

        public DbSet<Land> Lands { get; set; }
        public DbSet<LandRealization> LandRealizations { get; set; }

        public DbSet<Season> Seasons { get; set; }
        public DbSet<User> Users { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FertilizerActionWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerTypeWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseDeliveryWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseStateWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new FertilizerWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new LandRealizationWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new LandWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideActionWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideTypeWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseDeliveryWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseStateWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PesticideWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantActionWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantWarehouseDeliveryWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantWarehouseStateWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantWarehouseWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new PlantWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new SeasonWriteConfiguration(_tenantGetter.Tenant));
            modelBuilder.ApplyConfiguration(new UserWriteConfiguration(_tenantGetter.Tenant));
        }
    }
}
