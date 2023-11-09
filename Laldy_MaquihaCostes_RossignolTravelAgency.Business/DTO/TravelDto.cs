using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO
{
    public class TravelDto
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ICollection<Traveler> Traveler { get; set; }
    }
}
