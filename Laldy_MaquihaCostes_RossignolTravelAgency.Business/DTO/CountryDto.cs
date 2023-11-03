using Laldy_MaquihaCostes_RossignolTravelAgency.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laldy_MaquihaCostes_RossignolTravelAgency.Business.DTO
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Destination> DestinationList { get; set; }
    }
}
