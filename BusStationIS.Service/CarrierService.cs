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
    public class CarrierService : ICarrier
    {
        private readonly ApplicationDBContext _context;

        public CarrierService(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool AddNewCarrier(Carrier carrier)
        {
            try
            {
                _context.Add(carrier);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Delete(int id)
        {
            _context.Carriers.Remove(GetById(id));
            _context.SaveChanges();
        }

        public IEnumerable<Carrier> GetAll()
        {
            return _context.Carriers
                .Include(c => c.Address)
                    .ThenInclude(a => a.City)
                .Include(c => c.Contacts)
                .Include(c=>c.Vehicles);
        }

        public IEnumerable<Carrier> GetByCity(City city)
        {
            return GetAll()
                .Where(c => c.Address.City == city)
                .DefaultIfEmpty();
        }

        public Carrier GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(c => c.Id == id);
        }

        public Carrier GetByName(string name)
        {
            return GetAll()
                .FirstOrDefault(c => c.Name.ToLower() == name.ToLower());
        }

        public bool Update(Carrier carrier)
        {
            try
            {
                _context.Carriers.Update(carrier);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
