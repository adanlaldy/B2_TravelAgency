using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System;
using Microsoft.Extensions.Logging;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public class EventService : IEventService
    {
        private readonly IEventRepository repository;

        public EventService(IEventRepository repository)
        {
            this.repository = repository;
        }

        private EventDto ModelToDto(DestinationEvent destinationEvent)
        {
            EventDto eventDto = new EventDto
            {
                Id = destinationEvent.Id,
                Title = destinationEvent.Title,
                Date = destinationEvent.Date,
                Description = destinationEvent.Description,
                Destination = destinationEvent.Destination,
            };

            return eventDto;
        }

        private DestinationEvent DtoToModel(EventDto dto)
        {
            DestinationEvent destinationEvent = new DestinationEvent
            {
                Id = dto.Id,
                Title = dto.Title,
                Date = dto.Date,
                Description = dto.Description,
                Destination = dto.Destination,
            };

            return destinationEvent;
        }

        // Méthodes
        public async Task<EventDto> Add(EventDto eventDto)
        {
            DestinationEvent destinationEvent = DtoToModel(eventDto);
            await repository.Add(destinationEvent);
            DestinationDto dto = ModelToDto(destinationEvent);

            return dto;
        }

        public async Task<EventDto> Update(EventDto eventDto)
        {
            DestinationEvent destinationEvent = DtoToModel(eventDto);
            await repository.Update(destinationEvent);
            EventDto dto = ModelToDto(destinationEvent);

            return dto;
        }

        public async Task<EventDto> Get(int id)
        {
            DestinationEvent destinationEvent = await repository.Get(id);
            EventDto eventDto = ModelToDto(destinationEvent);
            return eventDto;
        }

        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }
    }
}
