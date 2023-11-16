﻿using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Migrations;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public class EventsService : IEventsService
    {
        private readonly IEventsRepository repository;

        public EventsService(IEventsRepository repository)
        {
            this.repository = repository;
        }
        private EventsDto ModelToDto(Events events)
        {
            EventsDto eventsDto = new EventsDto
            {
                Id = events.Id,
                Title = events.Title,
                Date = events.Date,
                Description = events.Description,
                DestinationID = events.DestinationID,
            };

            return eventsDto;
        }

        private Events DtoToModel(EventsDto dto)
        {
            Events events = new Events
            {
                Id = dto.Id,
                Title = dto.Title,
                Date = dto.Date,
                Description = dto.Description,
                DestinationID = dto.DestinationID,
            };

            return events;
        }

        //methodes
        public async Task<EventsDto> Add(EventsDto eventsDto)
        {
            Events events = DtoToModel(eventsDto);
            await repository.Add(events);
            EventsDto dto = ModelToDto(events);

            return dto;
        }

        public async Task<EventsDto> Update(EventsDto eventsDto)
        {
            Events events = DtoToModel(eventsDto);
            await repository.Update(events);
            EventsDto dto = ModelToDto(events);

            return dto;
        }

        public async Task<EventsDto> Get(int id)
        {
            Events events = await repository.Get(id);
            EventsDto eventsDto = ModelToDto(events);
            return eventsDto;
        }

        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }
        private List<EventsDto> ListModelToDto(ICollection<Events> events)
        {
            List<EventsDto> eventsDto = events.Select(x => ModelToDto(x)).ToList();
            return eventsDto;

        }
        public async Task<List<EventsDto>> GetEventsByDestination(int destinationID)
        {
            List<Events> events = await repository.GetEventsByDestination(destinationID);
            List<EventsDto> eventsDto = ListModelToDto(events);
            return eventsDto;
        }
    }
}
