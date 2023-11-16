using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService service;

        public EventsController(IEventsService service)
        {
            this.service = service;
        }

        //methodes

        [HttpPost] //POST : api/events
        public async Task<ActionResult<EventsDto>> Add([FromBody] EventsDto dto)
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

        [HttpGet("{id}")] //GET : api/eventsDto/2
        public async Task<ActionResult<EventsDto>> Get(int id)
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

        [HttpPut("{id}")] //PUT : api/events
        public async Task<ActionResult<EventsDto>> Update(int id, EventsDto dto)
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

        [HttpDelete("{id}")] //DELETE : api/events
        public async Task<ActionResult<EventsDto>> Delete(int id)
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
        [HttpGet("eventsbydestination/{destinationID}")] //GET : api/eventsbydestination/1
        public async Task<ActionResult<List<EventsDto>>> GetEventsByDestination(int destinationID)
        {
            if (destinationID <= default(int))
            {
                return NotFound();
            }

            try
            {
                var eventsDto = await this.service.GetEventsByDestination(destinationID);
                return Ok(eventsDto);
            }
            catch (Exception e)
            {
                return this.StatusCode(500, "Internal Server error");
            }
        }
    }
}