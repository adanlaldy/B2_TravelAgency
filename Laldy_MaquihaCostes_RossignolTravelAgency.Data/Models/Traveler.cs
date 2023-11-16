using System;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
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
