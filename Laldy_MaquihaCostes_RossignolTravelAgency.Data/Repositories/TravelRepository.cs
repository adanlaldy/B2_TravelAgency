using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    /// <summary>
    /// Repository for managing travel records in the database.
    /// </summary>
    public class TravelRepository : ITravelRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public TravelRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new travel record to the database.
        /// </summary>
        /// <param name="travel">The travel record to add.</param>
        /// <returns>The added travel record as a <see cref="Task{Travel}"/>.</returns>
        public async Task<Travel> Add(Travel travel)
        {
            context.Travels.Add(travel);
            await context.SaveChangesAsync();
            return travel;
        }

        /// <summary>
        /// Updates an existing travel record in the database.
        /// </summary>
        /// <param name="travel">The travel record to update.</param>
        /// <returns>The updated travel record as a <see cref="Task{Travel}"/>.</returns>
        public async Task<Travel> Update(Travel travel)
        {
            context.Travels.Update(travel);
            await context.SaveChangesAsync();
            return travel;
        }

        /// <summary>
        /// Deletes a travel record from the database by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel record to delete.</param>
        /// <returns>The number of entities removed from the database as a <see cref="Task{Int}"/>.</returns>
        public async Task<int> Delete(int id)
        {
            Travel travel = await context.Travels.FindAsync(id);
            context.Travels.Remove(travel);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a travel record by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the travel record to retrieve.</param>
        /// <returns>The requested travel record as a <see cref="Task{Travel}"/>.</returns>
        public async Task<Travel> Get(int id)
        {
            return await context.Travels.FindAsync(id);
        }

        /// <summary>
        /// Retrieves all future travel records.
        /// </summary>
        /// <returns>A list of travel records with start dates in the future.</returns>
        public List<Travel> GetFutureTravel()
        {
            DateTime currentDate = DateTime.Now;
            return context.Travels.Where(x => x.StartDate > currentDate).ToList();
        }

        /// <summary>
        /// Retrieves all past travel records.
        /// </summary>
        /// <returns>A list of travel records with end dates in the past.</returns>
        public List<Travel> GetPastTravel()
        {
            DateTime currentDate = DateTime.Now;
            return context.Travels.Where(x => x.EndDate < currentDate).ToList();
        }
    }
}
