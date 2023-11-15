using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public class TravelRepository : ITravelRepository
    {
        private readonly DataContext context;

        public TravelRepository(DataContext context)
        {
            this.context = context;
        }

        //methodes
        public async Task<Travel> Add(Travel travel)
        {
            context.Travels.Add(travel);
            await context.SaveChangesAsync();
            return travel;
        }

        public async Task<Travel> Update(Travel travel)
        {
            context.Travels.Update(travel);
            await context.SaveChangesAsync();
            return travel;
        }

        public async Task<int> Delete(int id)
        {
            Travel travel = await context.Travels.FindAsync(id);
            context.Travels.Remove(travel);
            return await context.SaveChangesAsync();
        }

        public async Task<Travel> Get(int id)
        {
            return await context.Travels.FindAsync(id);
        }
    }
}
