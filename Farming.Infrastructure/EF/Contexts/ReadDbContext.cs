using Farming.Infrastructure.EF.Config;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Contexts
{
    internal sealed class ReadDbContext : DbContext
    {
        public DbSet<FertilizerReadModel> Fertilizers { get; set; }
        public DbSet<FertilizerWarehouseReadModel> FertilizerWarehouses { get; set; }
        public DbSet<FertilizerWarehouseDeliveryReadModel> FertilizerWarehouseDeliveries { get; set; }
        public DbSet<FertilizerWarehouseStateReadModel> FertilizerWarehouseStates { get; set; }
        public DbSet<FertilizerTypeReadModel> FertilizerTypes { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configuration = new ReadConfiguration3();
            modelBuilder.ApplyConfiguration<FertilizerReadModel>(configuration);
            modelBuilder.ApplyConfiguration<FertilizerWarehouseReadModel>(configuration);
            modelBuilder.ApplyConfiguration<FertilizerWarehouseDeliveryReadModel>(configuration);
            modelBuilder.ApplyConfiguration<FertilizerWarehouseStateReadModel>(configuration);
            modelBuilder.ApplyConfiguration<FertilizerTypeReadModel>(configuration);
        }
    }
}
