using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public interface ICountryRepository
    {
        Task<Country> Add(Country country);
        Task<int> Delete(int id);
        Task<Country> Get(int id);
        List<Country> GetAll();
        Task<Country> Update(Country country);
    }
}