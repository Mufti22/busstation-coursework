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
    public class DepartureService : IDeparture
    {
        private readonly ApplicationDBContext _context;

        public DepartureService(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool Add(Departure newDeparture)
        {
            newDeparture.Cards = new List<Card>();
            try
            {
                _context.Add(newDeparture);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Departure> GetAll()
        {
            return _context.Departures
                .Include(d => d.CityFrom)
                .Include(d => d.CityTo)
                .Include(d => d.Distance)
                .Include(d => d.Carrier)
                    .ThenInclude(c => c.Address)
                .Include(d => d.PaymentCategory)
                .Include(d => d.Vehicle);
        }

        public Departure GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(d => d.Id == id);
        }
    }
}
