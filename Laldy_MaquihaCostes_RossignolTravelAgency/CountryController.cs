using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    /// <summary>
    /// Controller for handling country-related requests.
    /// </summary>
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountriesController"/> class.
        /// </summary>
        /// <param name="service">The country service to be used.</param>
        public CountriesController(ICountryService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds a new country.
        /// </summary>
        /// <param name="dto">The country DTO to add.</param>
        /// <returns>The created country DTO.</returns>
        [HttpPost] //POST : api/country
        public async Task<ActionResult<CountryDto>> Add([FromBody] CountryDto dto)
        {
            try
            {
                dto = await this.service.Add(dto);
                return StatusCode(StatusCodes.Status201Created, dto);
            }
            catch (ArgumentNullException e)
            {
                return this.ValidationProblem();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Retrieves a country by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the country to retrieve.</param>
        /// <returns>The requested country DTO.</returns>
        [HttpGet("{id}")] //GET : api/country/2
        public async Task<ActionResult<CountryDto>> Get(int id)
        {
            if (id <= default(int))
            {
                return NotFound();
            }

            try
            {
                return await this.service.Get(id);
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal Server error");
            }
        }

        /// <summary>
        /// Updates an existing country.
        /// </summary>
        /// <param name="id">The identifier of the country to update.</param>
        /// <param name="dto">The country DTO with updated information.</param>
        /// <returns>The updated country DTO.</returns>
        [HttpPut("{id}")] //PUT : api/country
        public async Task<ActionResult<CountryDto>> Update(int id, CountryDto dto)
        {
            if (id != dto.Id)
            {
                return this.BadRequest();
            }

            try
            {
                return await this.service.Update(dto);
            }
            catch (ArgumentException)
            {
                return this.ValidationProblem();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Deletes a country by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the country to delete.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
        [HttpDelete("{id}")] //DELETE : api/country
        public async Task<ActionResult<CountryDto>> Delete(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            try
            {
                await this.service.Delete(id);
                return this.Ok();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}
