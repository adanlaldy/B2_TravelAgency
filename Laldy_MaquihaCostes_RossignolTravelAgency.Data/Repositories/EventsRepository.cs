using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Migrations;
using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public class EventsRepository : IEventsRepository
    {
        private readonly DataContext context;

        public EventsRepository(DataContext context)
        {
            this.context = context;
        }

        //methodes
        public async Task<Events> Add(Events events)
        {
            context.AllEvents.Add(events);
            await context.SaveChangesAsync();
            return events;
        }

        public async Task<Events> Update(Events events)
        {
            context.AllEvents.Update(events);
            await context.SaveChangesAsync();
            return events;
        }

        public async Task<int> Delete(int id)
        {
            Events events = await context.AllEvents.FindAsync(id);
            context.AllEvents.Remove(events);
            return await context.SaveChangesAsync();
        }

        public async Task<Events> Get(int id)
        {
            return await context.AllEvents.FindAsync(id);
        }
        public async Task<List<Events>> GetEventsByDestination(int destinationID)
        {
            return context.AllEvents.Where(x => x.DestinationID == destinationID).ToList();
        }
    }
}
