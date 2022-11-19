using Farming.Domain.Entities;
using Farming.Infrastructure.EF.Config.WriteConfigurations;
using Farming.Infrastructure.EF.MultiTenancy;
using Farming.Shared.Abstractions.Domain;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        internal TenantId TenantId { get; }

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

        public WriteDbContext(DbContextOptions<WriteDbContext> options, ITenantGetter tenantGetter) : base(options)
        {
            TenantId = tenantGetter.TenantId;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ITenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity.TenantId == Guid.Empty)
                        {
                            entry.Entity.SetTenantId(TenantId);
                        }
                        break;
                }
            }

            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FertilizerActionWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerTypeWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseDeliveryWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseStateWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new LandRealizationWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new LandWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideActionWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideTypeWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseDeliveryWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseStateWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantActionWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantWarehouseDeliveryWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantWarehouseStateWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantWarehouseWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new SeasonWriteConfiguration(this));
            modelBuilder.ApplyConfiguration(new UserWriteConfiguration(this));
        }
    }
}
