using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    /// <summary>
    /// Controller for handling event-related requests.
    /// </summary>
    public class EventsController : ControllerBase
    {
        private readonly IEventsService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsController"/> class.
        /// </summary>
        /// <param name="service">The events service to be used.</param>
        public EventsController(IEventsService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds a new event.
        /// </summary>
        /// <param name="dto">The event DTO to add.</param>
        /// <returns>The created event DTO.</returns>
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

        /// <summary>
        /// Retrieves an event by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to retrieve.</param>
        /// <returns>The requested event DTO.</returns>
        [HttpGet("{id}")] //GET : api/events/2
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

        /// <summary>
        /// Updates an existing event.
        /// </summary>
        /// <param name="id">The identifier of the event to update.</param>
        /// <param name="dto">The event DTO with updated information.</param>
        /// <returns>The updated event DTO.</returns>
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

        /// <summary>
        /// Deletes an event by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to delete.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
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

        /// <summary>
        /// Retrieves events by destination ID.
        /// </summary>
        /// <param name="destinationID">The destination ID to filter events by.</param>
        /// <returns>A list of event DTOs for the specified destination.</returns>
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
