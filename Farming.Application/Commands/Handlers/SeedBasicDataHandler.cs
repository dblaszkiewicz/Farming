using Farming.Application.Commands.Responses;
using Farming.Domain.Entities;
using Farming.Domain.Repositories;
using Farming.Domain.ValueObjects.Fertilizer;
using Farming.Domain.ValueObjects.Land;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Domain.ValueObjects.Plant;
using Farming.Domain.ValueObjects.User;
using Farming.Shared.Abstractions.Commands;
using MediatR;

namespace Farming.Application.Commands.Handlers
{
    internal sealed class SeedBasicDataHandler : IRequestHandler<SeedBasicDataCommand, Response<SeedBasicDataResponse>>
    {
        private readonly IFertilizerTypeRepository _fertilizerTypeRepository;
        private readonly IPlantRepository _plantRepository;
        private readonly IUserRepository _userRepository;
        private readonly ISeasonRepository _seasonRepository;
        private readonly ILandRepository _landRepository;
        private readonly IPlantWarehouseRepository _plantWarehouseRepository;
        private readonly IPesticideWarehouseRepository _pesticideWarehouseRepository;
        private readonly IFertilizerWarehouseRepository _fertilizerWarehouseRepository;
        private readonly IPesticideTypeRepository _pesticideTypeRepository;

        public SeedBasicDataHandler(IFertilizerTypeRepository fertilizerTypeRepository, IPlantRepository plantRepository, IUserRepository userRepository, ISeasonRepository seasonRepository, ILandRepository landRepository, IPlantWarehouseRepository plantWarehouseRepository, IPesticideWarehouseRepository pesticideWarehouseRepository, IFertilizerWarehouseRepository fertilizerWarehouseRepository, IPesticideTypeRepository pesticideTypeRepository)
        {
            _fertilizerTypeRepository = fertilizerTypeRepository;
            _plantRepository = plantRepository;
            _userRepository = userRepository;
            _seasonRepository = seasonRepository;
            _landRepository = landRepository;
            _plantWarehouseRepository = plantWarehouseRepository;
            _pesticideWarehouseRepository = pesticideWarehouseRepository;
            _fertilizerWarehouseRepository = fertilizerWarehouseRepository;
            _pesticideTypeRepository = pesticideTypeRepository;
        }

