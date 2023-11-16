using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO
{
    public class TravelDto
    {
        public int Id { get; set; }
        public int DestinationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Traveler Traveler { get; set; }
    }
}
