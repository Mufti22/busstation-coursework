using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Departure
{
    public class DepartureInputModel
    {
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public string Carrier { get; set; }
        public string PaymentCategory { get; set; }
        public string VehicleRegistration { get; set; }
        public IEnumerable<BusStationIS.Data.Models.City> Cities { get; set; }
        public IEnumerable<BusStationIS.Data.Models.Carrier> Carriers { get; set; }
        public IEnumerable<BusStationIS.Data.Models.PaymentCategory> PaymentCategories { get; set; }
        public IEnumerable<BusStationIS.Data.Models.Vehicle> Vehicles { get; set; }
    }
}
