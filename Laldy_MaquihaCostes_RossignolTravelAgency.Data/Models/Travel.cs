using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public Traveler Traveler { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
