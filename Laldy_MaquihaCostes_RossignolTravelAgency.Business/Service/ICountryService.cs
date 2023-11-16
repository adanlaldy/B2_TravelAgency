using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public interface ICountryService
    {
        Task<CountryDto> Add(CountryDto countryDto);
        Task<int> Delete(int id);
        Task<CountryDto> Get(int id);
        Task<CountryDto> Update(CountryDto countryDto);
    }
}
