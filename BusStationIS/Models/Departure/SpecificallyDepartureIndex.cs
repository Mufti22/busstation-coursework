using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Departure
{
    public class SpecificallyDepartureIndex
    {
        public IEnumerable<SpecificallyDepartureDetail> SpecificallyDepartureDetails { get; set; }
        public DateTime DateTime { get; set; }
        public IEnumerable<BusStationIS.Data.Models.Departure> Departures { get; set; }
        public BusStationIS.Data.Models.Departure Departure { get; set; }
    }
}
