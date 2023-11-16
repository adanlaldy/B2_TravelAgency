using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService service;

        public TravelController(ITravelService service)
        {
            this.service = service;
        }

        //methodes

        [HttpPost] //POST : api/travel
        public async Task<ActionResult<TravelDto>> Add([FromBody] TravelDto dto)
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

        [HttpGet("{id}")] //GET : api/travelDto/2
        public async Task<ActionResult<TravelDto>> Get(int id)
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

        [HttpPut("{id}")] //PUT : api/travel
        public async Task<ActionResult<TravelDto>> Update(int id, TravelDto dto)
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

        [HttpDelete("{id}")] //DELETE : api/travel
        public async Task<ActionResult<TravelDto>> Delete(int id)
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
        [HttpGet("future")] //GET : api/travel/future
        public ActionResult<List<TravelDto>> GetFutureTravel()
        {
            try
            {
                return this.service.GetFutureTravel();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal Server error");
            }
        }
        [HttpGet("past")] //GET : api/travel/past
        public ActionResult<List<TravelDto>> GetPastTravel()
        {
            try
            {
                return this.service.GetPastTravel();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal Server error");
            }
        }
    }
}