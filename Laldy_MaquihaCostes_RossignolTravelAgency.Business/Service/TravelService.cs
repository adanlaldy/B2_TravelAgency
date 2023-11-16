using System;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public class TravelService : ITravelService
    {
        private readonly ITravelService repository;

        public TravelService(ITravelService repository)
        {
            this.repository = repository;
        }

        private TravelDto ModelToDto(Travel travel)
        {
            TravelDto travelDto = new TravelDto
            {
                Id = travel.Id,
                Traveler = travel.Traveler,
                Destination = travel.Destination,
                StartDate = travel.StartDate,
                EndDate = travel.EndDate,
            };
            return travelDto;
        }

        private Travel DtoToModel(TravelDto dto)
        {
            Travel travel = new Travel
            {
                Id = dto.Id,
                Traveler = dto.Traveler,
                Destination = dto.Destination,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
            };
            return travel;
        }

        // Méthodes
        public async Task<TravelDto> Add(TravelDto travelDto)
        {
            Travel travel = DtoToModel(travelDto);
            await repository.Add(travel);
            TravelDto dto = ModelToDto(travel);

            return dto;
        }

        public async Task<TravelDto> Update(TravelDto travelDto)
        {
            Travel travel = DtoToModel(travelDto);
            await repository.Update(travel);
            TravelDto dto = ModelToDto(travel);

            return dto;
        }

        public async Task<TravelDto> Get(int id)
        {
            Travel travel = await repository.Get(id);
            TravelDto travelDto = ModelToDto(travel);
            return travelDto;
        }

        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }
    }
}
