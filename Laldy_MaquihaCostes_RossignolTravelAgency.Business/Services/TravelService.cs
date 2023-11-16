using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    /// <summary>
    /// Service layer for managing travel records. Provides methods to add, update, retrieve, and delete travel data.
    /// </summary>
    public class TravelService : ITravelService
    {
        private readonly ITravelRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelService"/> class.
        /// </summary>
        /// <param name="repository">The travel repository for data operations.</param>
        public TravelService(ITravelRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Converts a Travel model to a TravelDto.
        /// </summary>
        /// <param name="travel">The travel model to convert.</param>
        /// <returns>The travel DTO.</returns>
        private TravelDto ModelToDto(Travel travel)
        {
            return new TravelDto
            {
                Id = travel.Id,
                DestinationID = travel.DestinationID,
                StartDate = travel.StartDate,
                EndDate = travel.EndDate,
                Traveler = travel.Traveler,
            };
        }

        /// <summary>
        /// Converts a TravelDto to a Travel model.
        /// </summary>
        /// <param name="dto">The travel DTO to convert.</param>
        /// <returns>The travel model.</returns>
        private Travel DtoToModel(TravelDto dto)
        {
            return new Travel
            {
                Id = dto.Id,
                DestinationID = dto.DestinationID,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Traveler = dto.Traveler,
            };
        }

        /// <summary>
        /// Adds a new travel record using a TravelDto.
        /// </summary>
        /// <param name="travelDto">The travel DTO to add.</param>
        /// <returns>The added travel DTO.</returns>
        public async Task<TravelDto> Add(TravelDto travelDto)
        {
            Travel travel = DtoToModel(travelDto);
            await repository.Add(travel);
            return ModelToDto(travel);
        }

        /// <summary>
        /// Updates an existing travel record using a TravelDto.
        /// </summary>
        /// <param name="travelDto">The travel DTO to update.</param>
        /// <returns>The updated travel DTO.</returns>
        public async Task<TravelDto> Update(TravelDto travelDto)
        {
            Travel travel = DtoToModel(travelDto);
            await repository.Update(travel);
            return ModelToDto(travel);
        }

        /// <summary>
        /// Retrieves a travel DTO by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel record to retrieve.</param>
        /// <returns>The requested travel DTO.</returns>
        public async Task<TravelDto> Get(int id)
        {
            Travel travel = await repository.Get(id);
            return ModelToDto(travel);
        }

        /// <summary>
        /// Deletes a travel record by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel record to delete.</param>
        /// <returns>The number of entities removed from the database.</returns>
        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Converts a collection of Travel models to a list of TravelDtos.
        /// </summary>
        /// <param name="travels">The collection of travel models to convert.</param>
        /// <returns>A list of travel DTOs.</returns>
        private List<TravelDto> ListModelToDto(ICollection<Travel> travels)
        {
            return travels.Select(x => ModelToDto(x)).ToList();
        }

        /// <summary>
        /// Retrieves all future travel records and returns them as a list of DTOs.
        /// </summary>
        /// <returns>A list of travel DTOs for future travels.</returns>
        public List<TravelDto> GetFutureTravel()
        {
            List<Travel> travels = repository.GetFutureTravel();
            return ListModelToDto(travels);
        }
        /// Retrieves all past travel records and returns them as a list of DTOs.
        /// </summary>
        /// <returns>A list of travel DTOs for past travels.</returns>
        public List<TravelDto> GetPastTravel()
        {
            List<Travel> travels = repository.GetPastTravel();
            List<TravelDto> travelDtos = ListModelToDto(travels);
            return travelDtos;
        }
    }
}

