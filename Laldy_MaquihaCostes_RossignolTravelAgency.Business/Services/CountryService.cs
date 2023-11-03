using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository repository;

        public CountryService(ICountryRepository repository)
        {
            this.repository = repository;
        }
        private CountryDto ModelToDto(Country country)
        {
            CountryDto countryDto = new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
                DestinationList = country.DestinationList,
            };

            return countryDto;
        }

        private Country DtoToModel(CountryDto dto)
        {
            Country country = new Country
            {
                Id = dto.Id,
                Name= dto.Name,
                DestinationList = dto.DestinationList,
            };

            return country;
        }

        //methodes

        public async Task<CountryDto> Add(CountryDto countryDto)
        {
            Country country = DtoToModel(countryDto);
            await repository.Add(country);
            CountryDto dto = ModelToDto(country);

            return dto;
        }

        public async Task<CountryDto> Update(CountryDto countryDto)
        {
            Country country = DtoToModel(countryDto);
            await repository.Update(country);
            CountryDto dto = ModelToDto(country);

            return dto;
        }

        public async Task<CountryDto> Get(int id)
        {
            Country country = await repository.Get(id);
            CountryDto countryDto = ModelToDto(country);
            return countryDto;
        }

        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }
    }
}
