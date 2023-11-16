using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Migrations;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    /// <summary>
    /// Service layer for managing events. Provides methods to add, update, retrieve, and delete event data.
    /// </summary>
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsService"/> class.
        /// </summary>
        /// <param name="repository">The events repository for data operations.</param>
        public EventsService(IEventsRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Converts an Events model to an EventsDto.
        /// </summary>
        /// <param name="events">The events model to convert.</param>
        /// <returns>The events DTO.</returns>
        private EventsDto ModelToDto(Events events)
        {
            return new EventsDto
            {
                Id = events.Id,
                Title = events.Title,
                Date = events.Date,
                Description = events.Description,
                DestinationID = events.DestinationID,
            };
        }

        /// <summary>
        /// Converts an EventsDto to an Events model.
        /// </summary>
        /// <param name="dto">The events DTO to convert.</param>
        /// <returns>The events model.</returns>
        private Events DtoToModel(EventsDto dto)
        {
            return new Events
            {
                Id = dto.Id,
                Title = dto.Title,
                Date = dto.Date,
                Description = dto.Description,
                DestinationID = dto.DestinationID,
            };
        }

        /// <summary>
        /// Adds a new event using an EventsDto.
        /// </summary>
        /// <param name="eventsDto">The events DTO to add.</param>
        /// <returns>The added events DTO.</returns>
        public async Task<EventsDto> Add(EventsDto eventsDto)
        {
            Events events = DtoToModel(eventsDto);
            await repository.Add(events);
            return ModelToDto(events);
        }

        /// <summary>
        /// Updates an existing event using an EventsDto.
        /// </summary>
        /// <param name="eventsDto">The events DTO to update.</param>
        /// <returns>The updated events DTO.</returns>
        public async Task<EventsDto> Update(EventsDto eventsDto)
        {
            Events events = DtoToModel(eventsDto);
            await repository.Update(events);
            return ModelToDto(events);
        }

        /// <summary>
        /// Retrieves an event DTO by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to retrieve.</param>
        /// <returns>The requested event DTO.</returns>
        public async Task<EventsDto> Get(int id)
        {
            Events events = await repository.Get(id);
            return ModelToDto(events);
        }

        /// <summary>
        /// Deletes an event by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to delete.</param>
        /// <returns>The number of entities removed from the database.</returns>
        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }

        /// <summary>
        /// Converts a collection of Events models to a list of EventsDtos.
        /// </summary>
        /// <param name="events">The collection of events models to convert.</param>
        /// <returns>A list of events DTOs.</returns>
        private List<EventsDto> ListModelToDto(ICollection<Events> events)
        {
            return events.Select(x => ModelToDto(x)).ToList();
        }

        /// <summary>
        /// Retrieves events by destination ID and returns them as a list of DTOs.
        /// </summary>
        /// <param name="destinationID">The destination ID to filter events by.</param>
        /// <returns>A list of events DTOs for the specified destination.</returns>
        public async Task<List<EventsDto>> GetEventsByDestination(int destinationID)
        {
            List<Events> events = await repository.GetEventsByDestination(destinationID);
            return ListModelToDto(events);
        }
    }
}
