using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.Models
{
    public class BusStation
    {
        public int Id { get; set; }
        public List<Contact> Contacts { get; set; }
        public virtual Address Address { get; set; }
    }
}
