using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public interface ITravelerRepository
    {
        Task<Traveler> Add(Traveler traveler);
        Task<int> Delete(int id);
        Task<Traveler> Get(int id);
        Task<Traveler> Update(Traveler traveler);
        List<Traveler> GetMinorTraveler();
    }
}