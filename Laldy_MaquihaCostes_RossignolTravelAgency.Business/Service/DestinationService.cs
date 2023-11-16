using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System;

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
                Country = destination.Country.Title,
                City = destination.City,
                IsCapital = destination.IsCapital,
                PointsOfInterest = destination.PointsOfInterest,
                IsVisited = destination.IsVisited,
                VisiteDate = destination.VisiteDate,
                Rate = destination.Rate != null ? destination.Rate : null,
                Comment = destination.Comment,
                DestinationEvents = destination.DestinationEvents?.Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Description = e.Description,
                }).ToList(),
                Travelers = destination.Travelers?.Select(t => new TravelerDto
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                }).ToList(),
            };

            return destinationDto;
        }

        private Destination DtoToModel(DestinationDto dto)
        {
            Destination destination = new Destination
            {
                Id = dto.Id,
                Country = new Country { Title = dto.Country },
                City = dto.City,
                IsCapital = dto.IsCapital,
                PointsOfInterest = dto.PointsOfInterest,
                IsVisited = dto.IsVisited,
                VisiteDate = dto.VisiteDate,
                Rate = dto.Rate != null ? dto.Rate : null,
                Comment = dto.Comment,
                DestinationEvents = dto.DestinationEvents?.Select(e => new DestinationEvent
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Description = e.Description,
                }).ToList(),
                Travelers = dto.Travelers?.Select(t => new Traveler
                {
                    Id = t.Id,
                    FirstName = t.FirstName,
                    LastName = t.LastName,
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                }).ToList(),
            };

            return destination;
        }

        // Méthodes
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
