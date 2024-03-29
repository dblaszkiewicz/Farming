﻿using Farming.Domain.ValueObjects.Identity;
using Farming.Domain.ValueObjects.Pesticide;
using Farming.Shared.Abstractions.Domain;

namespace Farming.Domain.Entities
{
    public class PesticideType : Tenant
    {
        public PesticideTypeId Id { get; }
        public PesticideTypeName Name { get; }
        public PesticideTypeDescription Description { get; }

        public ICollection<Pesticide> Pesticides { get; }
    }
}
