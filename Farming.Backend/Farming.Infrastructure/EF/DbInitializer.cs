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
                 new LandReadModel("Klasa IIIa", "Działka pierwsza", 0.75m),
                 new LandReadModel("Klasa I", "Działka druga", 0.51m),
                 new LandReadModel("Klasa IVb", "Działka trzecia", 2.21m),
                 new LandReadModel("Klasa II", "Działka czwarta", 1.5m),
                 new LandReadModel("Klasa V", "Działka piąta", 6.75m),
            };

            context.Lands.AddRange(lands);
        }

        private static void AddWarehouses(ReadDbContext context)
        {
            var plantWarehouses = new List<PlantWarehouseReadModel>()
            {
                new PlantWarehouseReadModel("Garaż"),
                new PlantWarehouseReadModel("Przechowalnia")
            };

            var pesticideWarehouses = new List<PesticideWarehouseReadModel>()
            {
                new PesticideWarehouseReadModel("Garaż"),
                new PesticideWarehouseReadModel("Przechowalnia")
            };

            var fertilizerWarehouses = new List<FertilizerWarehouseReadModel>()
            {
                new FertilizerWarehouseReadModel("Garaż"),
                new FertilizerWarehouseReadModel("Przechowalnia")
            };

            context.PlantWarehouses.AddRange(plantWarehouses);
            context.PesticideWarehouses.AddRange(pesticideWarehouses);
            context.FertilizerWarehouses.AddRange(fertilizerWarehouses);
        }

        private static void AddPlants(ReadDbContext context)
        {
            var pszenica = new PlantReadModel("Pszenica", 150, "kg", "Rodzaj zbóż z rodziny wiechlinowatych");
            var jeczmien = new PlantReadModel("Jęczmień", 160, "kg", "Rodzaj zbóż z rodziny wiechlinowatych");
            var zyto = new PlantReadModel("Żyto", 210, "kg", "Rodzaj zbóż z rodziny wiechlinowatych");
            var owies = new PlantReadModel("Owies", 220, "kg", "Rodzaj zbóż z rodziny wiechlinowatych");
            var ziemniak = new PlantReadModel("Ziemniaki", 6000, "kg", "Gatunek rośliny należący do rodziny psiankowatych");
            var czerwony_burak = new PlantReadModel("Czerwony burak", 800, "tys. szt.", "Grupa kultywarów podgatunku buraka zwyczajnego");
            var cebula = new PlantReadModel("Cebula", 650, "tys. szt.", "Warzywo należące do rodziny amarylkowatych");

            var nawozyAzotowe = new FertilizerTypeReadModel("Azot", "Grupa nawozów azotowych", 
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Amoniak", "Nawozy amoniakowe", 150, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Saletrzak", "Nawozy saletrzane", 90, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Saletrzak-Amoniak", "Nawozy saletrzano-amonowe", 160, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Mocznik", "Nawozy amidowe", 130, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var nawozyFosforowe = new FertilizerTypeReadModel("Fosfor", "Grupa nawozów fosforowych",
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Precypitat", "Nawóz fosforowy zawierający rozpuszczalny w wodzie diwodorofosforan wapnia",
                        110, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Supertomasyna", "Mineralny nawóz fosforowy", 200, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Fosforan amonu", "Nawóz typu fosforan amonu", 90, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Mączka fosforytowa", "Mączki fosforytowe i kostne", 170, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Polifosforan", "Polimery zbudowane z merów fosforanowych", 170, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Metafosforan", "Sole lub estry kwasu metafosforowego", 170, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var nawozyPotasowe = new FertilizerTypeReadModel("Potas", "Grupa nawozów potasowych",
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Chlorek", "Nawozy stosowane dla roślin niewrażliwych na nadmiar chloru, gdzie potas występuje w postaci chlorku potasu",
                        70, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Siarczan", "Potas występuje w postaci siarczanu potasu, może je stosować dla wszystkich roślin",
                        160, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                }
            );

            var herbicydy = new PesticideTypeReadModel("Herbicydy", "Środki do zwalczania niepożądanych roślin, głównie chwastów i gatunków inwazyjnych",
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Huzar Activ Plus", "Herbicyd selektywny o działaniu układowym stosowany nalistnie, koncentrat w formie zawiesiny olejowej do rozcieńczania wodą (OD).",
                        1000, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("Chwastox Trio", "Herbicyd selektywny o działaniu układowym, stosowanym nalistnie, w formie płynu do sporządzania roztworu wodnego.",
                        1500, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Arcade 880 EC", "Herbicyd selektywny o działaniu zwalczania jednorocznych chwastów jednoliściennych oraz dwuliściennych w ziemniaku",
                        900, new List<PlantReadModel>()
                    {
                        ziemniak
                    }),
                    new PesticideReadModel("Syngenta Boxer 800 EC", "Herbicyd selektywny stosowany doglebowo i nalistnie, przeznaczony do selektywnego zwalczania niektórych rocznych chwastów jednoliściennych i dwuliściennych",
                        900, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                }
            );

            var zoocydy = new PesticideTypeReadModel("Zoocydy", "Środki do zwalczania szkodników",
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Karate zeon", "Preparat na stonkę na ziemniaki",
                        700, new List<PlantReadModel>()
                    {
                        ziemniak
                    }),
                    new PesticideReadModel("Sherpa 100 EC", "Środek owadobójczy w formie koncentratu do sporządzania emulsji wodnej, przeznaczony do zwalczania szkodników gryzących i ssących",
                        300, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Cyperkill Max 500EC", "Środek owadobójczy w formie koncentratu do sporządzania emulsji wodnej, o działaniu kontaktowym i żołądkowym",
                        50, new List<PlantReadModel>()
                    {
                        ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("Deltaro owadobójczy", "Środek owadobójczy o działaniu kontaktowym i żołądkowym, przeznaczonym do zwalczania szkodników gryzących i kłująco – ssących",
                        140, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var fungicydy = new PesticideTypeReadModel("Fungicydy ", "Środki do zwalczania chorób",
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Tarcza Łan 250 EW", "Fungicyd w formie płynu do sporządzania emulsji wodnej o działaniu układowym do stosowania zapobiegawczego lub z chwilą pojawienia się pierwszych objawów choroby",
                        600, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("Tern 750 EC", "Koncentrat do sporządzania emulsji wodnej (EC) o działaniu układowym, do stosowania zapobiegawczego i interwencyjnego do ochrony przed chorobami grzybowymi.",
                        750, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Plexeo 60 EC", "Fungicyd w formie rozpuszczalnego koncentratu (EC) do sporządzania roztworu wodnego o działaniu systemicznym do stosowania zapobiegawczego, interwencyjnego oraz wyniszczającego.",
                        1500, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Soligor 425EC", "Fungicyd w formie koncentratu do sporządzania emulsji wodnej o działaniu układowym do stosowania zapobiegawczego,interwencyjnego oraz wyniszczającego.",
                        900, new List<PlantReadModel>()
                    {
                        ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var regulator_wzrostu = new PesticideTypeReadModel("Regulator wzrostu", "Stymulują lub hamują różne procesy u roślin",
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Stabilan 750 SL", "Hamuje wzrost, skraca i usztywnia źdźbło zbóż, w rezultacie zapobiegając ich wyleganiu",
                        600, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Medax Max", "Regulator wzrostu roślin w postaci granul do sporządzenia zawiesiny wodnej o działaniu systemicznym. Środek stosuje się w celu redukcji wzrostu roślin",
                        1200, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("MODDUS 250EC", "Środek z grupy regulatorów wzrostu roślin, w formie koncentratu do sporządzania emulsji wodnej",
                        1600, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            context.FertilizerTypes.Add(nawozyAzotowe);
            context.FertilizerTypes.Add(nawozyFosforowe);
            context.FertilizerTypes.Add(nawozyPotasowe);

            context.PesticideTypes.Add(herbicydy);
            context.PesticideTypes.AddRange(zoocydy);
            context.PesticideTypes.AddRange(fungicydy);
            context.PesticideTypes.AddRange(regulator_wzrostu);
        }
    }
}
