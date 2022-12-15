using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Carrier
{
    public class CarrierContactInputModel
    {
        public int CarrierId { get; set; }
        public ContactType Type { get; set; }
        public string ContactContent { get; set; }
        public IEnumerable<ContactType> ContactTypes { get; set; }

    }
}
