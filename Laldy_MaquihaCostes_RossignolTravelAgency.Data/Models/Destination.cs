using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Event> Events { get; set; }
        public List<Traveler> Travelers { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Destination Destination { get; set; }
    }

    public class Traveler
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Destination Destination { get; set; }
    }
}
