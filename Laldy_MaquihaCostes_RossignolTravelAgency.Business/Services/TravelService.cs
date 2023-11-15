using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public class TravelService : ITravelService
    {
        private readonly ITravelRepository repository;

        public TravelService(ITravelRepository repository)
        {
            this.repository = repository;
        }
        private TravelDto ModelToDto(Travel travel)
        {
            TravelDto travelDto = new TravelDto
            {
                Id = travel.Id,
                DestinationID = travel.DestinationID,
                StartDate = travel.StartDate,
                EndDate = travel.EndDate,
                Traveler = travel.Traveler,
            };

            return travelDto;
        }

        private Travel DtoToModel(TravelDto dto)
        {
            Travel travel = new Travel
            {
                Id = dto.Id,
                DestinationID = dto.DestinationID,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Traveler = dto.Traveler,
            };

            return travel;
        }

        //methodes

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
