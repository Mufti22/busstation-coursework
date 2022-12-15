using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.Models
{
    public class Carrier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Contact> Contacts { get; set; }
        public virtual Address Address { get; set; }
        public List<Vehicle> Vehicles { get; set; }

    }
}
