using System.Text.Json.Serialization;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int DestinationID { get; set; }
    }
}
