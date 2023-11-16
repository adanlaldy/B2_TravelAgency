using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public interface IEventService
    {
        Task<EventDto> Add(EventDto eventDto);
        Task<int> Delete(int id);
        Task<EventDto> Get(int id);
        Task<EventDto> Update(EventDto eventDto);
    }
}