        public async Task<Response<SeedBasicDataResponse>> Handle(SeedBasicDataCommand request, CancellationToken cancellationToken)
        {
            // TODO: zrobic fabryki, dodac wpisy w tabeli suitable fertilizer/suitable pesticide

            var fertilizerType1 = new FertilizerType( new FertilizerTypeName("Azot"), new FertilizerTypeDescription("Grupa nawozów azotowych"));

            fertilizerType1.AddFertilizer(new Fertilizer(fertilizerType1.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Amoniak"), new FertilizerDescription("Nawozy amoniakowe")));

            fertilizerType1.AddFertilizer(new Fertilizer(fertilizerType1.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Saletrzak"), new FertilizerDescription("Nawozy saletrzane")));

            fertilizerType1.AddFertilizer(new Fertilizer(fertilizerType1.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Saletrzak-Amoniak"), new FertilizerDescription("Nawozy saletrzano-amonowe")));

            fertilizerType1.AddFertilizer(new Fertilizer(fertilizerType1.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Mocznik"), new FertilizerDescription("Nawozy amidowe")));


            var fertilizerType2 = new FertilizerType( new FertilizerTypeName("Fosfor"), new FertilizerTypeDescription("Grupa nawozów fosforowych"));

            fertilizerType2.AddFertilizer(new Fertilizer(fertilizerType2.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Precypitat"), new FertilizerDescription("Nawóz fosforowy zawierający rozpuszczalny w wodzie diwodorofosforan wapnia")));

            fertilizerType2.AddFertilizer(new Fertilizer(fertilizerType2.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Supertomasyna"), new FertilizerDescription("Rodzaj sztucznego nawozu mineralnego fosforowego. Składa się z fosforu w postaci fosforanu dwuwapniowego. Jakością dorównuje superfosfatowi.")));

            fertilizerType2.AddFertilizer(new Fertilizer(fertilizerType2.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Supertomasyna"), new FertilizerDescription("Nawóz fosforowy otrzymywany przez stapianie mielonych fosforytów z węglanem sodu. Supertomasyna jest termofosfatem sodowym")));

            fertilizerType2.AddFertilizer(new Fertilizer(fertilizerType2.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Termofosfaty"), new FertilizerDescription("Nawozy fosforowe powstałe w wyniku stopienia wysokoprocentowych fosforanów (fosforyty i apatyty) z topnikami m.in. węglanem sodu, krzemionką, siarczanem sodu, siarczanem magnezu, siarczanem potasu. Stopnienie, a następnie dokładne zmielenie powoduje ze kwas fosforowy przechodzi w formę rozpuszczalną w wodzie i dostępną dla roślin.")));

            fertilizerType2.AddFertilizer(new Fertilizer(fertilizerType2.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Polifosforany"), new FertilizerDescription("Polimery zbudowane z merów fosforanowych")));

            fertilizerType2.AddFertilizer(new Fertilizer(fertilizerType2.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Metafosforany"), new FertilizerDescription("Sole lub estry kwasu metafosforowego")));


            var fertilizerType3 = new FertilizerType(new FertilizerTypeName("Potas"), new FertilizerTypeDescription("Grupa nawozów potasowych"));

            fertilizerType3.AddFertilizer(new Fertilizer(fertilizerType3.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Chlorkowe"), new FertilizerDescription("Nawozy stosowane dla roślin niewrażliwych na nadmiar chloru, gdzie potas występuje w postaci chlorku potasu")));

            fertilizerType3.AddFertilizer(new Fertilizer(fertilizerType3.Id, new FertilizerRequiredAmountPerHectare(1000), new FertilizerName("Siarczanowe"), new FertilizerDescription("Potas występuje w postaci siarczanu potasu, może je stosować dla wszystkich roślin")));


            var plant1 = new Plant(new PlantName("Pszenica"), new PlantRequiredAmountPerHectare(1000), new PlantDescription("Zboże typu pszenica"));

            var plant2 = new Plant(new PlantName("Jęczmień"), new PlantRequiredAmountPerHectare(1000), new PlantDescription("Zboże typu jęczmień"));

            var plant3 = new Plant(new PlantName("Żyto"), new PlantRequiredAmountPerHectare(1000), new PlantDescription("Zboże typu żyto"));

            var plant4 = new Plant(new PlantName("Owies"), new PlantRequiredAmountPerHectare(1000), new PlantDescription("Zboże typu owies"));

            var plant5 = new Plant(new PlantName("Buraczki czerwone"), new PlantRequiredAmountPerHectare(1000), new PlantDescription("Warzywo typu burak"));


            var plant6 = new Plant(new PlantName("Cebula"), new PlantRequiredAmountPerHectare(1000), new PlantDescription("Warzywo typu cebula"));

            var plant7 = new Plant(new PlantName("Ziemniaki"), new PlantRequiredAmountPerHectare(1000), new PlantDescription("Warzywo typu ziemniak"));

            var admin = new User(new UserId(Guid.NewGuid()), new UserLogin("admin"), new UserPassword("admin"), new UserFirstName("Administrator"), new UserLastName("Administrator"));

            var season = new Season();

            var land1 = new Land(new LandClass("Klasa A"), new LandStatus(1), new LandName("Pole pierwsze"), new LandArea(5));
            var land2 = new Land(new LandClass("Klasa B"), new LandStatus(1), new LandName("Pole drugie"), new LandArea(2));

            var pesticideWarehouse = new PesticideWarehouse();

            var fertilizerWarehouse = new FertilizerWarehouse();

            var plantWarehouse = new PlantWarehouse();

            var pesticideType1 = new PesticideType(new PesticideTypeName("Nazwa typu 1"), new PesticideTypeDescription("Opis typu 1"));

            pesticideType1.AddPesticide(new Pesticide(pesticideType1.Id, new PesticideRequiredAmountPerHectare(100), new PesticideName("Oprysk1"), new PesticideDescription("Opis1")));

            pesticideType1.AddPesticide(new Pesticide(pesticideType1.Id, new PesticideRequiredAmountPerHectare(77), new PesticideName("Oprysk2"), new PesticideDescription("Opis2")));

            var pesticideType2 = new PesticideType(new PesticideTypeName("Nazwa typu 2"), new PesticideTypeDescription("Opis typu 2"));

            pesticideType1.AddPesticide(new Pesticide(pesticideType2.Id, new PesticideRequiredAmountPerHectare(44), new PesticideName("Oprysk3"), new PesticideDescription("Opis3")));

            pesticideType1.AddPesticide(new Pesticide(pesticideType2.Id, new PesticideRequiredAmountPerHectare(66), new PesticideName("Oprysk4"), new PesticideDescription("Opis4")));

            await _fertilizerTypeRepository.AddAsync(fertilizerType1);
            await _fertilizerTypeRepository.AddAsync(fertilizerType2);
            await _fertilizerTypeRepository.AddAsync(fertilizerType3);

            await _plantRepository.AddAsync(plant1);
            await _plantRepository.AddAsync(plant2);
            await _plantRepository.AddAsync(plant3);
            await _plantRepository.AddAsync(plant4);
            await _plantRepository.AddAsync(plant5);
            await _plantRepository.AddAsync(plant6);
            await _plantRepository.AddAsync(plant7);

            await _userRepository.AddAsync(admin);

            await _seasonRepository.AddAsync(season);

            await _landRepository.AddAsync(land1);
            await _landRepository.AddAsync(land2);

            await _pesticideWarehouseRepository.AddAsync(pesticideWarehouse);

            await _fertilizerWarehouseRepository.AddAsync(fertilizerWarehouse);

            await _plantWarehouseRepository.AddAsync(plantWarehouse);

            await _pesticideTypeRepository.AddAsync(pesticideType1);
            await _pesticideTypeRepository.AddAsync(pesticideType2);

            return new Response<SeedBasicDataResponse>
            {
                Succeeded = true,
                Error = null,
                Content = null
            };
        }
    }
}
