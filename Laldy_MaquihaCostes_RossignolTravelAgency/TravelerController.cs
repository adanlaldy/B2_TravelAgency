using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    /// <summary>
    /// Controller for handling traveler-related requests.
    /// </summary>
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelerController"/> class.
        /// </summary>
        /// <param name="service">The traveler service to be used.</param>
        public TravelerController(ITravelerService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds a new traveler.
        /// </summary>
        /// <param name="dto">The traveler DTO to add.</param>
        /// <returns>The created traveler DTO.</returns>
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

        /// <summary>
        /// Retrieves a traveler by their identifier.
        /// </summary>
        /// <param name="id">The identifier of the traveler to retrieve.</param>
        /// <returns>The requested traveler DTO.</returns>
        [HttpGet("{id}")] //GET : api/traveler/2
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

        /// <summary>
        /// Updates an existing traveler.
        /// </summary>
        /// <param name="id">The identifier of the traveler to update.</param>
        /// <param name="dto">The traveler DTO with updated information.</param>
        /// <returns>The updated traveler DTO.</returns>
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

        /// <summary>
        /// Deletes a traveler by their identifier.
        /// </summary>
        /// <param name="id">The identifier of the traveler to delete.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
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

        /// <summary>
        /// Retrieves all minor travelers.
        /// </summary>
        /// <returns>A list of traveler DTOs for all travelers who are minors.</returns>
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
