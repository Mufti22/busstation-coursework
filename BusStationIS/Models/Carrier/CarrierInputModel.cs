using BusStationIS.Models.City;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Carrier
{
    public class CarrierInputModel
    {
        [Required]
        public string Name { get; set; }
        public string CityName { get; set; }
        [Required]
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public IEnumerable<BusStationIS.Data.Models.City> Cities { get; set; }
    }
}
