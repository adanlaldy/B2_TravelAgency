using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Destination
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public bool IsCapital { get; set; }
        public string PointsOfInterest { get; set; }
        public bool IsVisited { get; set; }
        public DateTime VisiteDate { get; set; }
        public int? Rate { get; set; }
        public string Comment { get; set; }
    }
}
