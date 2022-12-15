using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Departure
{
    public class DepartureIndexModel
    {
       public IEnumerable<DepartureDetailModel> Departures { get; set; }
    }
}
