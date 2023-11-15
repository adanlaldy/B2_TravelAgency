using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext context;

        public DestinationRepository(DataContext context)
        {
            this.context = context;
        }

        //methodes
        public async Task<Destination> Add(Destination destination)
        {
            context.Destinations.Add(destination);
            await context.SaveChangesAsync();
            return destination;
        }

        public async Task<Destination> Update(Destination destination)
        {
            context.Destinations.Update(destination);
            await context.SaveChangesAsync();
            return destination;
        }

        public async Task<int> Delete(int id)
        {
            Destination destination = await context.Destinations.FindAsync(id);
            context.Destinations.Remove(destination);
            return await context.SaveChangesAsync();
        }

        public async Task<Destination> Get(int id)
        {
            return await context.Destinations.FindAsync(id);
        }

        public List<Destination> GetAll()
        {
            return context.Destinations.ToList();
        }
        public List<Destination> GetAllVisited()
        {
            return context.Destinations.Where(x => x.IsVisited == true).ToList();
        }
    }
}
