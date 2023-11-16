using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    /// <summary>
    /// Service layer for managing travelers. Provides methods to add, update, retrieve, and delete traveler data.
    /// </summary>
    public class TravelerService : ITravelerService
    {
        private readonly ITravelerRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelerService"/> class.
        /// </summary>
        /// <param name="repository">The traveler repository for data operations.</param>
        public TravelerService(ITravelerRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Converts a Traveler model to a TravelerDto.
        /// </summary>
        /// <param name="traveler">The traveler model to convert.</param>
        /// <returns>The traveler DTO.</returns>
        private TravelerDto ModelToDto(Traveler traveler)
        {
            return new TravelerDto
            {
                Id = traveler.Id,
                FirstName = traveler.FirstName,
                LastName = traveler.LastName,
                BirthDate = traveler.BirthDate,
            };
        }

        /// <summary>
        /// Converts a TravelerDto to a Traveler model.
        /// </summary>
        /// <param name="dto">The traveler DTO to convert.</param>
        /// <returns>The traveler model.</returns>
        private Traveler DtoToModel(TravelerDto dto)
        {
            return new Traveler
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                BirthDate = dto.BirthDate,
            };
        }

        /// <summary>
        /// Adds a new traveler using a TravelerDto.
        /// </summary>
        /// <param name="travelerDto">The traveler DTO to add.</param>
        /// <returns>The added traveler DTO.</returns>
        public async Task<TravelerDto> Add(TravelerDto travelerDto)
        {
            Traveler traveler = DtoToModel(travelerDto);
            await repository.Add(traveler);
            return ModelToDto(traveler);
        }

        /// <summary>
        /// Updates an existing traveler using a TravelerDto.
        /// </summary>
        /// <param name="travelerDto">The traveler DTO to update.</param>
        /// <returns>The updated traveler DTO.</returns>
        public async Task<TravelerDto> Update(TravelerDto travelerDto)
        {
            Traveler traveler = DtoToModel(travelerDto);
            await repository.Update(traveler);
            return ModelToDto(traveler);
        }

        /// <summary>
        /// Retrieves a traveler DTO by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the traveler to retrieve.</param>
        /// <returns>The requested traveler DTO.</returns>
        public async Task<TravelerDto> Get(int id)
        {
            Traveler traveler = await repository.Get(id);
            return ModelToDto(traveler);
        }

        /// <summary>
        /// Deletes a traveler by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the traveler to delete.</param>
        /// <returns>The number of entities removed from the database.</returns>
        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Converts a collection of Traveler models to a list of TravelerDtos.
        /// </summary>
        /// <param name="travelers">The collection of traveler models to convert.</param>
        /// <returns>A list of traveler DTOs.</returns>
        private List<TravelerDto> ListModelToDto(ICollection<Traveler> travelers)
        {
            return travelers.Select(x => ModelToDto(x)).ToList();
        }

        /// <summary>
        /// Retrieves all minor travelers and returns them as a list of DTOs.
        /// </summary>
        /// <returns>A list of traveler DTOs for all travelers who are minors.</returns>
        public List<TravelerDto> GetMinorTraveler()
        {
            List<Traveler> travelers = repository.GetMinorTraveler();
            return ListModelToDto(travelers);
        }
    }
}
