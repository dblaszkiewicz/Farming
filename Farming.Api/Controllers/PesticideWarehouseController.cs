﻿using Farming.Api.MapsterProfiles;
using Farming.Application.Commands;
using Farming.Application.DTO.Requests;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Farming.Api.Controllers
{
    public class PesticideWarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapsterMapper;

        public PesticideWarehouseController(IMediator mediator)
        {
            _mediator = mediator;
            _mapsterMapper = new Mapper(MapsterProfile.GetAdapterConfig());
        }

        [HttpPost("addPesticideWarehouseDelivery")]
        public async Task<IActionResult> AddFertilizerWarehouseDelivery([FromBody] AddPesticideWarehouseDeliveryRequestDto addPesticideWarehouseDeliveryDto)
        {
            var command = _mapsterMapper.From(addPesticideWarehouseDeliveryDto).AdaptToType<AddPesticideWarehouseDeliveryCommand>();
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}