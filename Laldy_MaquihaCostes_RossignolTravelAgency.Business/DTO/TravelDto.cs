using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO
{
    public class TravelDto
    {
        public int Id { get; set; }
        public TravelerDto Traveler { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
