using System.Collections.Generic;

namespace BusStationIS.Data.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public List<Contact>  Contacts { get; set; }
    }
}