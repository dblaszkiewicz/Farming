﻿using Farming.Application.DTO;
using Farming.Application.Queries;
using Farming.Infrastructure.EF.Contexts;
using Farming.Infrastructure.EF.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Farming.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetAllLandsWithPlantHandler : IRequestHandler<GetAllLandsWithPlantQuery, IEnumerable<LandWithPlantedDto>>
    {
        private readonly DbSet<LandReadModel> _lands;
        private readonly DbSet<LandRealizationReadModel> _landRealizations;
        private readonly DbSet<SeasonReadModel> _seasons;

        public GetAllLandsWithPlantHandler(ReadDbContext context)
        {
            _lands = context.Lands;
            _landRealizations = context.LandRealizations;
            _seasons = context.Seasons;
        }

        public async Task<IEnumerable<LandWithPlantedDto>> Handle(GetAllLandsWithPlantQuery request, CancellationToken cancellationToken)
        {
            var currentActiveSeason = _seasons.FirstOrDefault(x => x.Active);

            var lands = await _lands.Include(x => x.LandRealizations).Select(x => x.AsDto()).ToListAsync();

            var landIdWhichArePlanted = lands.Where(x => x.IsPlanted).Select(x => x.Id).ToList();

            var plantIdsFromLands = await _landRealizations
                .Include(x => x.PlantActions)
                    .ThenInclude(x => x.Plant)
                .Where(x => x.SeasonId == currentActiveSeason.Id && landIdWhichArePlanted.Contains(x.LandId) && x.PlantActions.Any())
                .Select(x => new LandIdPlantId
                {
                    LandId = x.LandId,
                    PlantId = x.PlantActions.OrderByDescending(x => x.RealizationDate).FirstOrDefault().PlantId,
                    PlantName = x.PlantActions.OrderByDescending(x => x.RealizationDate).FirstOrDefault().Plant.Name,
                }).ToListAsync();

            foreach (var land in lands)
            {
                if (!land.IsPlanted)
                {
                    continue;
                }

                var plant = plantIdsFromLands.First(x => x.LandId == land.Id);

                land.Planted = new PlantedDto
                {
                    PlantId = plant.PlantId,
                    PlantName = plant.PlantName
                };
            }

            return lands;
        }
    }

    internal class LandIdPlantId
    {
        public Guid LandId { get; set; }
        public Guid PlantId { get; set; }
        public string PlantName { get; set; }
    }
}
