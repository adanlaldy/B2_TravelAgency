using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public interface ICountryService
    {
        Task<CountryDto> Add(CountryDto countryDto);
        Task<int> Delete(int id);
        Task<CountryDto> Get(int id);
        //get all
        Task<CountryDto> Update(CountryDto countryDto);
    }
}