using System;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public Country Country { get; set; }
        public string City { get; set; }
        public bool IsCapital { get; set; }
        public string PointsOfInterest { get; set; }
        public bool IsVisited { get; set; }
        public DateTime VisiteDate { get; set; }
        public int? Rate { get; set; }
        public string Comment { get; set; }
        public List<DestinationEvent> DestinationEvents { get; set; }
        public List<Traveler> Travelers { get; set; }
    }
}
