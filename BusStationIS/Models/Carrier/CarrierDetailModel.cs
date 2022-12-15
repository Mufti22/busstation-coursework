using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.CarrierViewModel
{
    public class CarrierDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contacts { get; set; }
        public virtual Address Address { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
