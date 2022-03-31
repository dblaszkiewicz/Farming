using Farming.Domain.Entities;
using Farming.Infrastructure.EF.Config.WriteConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Farming.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), 
                x => x.GetInterfaces().Contains(typeof(IWriteConfiguration)));
        }
    }
}
