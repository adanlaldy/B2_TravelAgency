using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    public class CountryService : ICountryService
    {
        private readonly ICountryService repository;

        public CountryService(ICountryService repository)
        {
            this.repository = repository;
        }

        private CountryDto ModelToDto(Country country)
        {
            CountryDto countryDto = new CountryDto
            {
                Id = country.Id,
                Title = country.Title,
            };
            return countryDto;
        }

        private Country DtoToModel(CountryDto dto)
        {
            Country country = new Country
            {
                Id = dto.Id,
                Title = dto.Title,
            };
        return country;
        }

        // Méthodes
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
