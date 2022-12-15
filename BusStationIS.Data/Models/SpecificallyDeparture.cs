using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.Models
{
    public class SpecificallyDeparture
    {
        public int Id { get; set; }
        public Departure Departure { get; set; }
        public DateTime DateTime { get; set; }
    }
}
