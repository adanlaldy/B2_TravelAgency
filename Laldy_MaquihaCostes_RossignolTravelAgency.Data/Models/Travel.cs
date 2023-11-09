namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public ICollection<Traveler> Traveler { get; set; }
    }
}
