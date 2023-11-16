using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service
{
    /// <summary>
    /// Service layer for managing countries. It provides methods to add, update, delete, and retrieve country data.
    /// </summary>
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class.
        /// </summary>
        /// <param name="repository">The country repository to use for data operations.</param>
        public CountryService(ICountryRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Converts a Country model to a CountryDto.
        /// </summary>
        /// <param name="country">The country model to convert.</param>
        /// <returns>The country DTO.</returns>
        private CountryDto ModelToDto(Country country)
        {
            return new CountryDto
            {
                Id = country.Id,
                Name = country.Name,
            };
        }

        /// <summary>
        /// Converts a CountryDto to a Country model.
        /// </summary>
        /// <param name="dto">The country DTO to convert.</param>
        /// <returns>The country model.</returns>
        private Country DtoToModel(CountryDto dto)
        {
            return new Country
            {
                Id = dto.Id,
                Name = dto.Name,
            };
        }

        /// <summary>
        /// Adds a new country using a CountryDto.
        /// </summary>
        /// <param name="countryDto">The country DTO to add.</param>
        /// <returns>The added country DTO.</returns>
        public async Task<CountryDto> Add(CountryDto countryDto)
        {
            Country country = DtoToModel(countryDto);
            await repository.Add(country);
            return ModelToDto(country);
        }

        /// <summary>
        /// Updates an existing country using a CountryDto.
        /// </summary>
        /// <param name="countryDto">The country DTO to update.</param>
        /// <returns>The updated country DTO.</returns>
        public async Task<CountryDto> Update(CountryDto countryDto)
        {
            Country country = DtoToModel(countryDto);
            await repository.Update(country);
            return ModelToDto(country);
        }

        /// <summary>
        /// Retrieves a country DTO by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the country to retrieve.</param>
        /// <returns>The requested country DTO.</returns>
        public async Task<CountryDto> Get(int id)
        {
            Country country = await repository.Get(id);
            return ModelToDto(country);
        }

        /// <summary>
        /// Deletes a country by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the country to delete.</param>
        /// <returns>The number of entities removed from the database.</returns>
        public async Task<int> Delete(int id)
        {
            return await repository.Delete(id);
        }
    }
}
