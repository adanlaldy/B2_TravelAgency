using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public interface IDestinationRepository
    {
        Task<Destination> Add(Destination destination);
        Task<int> Delete(int id);
        Task<Destination> Get(int id);
        List<Destination> GetAll();
        Task<Destination> Update(Destination destination);
        List<Destination> GetAllVisited();

    }
}