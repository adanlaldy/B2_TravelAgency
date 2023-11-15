using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public interface ITravelRepository
    {
        Task<Travel> Add(Travel travel);
        Task<int> Delete(int id);
        Task<Travel> Get(int id);
        Task<Travel> Update(Travel travel);
    }
}