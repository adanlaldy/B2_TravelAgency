using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Country = destination.Country,
                City = destination.City,
                IsCapital = destination.IsCapital,
                PointsOfInterest = destination.PointsOfInterest,
                IsVisited = destination.IsVisited,
                VisiteDate = destination.VisiteDate,
                Rate = destination.Rate != null ? destination.Rate : null,
                Comment = destination.Comment,
            };

            return destinationDto;
        }

        private Destination DtoToModel(DestinationDto dto)
        {
            Destination destination = new Destination
            {
                Id = dto.Id,
                Country = dto.Country,
                City = dto.City,
                IsCapital = dto.IsCapital,
                PointsOfInterest = dto.PointsOfInterest,
                IsVisited = dto.IsVisited,
                VisiteDate = dto.VisiteDate,
                Rate = dto.Rate != null ? dto.Rate : null,
                Comment = dto.Comment,
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
