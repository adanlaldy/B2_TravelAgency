using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext context;

        public EventRepository(DataContext context)
        {
            this.context = context;
        }

        //methodes
        public async Task<DestinationEvent> Add(DestinationEvent destinationEvent)
        {
            context.DestinationEvents.Add(destinationEvent);
            await context.SaveChangesAsync();
            return destinationEvent;
        }

        public async Task<DestinationEvent> Update(DestinationEvent destinationEvent)
        {
            context.DestinationEvents.Update(destinationEvent);
            await context.SaveChangesAsync();
            return destinationEvent;
        }

        public async Task<int> Delete(int id)
        {
            DestinationEvent destinationEvent = await context.DestinationEvents.FindAsync(id);
            context.DestinationEvents.Remove(destinationEvent);
            return await context.SaveChangesAsync();
        }

        public async Task<DestinationEvent> Get(int id)
        {
            return await context.DestinationEvents.FindAsync(id);
        }

        public List<DestinationEvent> GetAll()
        {
            return context.DestinationEvents.ToList();
        }
    }
}
