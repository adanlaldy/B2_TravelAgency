namespace Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Destination> DestinationList { get; set; }
    }
}
