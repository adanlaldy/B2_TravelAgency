﻿using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository repository;

        public DestinationService(IDestinationRepository repository)
        {
            this.repository = repository;
        }
        private DestinationDto ModelToDto(Destination destination)
        {
            DestinationDto destinationDto = new DestinationDto
            {
                Id = destination.Id,
                City = destination.City,
                IsCapital = destination.IsCapital,
                PointsOfInterest = destination.PointsOfInterest,
                IsVisited = destination.IsVisited,
                Rate = destination.Rate != null ? destination.Rate : null,
                Comment = destination.Comment,
                CountryId = destination.CountryId,
            };

            return destinationDto;
        }

        private Destination DtoToModel(DestinationDto dto)
        {
            Destination destination = new Destination
            {
                Id = dto.Id,
                City = dto.City,
                IsCapital = dto.IsCapital,
                PointsOfInterest = dto.PointsOfInterest,
                IsVisited = dto.IsVisited,
                Rate = dto.Rate != null ? dto.Rate : null,
                Comment = dto.Comment,
                CountryId = dto.CountryId
            };

            return destination;
        }

        //methodes

        public async Task<DestinationDto> Add(DestinationDto destinationDto)
        {
            Destination destination = DtoToModel(destinationDto);
            await repository.Add(destination);
            DestinationDto dto = ModelToDto(destination);

            return dto;
        }

        public async Task<DestinationDto> Update(DestinationDto destinationDto)
        {
            Destination destination = DtoToModel(destinationDto);
            await repository.Update(destination);
            DestinationDto dto = ModelToDto(destination);

            return dto;
        }

        public async Task<DestinationDto> Get(int id)
        {
            Destination destination = await repository.Get(id);
            DestinationDto destinationDto = ModelToDto(destination);
            return destinationDto;
        }

        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }
    }
}
