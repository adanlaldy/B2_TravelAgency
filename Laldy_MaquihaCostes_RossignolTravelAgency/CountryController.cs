using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService service;

        public CountriesController(ICountryService service)
        {
            this.service = service;
        }

        //methodes

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

        [HttpGet("{id}")] //GET : api/ountryDto/2
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