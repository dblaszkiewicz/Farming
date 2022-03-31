using Farming.Infrastructure.EF.Config.ReadConfiguration;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Farming.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), 
                x => x.GetInterfaces().Contains(typeof(IReadConfiguration)));
        }
    }
}
