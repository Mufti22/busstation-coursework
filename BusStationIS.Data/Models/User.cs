using System;

namespace BusStationIS.Data.Models
{
    public class User:Person
    {   
        public DateTime MemberSince { get; set; }
        public virtual UserCategory Category { get; set; }
    }
}