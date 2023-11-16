using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    /// <summary>
    /// Repository for managing events in the database.
    /// </summary>
    public class EventsRepository : IEventsRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventsRepository"/> class.
        /// </summary>
        /// <param name="context">The database context used for event operations.</param>
        public EventsRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new event to the database.
        /// </summary>
        /// <param name="events">The event to add.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the added event.</returns>
        public async Task<Events> Add(Events events)
        {
            context.AllEvents.Add(events);
            await context.SaveChangesAsync();
            return events;
        }

        /// <summary>
        /// Updates an existing event in the database.
        /// </summary>
        /// <param name="events">The event to update.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated event.</returns>
        public async Task<Events> Update(Events events)
        {
            context.AllEvents.Update(events);
            await context.SaveChangesAsync();
            return events;
        }

        /// <summary>
        /// Deletes an event from the database by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to be deleted.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of state entries written to the database.</returns>
        public async Task<int> Delete(int id)
        {
            Events events = await context.AllEvents.FindAsync(id);
            context.AllEvents.Remove(events);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves an event by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the event to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the event found, or null if no event is found.</returns>
        public async Task<Events> Get(int id)
        {
            return await context.AllEvents.FindAsync(id);
        }

        /// <summary>
        /// Retrieves all events associated with a specific destination identifier.
        /// </summary>
        /// <param name="destinationID">The destination identifier for which events are to be retrieved.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a list of events.</returns>
        public async Task<List<Events>> GetEventsByDestination(int destinationID)
        {
            return await context.AllEvents.Where(x => x.DestinationID == destinationID).ToListAsync();
        }
    }
}
