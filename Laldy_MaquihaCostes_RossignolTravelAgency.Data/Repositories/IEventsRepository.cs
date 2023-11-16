using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public interface IEventsRepository
    {
        Task<Events> Add(Events events);
        Task<int> Delete(int id);
        Task<Events> Get(int id);
        Task<Events> Update(Events events);
        Task<List<Events>> GetEventsByDestination(int destinationID);
    }
}