using BusStationIS.Data.Models;
using BusStationIS.Data.ServiceSpecification;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Service
{
    public class ContactService : IContact
    {
        public IEnumerable<ContactType> GetContactTypes()
        {
            return (IEnumerable<ContactType>)Enum.GetValues(typeof(ContactType));
        }
    }
}
