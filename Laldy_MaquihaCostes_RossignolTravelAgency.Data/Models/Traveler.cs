namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Traveler
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly BirthDate { get; set; }
        public ICollection<Destination> DestinationList { get; set; }
        public ICollection<Travel> TravelList { get; set; }
    }
}
