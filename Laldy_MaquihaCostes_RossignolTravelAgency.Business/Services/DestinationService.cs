using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    /// <summary>
    /// Service layer for managing destinations. Provides methods to add, update, retrieve, and delete destination data.
    /// </summary>
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationService"/> class.
        /// </summary>
        /// <param name="repository">The destination repository for data operations.</param>
        public DestinationService(IDestinationRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Converts a Destination model to a DestinationDto.
        /// </summary>
        /// <param name="destination">The destination model to convert.</param>
        /// <returns>The destination DTO.</returns>
        private DestinationDto ModelToDto(Destination destination)
        {
            return new DestinationDto
            {
                Id = destination.Id,
                City = destination.City,
                IsCapital = destination.IsCapital,
                PointsOfInterest = destination.PointsOfInterest,
                IsVisited = destination.IsVisited,
                Rate = destination.Rate,
                Comment = destination.Comment,
                Country = destination.Country,
                EventsList = destination.EventsList,
                TravelList = destination.TravelList,
            };
        }

        /// <summary>
        /// Converts a DestinationDto to a Destination model.
        /// </summary>
        /// <param name="dto">The destination DTO to convert.</param>
        /// <returns>The destination model.</returns>
        private Destination DtoToModel(DestinationDto dto)
        {
            return new Destination
            {
                Id = dto.Id,
                City = dto.City,
                IsCapital = dto.IsCapital,
                PointsOfInterest = dto.PointsOfInterest,
                IsVisited = dto.IsVisited,
                Rate = dto.Rate,
                Comment = dto.Comment,
                Country = dto.Country,
                EventsList = dto.EventsList,
                TravelList = dto.TravelList,
            };
        }

        /// <summary>
        /// Adds a new destination using a DestinationDto.
        /// </summary>
        /// <param name="destinationDto">The destination DTO to add.</param>
        /// <returns>The added destination DTO.</returns>
        public async Task<DestinationDto> Add(DestinationDto destinationDto)
        {
            Destination destination = DtoToModel(destinationDto);
            await repository.Add(destination);
            return ModelToDto(destination);
        }

        /// <summary>
        /// Updates an existing destination using a DestinationDto.
        /// </summary>
        /// <param name="destinationDto">The destination DTO to update.</param>
        /// <returns>The updated destination DTO.</returns>
        public async Task<DestinationDto> Update(DestinationDto destinationDto)
        {
            Destination destination = DtoToModel(destinationDto);
            await repository.Update(destination);
            return ModelToDto(destination);
        }

        /// <summary>
        /// Retrieves a destination DTO by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to retrieve.</param>
        /// <returns>The requested destination DTO.</returns>
        public async Task<DestinationDto> Get(int id)
        {
            Destination destination = await repository.Get(id);
            return ModelToDto(destination);
        }

        /// <summary>
        /// Converts a collection of Destination models to a list of DestinationDtos.
        /// </summary>
        /// <param name="destinations">The collection of destination models to convert.</param>
        /// <returns>A list of destination DTOs.</returns>
        private List<DestinationDto> ListModelToDto(ICollection<Destination> destinations)
        {
            return destinations.Select(x => ModelToDto(x)).ToList();
        }

        /// <summary>
        /// Retrieves all destinations as DTOs.
        /// </summary>
        /// <returns>A list of all destination DTOs.</returns>
        public List<DestinationDto> GetAll()
        {
            List<Destination> destinations = repository.GetAll();
            return ListModelToDto(destinations);
        }

        /// <summary>
        /// Deletes a destination by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to delete.</param>
        /// <returns>The number of entities removed from the database.</returns>
        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }

        /// Retrieves all visited destinations as DTOs.
        /// </summary>
        /// <returns>A list of destination DTOs for all visited destinations.</returns>
        public List<DestinationDto> GetAllVisited()
        {
            List<Destination> destinations = repository.GetAllVisited();
            List<DestinationDto> destinationDtos = ListModelToDto(destinations);
            return destinationDtos;
        }
    }
}
