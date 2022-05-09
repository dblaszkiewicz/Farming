using Farming.Application.Consts;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Farming.Infrastructure.EF
{
    internal static class DbInitializer
    {
        public static void CreateAndSeedDatabase(ReadDbContext context)
        {
            if (!(context.Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
            {
                context.Database.Migrate();

                using var transaction = context.Database.BeginTransaction();

                SeedData(context);

                transaction.Commit();
            }
        }

        private static void SeedData(ReadDbContext context)
        {
            AddUsers(context);
            AddLands(context);
            AddWarehouses(context);

            AddPlants(context);

            context.SaveChanges();
        }

        private static void AddUsers(ReadDbContext context)
        {
            var admin = new UserReadModel("admin", "Haslo12", "Dawid");
            context.Users.Add(admin);
        }

        private static void AddLands(ReadDbContext context)
        {
            var lands = new List<LandReadModel>()
            {
                 new LandReadModel("Klasa IIIa", "Pole pierwsze", 0.75m),
                 new LandReadModel("Klasa I", "Pole drugie", 0.51m),
                 new LandReadModel("Klasa IVb", "Pole trzecie", 2.21m),
                 new LandReadModel("Klasa II", "Pole czwarte", 1.5m),
                 new LandReadModel("Klasa V", "Pole piąte", 3.75m),
                 new LandReadModel("Klasa I", "Pole szóste", 6.24m)
            };

            context.Lands.AddRange(lands);
        }

        private static void AddWarehouses(ReadDbContext context)
        {
            var plantWarehouses = new List<PlantWarehouseReadModel>()
            {
                new PlantWarehouseReadModel("Garaż 1"),
                new PlantWarehouseReadModel("Garaż 2"),
                new PlantWarehouseReadModel("Przechowalnia"),
                new PlantWarehouseReadModel("Wiata")
            };

            var pesticideWarehouses = new List<PesticideWarehouseReadModel>()
            {
                new PesticideWarehouseReadModel("Garaż 1"),
                new PesticideWarehouseReadModel("Garaż 2"),
                new PesticideWarehouseReadModel("Przechowalnia"),
                new PesticideWarehouseReadModel("Wiata")
            };

            var fertilizerWarehouses = new List<FertilizerWarehouseReadModel>()
            {
                new FertilizerWarehouseReadModel("Garaż 1"),
                new FertilizerWarehouseReadModel("Garaż 2"),
                new FertilizerWarehouseReadModel("Przechowalnia"),
                new FertilizerWarehouseReadModel("Wiata")
            };

            context.PlantWarehouses.AddRange(plantWarehouses);
            context.PesticideWarehouses.AddRange(pesticideWarehouses);
            context.FertilizerWarehouses.AddRange(fertilizerWarehouses);
        }

        private static void AddPlants(ReadDbContext context)
        {
            var wheat = new PlantReadModel("Pszenica", 150, "kg", "Zboże typu pszenica");
            var barley = new PlantReadModel("Jęczmień", 160, "kg", "Zboże typu jęczmień");
            var rye = new PlantReadModel("Żyto", 210, "kg", "Zboże typu żyto");
            var oat = new PlantReadModel("Owies", 220, "kg", "Zboże typu owies");
            var potato = new PlantReadModel("Ziemniaki", 6000, "kg", "Warzywo typu ziemniak");
            var redBeets = new PlantReadModel("Buraczki czerwone", 800, "tys. szt.", "Warzywo typu burak");
            var onion = new PlantReadModel("Cebula", 650, "tys. szt.", "Warzywo typu cebula");

            var nawozyAzotowe = new FertilizerTypeReadModel("Azot", "Grupa nawozów azotowych", 
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Amoniak", "Nawozy amoniakowe", 150, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Saletrzak", "Nawozy saletrzane", 90, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Saletrzak-Amoniak", "Nawozy saletrzano-amonowe", 160, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Mocznik", "Nawozy amidowe", 130, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    })
                }
            );

            var nawozyFosforowe = new FertilizerTypeReadModel("Fosfor", "Grupa nawozów fosforowych",
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Precypitat", "Nawóz fosforowy zawierający rozpuszczalny w wodzie diwodorofosforan wapnia",
                        110, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Supertomasyna", "Mineralny nawóz fosforowy", 200, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Fosforan amonu", "Nawóz typu fosforan amonu", 90, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Mączka fosforytowa", "Mączki fosforytowe i kostne", 170, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Polifosforan", "Polimery zbudowane z merów fosforanowych", 170, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Metafosforan", "Sole lub estry kwasu metafosforowego", 170, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    })
                }
            );

            var nawozyPotasowe = new FertilizerTypeReadModel("Potas", "Grupa nawozów potasowych",
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Chlorek", "Nawozy stosowane dla roślin niewrażliwych na nadmiar chloru, gdzie potas występuje w postaci chlorku potasu",
                        70, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new FertilizerReadModel("Siarczan", "Potas występuje w postaci siarczanu potasu, może je stosować dla wszystkich roślin",
                        160, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                }
            );

            var typOprysku1 = new PesticideTypeReadModel("Nazwa typu 1", "Opis typu 1",
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Oprysk1", "Opis oprysk1",
                        70, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new PesticideReadModel("Oprysk2", "Opis oprysk2",
                        160, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                }
            );

            var typOprysku2 = new PesticideTypeReadModel("Nazwa typu 2", "Opis typu 2",
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Oprysk3", "Opis oprysk3",
                        70, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                    new PesticideReadModel("Oprysk4", "Opis oprysk4",
                        160, new List<PlantReadModel>()
                    {
                        wheat, barley, rye, oat, potato, redBeets, onion
                    }),
                }
            );

            context.FertilizerTypes.Add(nawozyAzotowe);
            context.FertilizerTypes.Add(nawozyFosforowe);
            context.FertilizerTypes.Add(nawozyPotasowe);

            context.PesticideTypes.Add(typOprysku1);
            context.PesticideTypes.AddRange(typOprysku2);
        }
    }
}
