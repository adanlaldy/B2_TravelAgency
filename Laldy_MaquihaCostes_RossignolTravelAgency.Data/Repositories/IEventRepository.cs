using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public interface IEventRepository
    {
        Task<DestinationEvent> Add(DestinationEvent destinationEvent);
        Task<int> Delete(int id);
        Task<DestinationEvent> Get(int id);
        List<DestinationEvent> GetAll();
        Task<DestinationEvent> Update(DestinationEvent destinationEvent);
    }
}