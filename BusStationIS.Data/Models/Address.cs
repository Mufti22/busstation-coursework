using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public virtual City City { get; set; }
    }
}
