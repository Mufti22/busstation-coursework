using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Carrier
{
    public class CarrierVehicleInputModel
    {
        public int CarrierId { get; set; }
        public string RegistrationNumber { get; set; }
        public  VehicleType VehicleType { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }
        public IEnumerable<VehicleType> VehicleTypes { get; set; }
    }
}
