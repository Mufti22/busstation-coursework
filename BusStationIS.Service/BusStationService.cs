using BusStationIS.Data;
using BusStationIS.Data.Models;
using BusStationIS.Data.ServiceSpecification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusStationIS.Service
{
    public class BusStationService:IBusStation
    {
        private readonly ApplicationDBContext _context;

        public BusStationService(ApplicationDBContext context)
        {
            _context = context;
        }

        public IEnumerable<BusStation> GetAll()
        {
            return _context.BusStations
                .Include(b => b.Address)
                    .ThenInclude(a => a.City)
                .Include(b => b.Contacts);
        }

        public IEnumerable<BusStation> GetByCity(int cityId)
        {
            return GetAll()
                .Where(b => b.Address.City.Id == cityId)
                .DefaultIfEmpty();
        }

        public BusStation GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(b => b.Id == id);
        }

        public string GetContacts(BusStation station)
        {
            var busStation = GetAll()
                .FirstOrDefault(s => s == station);

            if(busStation == null)
            {
                return null;
            }

            var contacts = busStation.Contacts;

            return HumanizHelper.HumanizeContacts(contacts);
        }
    }
}
