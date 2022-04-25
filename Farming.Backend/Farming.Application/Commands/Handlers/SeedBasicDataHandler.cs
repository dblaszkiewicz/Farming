using Farming.Application.Commands.Responses;
using Farming.Application.Consts;
using Farming.Domain.Consts;
using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class SeedBasicDataHandler : IRequestHandler<SeedBasicDataCommand, Response<SeedBasicDataResponse>>
    {
        private readonly IFertilizerTypeRepository _fertilizerTypeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly ILandRepository _landRepository;
        private readonly IPlantWarehouseRepository _plantWarehouseRepository;
        private readonly IPesticideWarehouseRepository _pesticideWarehouseRepository;
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;
        private readonly IPesticideTypeRepository _pesticideTypeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SeedBasicDataHandler(IFertilizerTypeRepository fertilizerTypeRepository, IUserRepository userRepository, ISeasonRepository seasonRepository,
            ILandRepository landRepository, IPlantWarehouseRepository plantWarehouseRepository, IPesticideWarehouseRepository pesticideWarehouseRepository,
            IFertilizerWarehouseRepository fertilizerWarehouseRepository, IPesticideTypeRepository pesticideTypeRepository, IUnitOfWork unitOfWork)
        {
            _fertilizerTypeRepository = fertilizerTypeRepository;
            _userRepository = userRepository;
            _seasonRepository = seasonRepository;
            _landRepository = landRepository;
            _plantWarehouseRepository = plantWarehouseRepository;
            _pesticideWarehouseRepository = pesticideWarehouseRepository;
            _fertilizerWarehouseRepository = fertilizerWarehouseRepository;
            _pesticideTypeRepository = pesticideTypeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<SeedBasicDataResponse>> Handle(SeedBasicDataCommand request, CancellationToken cancellationToken)
        {
            #region plant seed
            var wheat = new Plant("Pszenica", 1000, "Zboże typu pszenica");
            var barley = new Plant("Jęczmień", 1000, "Zboże typu jęczmień");
            var rye = new Plant("Żyto", 1000, "Zboże typu żyto");
            var oat = new Plant("Owies", 1000, "Zboże typu owies");
            var redBeets = new Plant("Buraczki czerwone", 1000, "Warzywo typu burak");
            var onion = new Plant("Cebula",1000, "Warzywo typu cebula");
            var potato = new Plant("Ziemniaki", 1000, "Warzywo typu ziemniak");
            #endregion

            #region fertilizer seed
            var nitrogenFertilizers = new FertilizerType("Azot","Grupa nawozów azotowych");

            var fertilizer1 = new Fertilizer(1000, "Amoniak", "Nawozy amoniakowe");
            fertilizer1.AddSutiablePlants(new List<Plant>
            {
                wheat,
                onion,
                potato
            });

            var fertilizer2 = new Fertilizer(1000, "Saletrzak", "Nawozy saletrzane");
            fertilizer2.AddSutiablePlants(new List<Plant>
            {
                oat,
                redBeets
            });

            var fertilizer3 = new Fertilizer(1000, "Saletrzak-Amoniak", "Nawozy saletrzano-amonowe");
            fertilizer3.AddSutiablePlants(new List<Plant>
            {
                barley
            });

            var fertilizer4 = new Fertilizer(1000, "Mocznik", "Nawozy amidowe");
            fertilizer4.AddSutiablePlants(new List<Plant>
            {
                wheat
            });

            nitrogenFertilizers.AddFertilizer(fertilizer1);
            nitrogenFertilizers.AddFertilizer(fertilizer2);
            nitrogenFertilizers.AddFertilizer(fertilizer3);
            nitrogenFertilizers.AddFertilizer(fertilizer4);


            var phosphorusFertilizers = new FertilizerType( "Fosfor", "Grupa nawozów fosforowych");

            var fertilizer5 = new Fertilizer(1000, "Precypitat", "Nawóz fosforowy zawierający rozpuszczalny w wodzie diwodorofosforan wapnia");
            fertilizer5.AddSutiablePlants(new List<Plant>
            {
                onion
            });

            var fertilizer6 = new Fertilizer(1000, "Supertomasyna", "Rodzaj sztucznego nawozu mineralnego fosforowego. Składa się z fosforu w postaci fosforanu dwuwapniowego. Jakością dorównuje superfosfatowi.");
            fertilizer6.AddSutiablePlants(new List<Plant>
            {
                wheat,
                onion
            });

            var fertilizer7 = new Fertilizer(1000, "Supertomasyna", "Nawóz fosforowy otrzymywany przez stapianie mielonych fosforytów z węglanem sodu. Supertomasyna jest termofosfatem sodowym");
            fertilizer7.AddSutiablePlants(new List<Plant>
            {
                rye,
                barley
            });

            var fertilizer8 = new Fertilizer(1000, "Termofosfaty", "Nawozy fosforowe powstałe w wyniku stopienia wysokoprocentowych fosforanów (fosforyty i apatyty) z topnikami m.in. węglanem sodu, " +
                "krzemionką, siarczanem sodu, siarczanem magnezu, siarczanem potasu. Stopnienie, a następnie dokładne zmielenie powoduje ze kwas fosforowy przechodzi w formę rozpuszczalną w wodzie i dostępną dla roślin.");
            fertilizer8.AddSutiablePlants(new List<Plant>
            {
                barley,
                wheat
            });

            var fertilizer9 = new Fertilizer(1000, "Polifosforany", "Polimery zbudowane z merów fosforanowych");
            fertilizer9.AddSutiablePlants(new List<Plant>
            {
                potato
            });

            var fertilizer10 = new Fertilizer(1000, "Metafosforany", "Sole lub estry kwasu metafosforowego");
            fertilizer10.AddSutiablePlants(new List<Plant>
            {
                onion
            });

            phosphorusFertilizers.AddFertilizer(fertilizer5);
            phosphorusFertilizers.AddFertilizer(fertilizer6);
            phosphorusFertilizers.AddFertilizer(fertilizer7);
            phosphorusFertilizers.AddFertilizer(fertilizer8);
            phosphorusFertilizers.AddFertilizer(fertilizer9);
            phosphorusFertilizers.AddFertilizer(fertilizer10);

            var potashFertilizers = new FertilizerType("Potas", "Grupa nawozów potasowych");

            var fertilizer11 = new Fertilizer(1000, "Chlorkowe", "Nawozy stosowane dla roślin niewrażliwych na nadmiar chloru, gdzie potas występuje w postaci chlorku potasu");
            fertilizer11.AddSutiablePlants(new List<Plant>
            {
                wheat
            });

            var fertilizer12 = new Fertilizer(1000, "Siarczanowe", "Potas występuje w postaci siarczanu potasu, może je stosować dla wszystkich roślin");
            fertilizer12.AddSutiablePlants(new List<Plant>
            {
                onion
            });

            potashFertilizers.AddFertilizer(fertilizer11);
            potashFertilizers.AddFertilizer(fertilizer12);
            #endregion

            #region pesticide seed
            var pesticideType1 = new PesticideType("Nazwa typu 1", "Opis typu 1");

            var pesticide1 = new Pesticide(100, "Oprysk1", "Opis1");
            pesticide1.AddSutiablePlants(new List<Plant>
            {
                rye,
                oat
            });

            var pesticide2 = new Pesticide(77, "Oprysk2", "Opis2");
            pesticide2.AddSutiablePlants(new List<Plant>
            {
                onion,
                wheat
            });

            pesticideType1.AddPesticide(pesticide1);
            pesticideType1.AddPesticide(pesticide2);

            var pesticideType2 = new PesticideType("Nazwa typu 2", "Opis typu 2");

            var pesticide3 = new Pesticide(44, "Oprysk3", "Opis3");
            pesticide3.AddSutiablePlants(new List<Plant>
            {
                potato,
                onion
            });

            var pesticide4 = new Pesticide(66, "Oprysk4", "Opis4");
            pesticide4.AddSutiablePlants(new List<Plant>
            {
                barley,
                wheat
            });

            pesticideType2.AddPesticide(pesticide3);
            pesticideType2.AddPesticide(pesticide4);
            #endregion

            var pesticideWarehouse = new PesticideWarehouse("Magazyn Głównyy");
            var fertilizerWarehouse = new FertilizerWarehouse("Magazyn Główny");
            var plantWarehouse = new PlantWarehouse("Magazyn Główny");

            var admin = new User("admin", "admin", "Administrator", true);

            var season = new Season();

            var land1 = new Land("Klasa A", LandStatusEnum.Harvested, "Pole pierwsze", 5);
            var land2 = new Land("Klasa B", LandStatusEnum.Harvested, "Pole drugie", 2);

            await _userRepository.AddAsync(admin);

            await _seasonRepository.AddAsync(season);

            await _landRepository.AddAsync(land1);
            await _landRepository.AddAsync(land2);

            await _pesticideWarehouseRepository.AddAsync(pesticideWarehouse);
            await _fertilizerWarehouseRepository.AddAsync(fertilizerWarehouse);
            await _plantWarehouseRepository.AddAsync(plantWarehouse);

            await _fertilizerTypeRepository.AddAsync(potashFertilizers);
            await _fertilizerTypeRepository.AddAsync(phosphorusFertilizers);
            await _fertilizerTypeRepository.AddAsync(nitrogenFertilizers);

            await _pesticideTypeRepository.AddAsync(pesticideType1);
            await _pesticideTypeRepository.AddAsync(pesticideType2);

            await _unitOfWork.CommitAsync();

            return new Response<SeedBasicDataResponse>();
        }
    }
}
