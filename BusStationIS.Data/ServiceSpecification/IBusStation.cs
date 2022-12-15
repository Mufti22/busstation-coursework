using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.ServiceSpecification
{
    public interface IBusStation
    {
        BusStation GetById(int id);
        IEnumerable<BusStation> GetAll();
        IEnumerable<BusStation> GetByCity(int cityId);
        string GetContacts(BusStation station);
    }
}
