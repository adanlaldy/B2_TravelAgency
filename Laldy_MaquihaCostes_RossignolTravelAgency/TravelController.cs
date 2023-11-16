using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    /// <summary>
    /// Controller for handling travel-related requests.
    /// </summary>
    public class TravelController : ControllerBase
    {
        private readonly ITravelService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelController"/> class.
        /// </summary>
        /// <param name="service">The travel service to be used.</param>
        public TravelController(ITravelService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds a new travel record.
        /// </summary>
        /// <param name="dto">The travel DTO to add.</param>
        /// <returns>The created travel DTO.</returns>
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

        /// <summary>
        /// Retrieves a travel record by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel record to retrieve.</param>
        /// <returns>The requested travel DTO.</returns>
        [HttpGet("{id}")] //GET : api/travel/2
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

        /// <summary>
        /// Updates an existing travel record.
        /// </summary>
        /// <param name="id">The identifier of the travel record to update.</param>
        /// <param name="dto">The travel DTO with updated information.</param>
        /// <returns>The updated travel DTO.</returns>
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

        /// <summary>
        /// Deletes a travel record by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel record to delete.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
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

        /// <summary>
        /// Retrieves all future travel records.
        /// </summary>
        /// <returns>A list of travel DTOs for future travels.</returns>
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

        /// <summary>
        /// Retrieves all past travel records.
        /// </summary>
        /// <returns>A list of travel DTOs for past travels.</returns>
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
