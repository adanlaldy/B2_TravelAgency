using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerService service;

        public TravelerController(ITravelerService service)
        {
            this.service = service;
        }

        //methodes

        [HttpPost] //POST : api/traveler
        public async Task<ActionResult<TravelerDto>> Add([FromBody] TravelerDto dto)
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

        [HttpGet("{id}")] //GET : api/travelerDto/2
        public async Task<ActionResult<TravelerDto>> Get(int id)
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

        [HttpPut("{id}")] //PUT : api/traveler
        public async Task<ActionResult<TravelerDto>> Update(int id, TravelerDto dto)
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

        [HttpDelete("{id}")] //DELETE : api/traveler
        public async Task<ActionResult<TravelerDto>> Delete(int id)
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
        [HttpGet("minor")] //GET : api/traveler/minor
        public ActionResult<List<TravelerDto>> GetMinorTraveler()
        {
            try
            {
                return this.service.GetMinorTraveler();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal Server error");
            }
        }
    }
}