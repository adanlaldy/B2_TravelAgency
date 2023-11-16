using Microsoft.AspNetCore.Mvc;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO;
using Laldy_MaquihaCostes_RossignolTravelAgency.Business.Service;

namespace Laldy_MaquihaCostes_RossignolTravelAgency
{
    [Route("api/[Controller]")]
    [ApiController]
    /// <summary>
    /// Controller for handling destination-related requests.
    /// </summary>
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationService service;

        /// <summary>
        /// Initializes a new instance of the <see cref="DestinationsController"/> class.
        /// </summary>
        /// <param name="service">The destination service to be used.</param>
        public DestinationsController(IDestinationService service)
        {
            this.service = service;
        }

        /// <summary>
        /// Adds a new destination.
        /// </summary>
        /// <param name="dto">The destination DTO to add.</param>
        /// <returns>The created destination DTO.</returns>
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

        /// <summary>
        /// Retrieves a destination by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to retrieve.</param>
        /// <returns>The requested destination DTO.</returns>
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

        /// <summary>
        /// Retrieves all destinations.
        /// </summary>
        /// <returns>A list of all destination DTOs.</returns>
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

        /// <summary>
        /// Updates an existing destination.
        /// </summary>
        /// <param name="id">The identifier of the destination to update.</param>
        /// <param name="dto">The destination DTO with updated information.</param>
        /// <returns>The updated destination DTO.</returns>
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

        /// <summary>
        /// Deletes a destination by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the destination to delete.</param>
        /// <returns>An ActionResult indicating the result of the operation.</returns>
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

        /// <summary>
        /// Retrieves all visited destinations.
        /// </summary>
        /// <returns>A list of destination DTOs for all visited destinations.</returns>
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
