using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Departure
{
    public class SpecificallyDepartureDetail
    {
        public int Id { get; set; }
        public BusStationIS.Data.Models.Departure Departure { get; set; }
        public DateTime DateTime { get; set; }
    }
}
