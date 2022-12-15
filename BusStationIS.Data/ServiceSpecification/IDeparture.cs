using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.ServiceSpecification
{
    public interface IDeparture
    {
        public IEnumerable<Departure> GetAll();
        public Departure GetById(int id);
        public bool Add(Departure newDeparture);
    }
}
