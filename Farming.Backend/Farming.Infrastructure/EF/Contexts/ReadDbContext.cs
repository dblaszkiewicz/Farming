using Farming.Infrastructure.EF.Config.ReadConfiguration;
using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        internal Tenant Tenant { get; }

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

        public ReadDbContext(DbContextOptions<ReadDbContext> options, ITenantGetter tenantGetter) : base(options)
        {
            Tenant = tenantGetter.Tenant;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FertilizerActionReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerTypeReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseDeliveryReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseStateReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerWarehouseReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new FertilizerReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new LandRealizationReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new LandReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideActionReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideTypeReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseDeliveryReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseStateReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideWarehouseReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PesticideReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantActionReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantWarehouseDeliveryReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantWarehouseStateReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantWarehouseReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new PlantReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new SeasonReadConfiguration(this));
            modelBuilder.ApplyConfiguration(new UserReadConfiguration(this));
        }
    }
}
