namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public int DestinationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Traveler Traveler { get; set; }
    }
}
