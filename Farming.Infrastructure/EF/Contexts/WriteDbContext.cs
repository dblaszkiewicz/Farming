using Farming.Domain.Entities;
using Farming.Infrastructure.EF.Config.WriteConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Farming.Infrastructure.EF.Contexts
{
    public sealed class WriteDbContext : DbContext
    {
        public DbSet<Fertilizer> Fertilizers { get; set; }
        public DbSet<FertilizerWarehouse> FertilizerWarehouses { get; set; }
        public DbSet<FertilizerWarehouseDelivery> FertilizerWarehouseDeliveries { get; set; }
        public DbSet<FertilizerWarehouseState> FertilizerWarehouseStates { get; set; }
        public DbSet<FertilizerType> FertilizerTypes { get; set; }
        public DbSet<Plant> Plants { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly(), x => x.GetInterfaces().Contains(typeof(IWriteConfiguration)));

            //var configuration = new WriteConfiguration();
            //modelBuilder.ApplyConfiguration<Fertilizer>(configuration);
            //modelBuilder.ApplyConfiguration<FertilizerWarehouse>(configuration);
            //modelBuilder.ApplyConfiguration<FertilizerWarehouseDelivery>(configuration);
            //modelBuilder.ApplyConfiguration<FertilizerWarehouseState>(configuration);
            //modelBuilder.ApplyConfiguration<FertilizerType>(configuration);
            //modelBuilder.ApplyConfiguration<Plant>(configuration);
        }
    }
}
