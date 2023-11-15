namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public int DestinationID { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Traveler Traveler { get; set; }
    }
}
