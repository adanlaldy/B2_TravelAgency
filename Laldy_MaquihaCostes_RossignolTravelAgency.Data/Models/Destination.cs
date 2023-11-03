﻿namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string City { get; set; }
        public bool IsCapital { get; set; }
        public string PointsOfInterest { get; set; }
        public bool IsVisited { get; set; }
        public int? Rate { get; set; }
        public string Comment { get; set; }
        public int CountryId { get; set; }
    }
}
