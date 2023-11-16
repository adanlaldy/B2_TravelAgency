using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public class TravelerRepository : ITravelerRepository
    {
        private readonly DataContext context;

        public TravelerRepository(DataContext context)
        {
            this.context = context;
        }

        //methodes
        public async Task<Traveler> Add(Traveler traveler)
        {
            context.Travelers.Add(traveler);
            await context.SaveChangesAsync();
            return traveler;
        }

        public async Task<Traveler> Update(Traveler traveler)
        {
            context.Travelers.Update(traveler);
            await context.SaveChangesAsync();
            return traveler;
        }

        public async Task<int> Delete(int id)
        {
            Traveler traveler = await context.Travelers.FindAsync(id);
            context.Travelers.Remove(traveler);
            return await context.SaveChangesAsync();
        }

        public async Task<Traveler> Get(int id)
        {
            return await context.Travelers.FindAsync(id);
        }
        public List<Traveler> GetMinorTraveler()
        {
            DateOnly eighteenYearsAgo = DateOnly.FromDateTime(DateTime.Now.AddYears(-18));
            return context.Travelers.Where(x => x.BirthDate > eighteenYearsAgo).ToList();
        }
    }
}
