using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    /// <summary>
    /// Repository for managing travelers in the database.
    /// </summary>
    public class TravelerRepository : ITravelerRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TravelerRepository"/> class.
        /// </summary>
        /// <param name="context">The database context to be used.</param>
        public TravelerRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new traveler to the database.
        /// </summary>
        /// <param name="traveler">The traveler to add.</param>
        /// <returns>The added traveler as a <see cref="Task{Traveler}"/>.</returns>
        public async Task<Traveler> Add(Traveler traveler)
        {
            context.Travelers.Add(traveler);
            await context.SaveChangesAsync();
            return traveler;
        }

        /// <summary>
        /// Updates an existing traveler in the database.
        /// </summary>
        /// <param name="traveler">The traveler to update.</param>
        /// <returns>The updated traveler as a <see cref="Task{Traveler}"/>.</returns>
        public async Task<Traveler> Update(Traveler traveler)
        {
            context.Travelers.Update(traveler);
            await context.SaveChangesAsync();
            return traveler;
        }

        /// <summary>
        /// Deletes a traveler from the database by their identifier.
        /// </summary>
        /// <param name="id">The identifier of the traveler to delete.</param>
        /// <returns>The number of entities removed from the database as a <see cref="Task{Int}"/>.</returns>
        public async Task<int> Delete(int id)
        {
            Traveler traveler = await context.Travelers.FindAsync(id);
            context.Travelers.Remove(traveler);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a traveler by their identifier.
        /// </summary>
        /// <param name="id">The identifier of the traveler to retrieve.</param>
        /// <returns>The requested traveler as a <see cref="Task{Traveler}"/>.</returns>
        public async Task<Traveler> Get(int id)
        {
            return await context.Travelers.FindAsync(id);
        }

        /// <summary>
        /// Retrieves all travelers who are minors.
        /// </summary>
        /// <returns>A list of travelers who are under 18 years old.</returns>
        public List<Traveler> GetMinorTraveler()
        {
            DateOnly eighteenYearsAgo = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));
            return context.Travelers.Where(x => x.BirthDate > eighteenYearsAgo).ToList();
        }
    }
}
