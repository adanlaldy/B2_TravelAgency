using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService service;

        public DestinationsController(IDestinationService service)
        {
            this.service = service;
        }

        //methodes

        [HttpPost] //POST : api/destination
        public async Task<ActionResult<DestinationDto>> Add([FromBody] DestinationDto dto)
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

        [HttpGet("{id}")] //GET : api/destination/2
        public async Task<ActionResult<DestinationDto>> Get(int id)
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
        [HttpGet("all")] //GET : api/destination/all
        public ActionResult<List<DestinationDto>> GetAll()
        {
            try
            {
                return this.service.GetAll();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal Server error");
            }
        }

        [HttpPut("{id}")] //PUT : api/destination
        public async Task<ActionResult<DestinationDto>> Update(int id, DestinationDto dto)
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

        [HttpDelete("{id}")] //DELETE : api/destination
        public async Task<ActionResult<DestinationDto>> Delete(int id)
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
        [HttpGet("visited")] //GET : api/destination/visited
        public ActionResult<List<DestinationDto>> GetAllVisited()
        {
            try
            {
                return this.service.GetAllVisited();
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal Server error");
            }
        }
    }
}