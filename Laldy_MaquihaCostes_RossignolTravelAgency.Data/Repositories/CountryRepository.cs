using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext context;

        public CountryRepository(DataContext context)
        {
            this.context = context;
        }

        //methodes
        public async Task<Country> Add(Country country)
        {
            context.Countries.Add(country);
            await context.SaveChangesAsync();
            return country;
        }

        public async Task<Country> Update(Country country)
        {
            context.Countries.Update(country);
            await context.SaveChangesAsync();
            return country;
        }

        public async Task<int> Delete(int id)
        {
            Country country = await context.Countries.FindAsync(id);
            context.Countries.Remove(country);
            return await context.SaveChangesAsync();
        }

        public async Task<Country> Get(int id)
        {
            return await context.Countries.FindAsync(id);
        }

        public List<Country> GetAll()
        {
            return context.Countries.ToList();
        }
    }
}
