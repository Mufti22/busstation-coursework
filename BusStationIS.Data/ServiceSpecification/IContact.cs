using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.ServiceSpecification
{
    public interface IContact
    {
        IEnumerable<ContactType> GetContactTypes();
    }
}
