using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext context;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="context"></param>
        public DestinationRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// add a destination
        /// </summary>
        /// <param name="destination"></param>
        /// <returns>Task<Destination></returns>
        public async Task<Destination> Add(Destination destination)
        {
            context.Destinations.Add(destination);
            await context.SaveChangesAsync();
            return destination;
        }
        /// <summary>
        /// update a destination
        /// </summary>
        /// <param name="destination"></param>
        /// <returns>Task<Destination></returns>
        public async Task<Destination> Update(Destination destination)
        {
            context.Destinations.Update(destination);
            await context.SaveChangesAsync();
            return destination;
        }
        /// <summary>
        /// delete  a destination
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {
            Destination destination = await context.Destinations.FindAsync(id);
            context.Destinations.Remove(destination);
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// get a destination
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<Destination></returns>
        public async Task<Destination> Get(int id)
        {
            return await context.Destinations.FindAsync(id);
        }
        /// <summary>
        /// get all destinations
        /// </summary>
        /// <returns>List<Destination></returns>
        public List<Destination> GetAll()
        {
            return context.Destinations.ToList();
        }
        /// <summary>
        /// get all destinations visited
        /// </summary>
        /// <returns>List<Destination></returns>
        public List<Destination> GetAllVisited()
        {
            return context.Destinations.Where(x => x.IsVisited == true).ToList();
        }
    }
}
