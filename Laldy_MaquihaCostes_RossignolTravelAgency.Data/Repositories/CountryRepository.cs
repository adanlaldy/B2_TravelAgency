using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    /// <summary>
    /// Repository for managing countries in the database.
    /// </summary>
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryRepository"/> class.
        /// </summary>
        /// <param name="context">The database context.</param>
        public CountryRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Adds a new country to the database.
        /// </summary>
        /// <param name="country">The country to add.</param>
        /// <returns>The added country.</returns>
        public async Task<Country> Add(Country country)
        {
            context.Countries.Add(country);
            await context.SaveChangesAsync();
            return country;
        }

        /// <summary>
        /// Updates an existing country in the database.
        /// </summary>
        /// <param name="country">The country to update.</param>
        /// <returns>The updated country.</returns>
        public async Task<Country> Update(Country country)
        {
            context.Countries.Update(country);
            await context.SaveChangesAsync();
            return country;
        }

        /// <summary>
        /// Deletes a country from the database.
        /// </summary>
        /// <param name="id">The ID of the country to delete.</param>
        /// <returns>The number of affected records.</returns>
        public async Task<int> Delete(int id)
        {
            Country country = await context.Countries.FindAsync(id);
            context.Countries.Remove(country);
            return await context.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a country by its ID.
        /// </summary>
        /// <param name="id">The ID of the country to retrieve.</param>
        /// <returns>The country found, or null if no country is found.</returns>
        public async Task<Country> Get(int id)
        {
            return await context.Countries.FindAsync(id);
        }
    }
}
