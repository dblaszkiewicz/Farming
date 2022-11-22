using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using Farming.Infrastructure.EF.MultiTenancy;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class SampleDataSeedHandler : IRequestHandler<SampleDataSeedQuery, bool>
    {
        private readonly ReadDbContext _context;
        private readonly ITenantGetter _tenantGetter;

        public SampleDataSeedHandler(ReadDbContext context, ITenantGetter tenantGetter)
        {
            _context = context;
            _tenantGetter = tenantGetter;
        }

        public async Task<bool> Handle(SampleDataSeedQuery request, CancellationToken cancellationToken)
        {
            var tenantId = _tenantGetter.TenantId.Value;

            var dataExists = await _context.Lands.AnyAsync();

            if (dataExists)
            {
                return await Task.FromResult(false);
            }

            var lands = new List<LandReadModel>()
            {
                 new LandReadModel("Klasa IIIa", "Działka pierwsza", 0.75m, tenantId),
                 new LandReadModel("Klasa I", "Działka druga", 0.51m, tenantId),
                 new LandReadModel("Klasa IVb", "Działka trzecia", 2.21m, tenantId),
                 new LandReadModel("Klasa II", "Działka czwarta", 1.5m, tenantId),
                 new LandReadModel("Klasa V", "Działka piąta", 6.75m, tenantId),
            };
            await _context.Lands.AddRangeAsync(lands);

            var plantWarehouses = new List<PlantWarehouseReadModel>()
            {
                new PlantWarehouseReadModel("Garaż", tenantId),
                new PlantWarehouseReadModel("Przechowalnia", tenantId)
            };

            var pesticideWarehouses = new List<PesticideWarehouseReadModel>()
            {
                new PesticideWarehouseReadModel("Garaż", tenantId),
                new PesticideWarehouseReadModel("Przechowalnia", tenantId)
            };

            var fertilizerWarehouses = new List<FertilizerWarehouseReadModel>()
            {
                new FertilizerWarehouseReadModel("Garaż", tenantId),
                new FertilizerWarehouseReadModel("Przechowalnia", tenantId)
            };

            await _context.PlantWarehouses.AddRangeAsync(plantWarehouses);
            await _context.PesticideWarehouses.AddRangeAsync(pesticideWarehouses);
            await _context.FertilizerWarehouses.AddRangeAsync(fertilizerWarehouses);

            var pszenica = new PlantReadModel("Pszenica", 150, "kg", "Rodzaj zbóż z rodziny wiechlinowatych", tenantId);
            var jeczmien = new PlantReadModel("Jęczmień", 160, "kg", "Rodzaj zbóż z rodziny wiechlinowatych", tenantId);
            var zyto = new PlantReadModel("Żyto", 210, "kg", "Rodzaj zbóż z rodziny wiechlinowatych", tenantId);
            var owies = new PlantReadModel("Owies", 220, "kg", "Rodzaj zbóż z rodziny wiechlinowatych", tenantId);
            var ziemniak = new PlantReadModel("Ziemniaki", 6000, "kg", "Gatunek rośliny należący do rodziny psiankowatych", tenantId);
            var czerwony_burak = new PlantReadModel("Czerwony burak", 800, "tys. szt.", "Grupa kultywarów podgatunku buraka zwyczajnego", tenantId);
            var cebula = new PlantReadModel("Cebula", 650, "tys. szt.", "Warzywo należące do rodziny amarylkowatych", tenantId);

            var nawozyAzotowe = new FertilizerTypeReadModel("Azot", "Grupa nawozów azotowych", tenantId,
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Amoniak", "Nawozy amoniakowe", 150, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Saletrzak", "Nawozy saletrzane", 90, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Saletrzak-Amoniak", "Nawozy saletrzano-amonowe", 160, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Mocznik", "Nawozy amidowe", 130, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var nawozyFosforowe = new FertilizerTypeReadModel("Fosfor", "Grupa nawozów fosforowych", tenantId,
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Precypitat", "Nawóz fosforowy zawierający rozpuszczalny w wodzie diwodorofosforan wapnia",
                        110, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Supertomasyna", "Mineralny nawóz fosforowy", 200, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Fosforan amonu", "Nawóz typu fosforan amonu", 90, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Mączka fosforytowa", "Mączki fosforytowe i kostne", 170, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Polifosforan", "Polimery zbudowane z merów fosforanowych", 170, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Metafosforan", "Sole lub estry kwasu metafosforowego", 170, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var nawozyPotasowe = new FertilizerTypeReadModel("Potas", "Grupa nawozów potasowych", tenantId,
                new List<FertilizerReadModel>()
                {
                    new FertilizerReadModel("Chlorek", "Nawozy stosowane dla roślin niewrażliwych na nadmiar chloru, gdzie potas występuje w postaci chlorku potasu",
                        70, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new FertilizerReadModel("Siarczan", "Potas występuje w postaci siarczanu potasu, może je stosować dla wszystkich roślin",
                        160, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                }
            );

            var herbicydy = new PesticideTypeReadModel("Herbicydy", "Środki do zwalczania niepożądanych roślin, głównie chwastów i gatunków inwazyjnych", tenantId,
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Huzar Activ Plus", "Herbicyd selektywny o działaniu układowym stosowany nalistnie, koncentrat w formie zawiesiny olejowej do rozcieńczania wodą (OD).",
                        1000, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("Chwastox Trio", "Herbicyd selektywny o działaniu układowym, stosowanym nalistnie, w formie płynu do sporządzania roztworu wodnego.",
                        1500, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Arcade 880 EC", "Herbicyd selektywny o działaniu zwalczania jednorocznych chwastów jednoliściennych oraz dwuliściennych w ziemniaku",
                        900, tenantId, new List<PlantReadModel>()
                    {
                        ziemniak
                    }),
                    new PesticideReadModel("Syngenta Boxer 800 EC", "Herbicyd selektywny stosowany doglebowo i nalistnie, przeznaczony do selektywnego zwalczania niektórych rocznych chwastów jednoliściennych i dwuliściennych",
                        900, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                }
            );

            var zoocydy = new PesticideTypeReadModel("Zoocydy", "Środki do zwalczania szkodników", tenantId,
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Karate zeon", "Preparat na stonkę na ziemniaki",
                        700, tenantId, new List<PlantReadModel>()
                    {
                        ziemniak
                    }),
                    new PesticideReadModel("Sherpa 100 EC", "Środek owadobójczy w formie koncentratu do sporządzania emulsji wodnej, przeznaczony do zwalczania szkodników gryzących i ssących",
                        300, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Cyperkill Max 500EC", "Środek owadobójczy w formie koncentratu do sporządzania emulsji wodnej, o działaniu kontaktowym i żołądkowym",
                        50, tenantId, new List<PlantReadModel>()
                    {
                        ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("Deltaro owadobójczy", "Środek owadobójczy o działaniu kontaktowym i żołądkowym, przeznaczonym do zwalczania szkodników gryzących i kłująco – ssących",
                        140, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var fungicydy = new PesticideTypeReadModel("Fungicydy ", "Środki do zwalczania chorób", tenantId,
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Tarcza Łan 250 EW", "Fungicyd w formie płynu do sporządzania emulsji wodnej o działaniu układowym do stosowania zapobiegawczego lub z chwilą pojawienia się pierwszych objawów choroby",
                        600, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("Tern 750 EC", "Koncentrat do sporządzania emulsji wodnej (EC) o działaniu układowym, do stosowania zapobiegawczego i interwencyjnego do ochrony przed chorobami grzybowymi.",
                        750, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Plexeo 60 EC", "Fungicyd w formie rozpuszczalnego koncentratu (EC) do sporządzania roztworu wodnego o działaniu systemicznym do stosowania zapobiegawczego, interwencyjnego oraz wyniszczającego.",
                        1500, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Soligor 425EC", "Fungicyd w formie koncentratu do sporządzania emulsji wodnej o działaniu układowym do stosowania zapobiegawczego,interwencyjnego oraz wyniszczającego.",
                        900, tenantId, new List<PlantReadModel>()
                    {
                        ziemniak, czerwony_burak, cebula
                    })
                }
            );

            var regulator_wzrostu = new PesticideTypeReadModel("Regulator wzrostu", "Stymulują lub hamują różne procesy u roślin", tenantId,
                new List<PesticideReadModel>()
                {
                    new PesticideReadModel("Stabilan 750 SL", "Hamuje wzrost, skraca i usztywnia źdźbło zbóż, w rezultacie zapobiegając ich wyleganiu",
                        600, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies
                    }),
                    new PesticideReadModel("Medax Max", "Regulator wzrostu roślin w postaci granul do sporządzenia zawiesiny wodnej o działaniu systemicznym. Środek stosuje się w celu redukcji wzrostu roślin",
                        1200, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    }),
                    new PesticideReadModel("MODDUS 250EC", "Środek z grupy regulatorów wzrostu roślin, w formie koncentratu do sporządzania emulsji wodnej",
                        1600, tenantId, new List<PlantReadModel>()
                    {
                        pszenica, jeczmien, zyto, owies, ziemniak, czerwony_burak, cebula
                    })
                }
            );

            await _context.FertilizerTypes.AddAsync(nawozyAzotowe);
            await _context.FertilizerTypes.AddAsync(nawozyFosforowe);
            await _context.FertilizerTypes.AddAsync(nawozyPotasowe);

            await _context.PesticideTypes.AddAsync(herbicydy);
            await _context.PesticideTypes.AddRangeAsync(zoocydy);
            await _context.PesticideTypes.AddRangeAsync(fungicydy);
            await _context.PesticideTypes.AddRangeAsync(regulator_wzrostu);

            await _context.SaveChangesAsync();

            return await Task.FromResult(true);
        }
    }
}
