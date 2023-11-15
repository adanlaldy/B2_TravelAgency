using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public interface IEventsService
    {
        Task<EventsDto> Add(EventsDto eventsDto);
        Task<int> Delete(int id);
        Task<EventsDto> Get(int id);
        Task<EventsDto> Update(EventsDto eventsDto);
    }
}