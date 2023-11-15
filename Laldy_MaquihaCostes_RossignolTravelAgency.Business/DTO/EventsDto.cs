using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System.Text.Json.Serialization;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO
{
    public class EventsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int DestinationID { get; set; }
    }
}
