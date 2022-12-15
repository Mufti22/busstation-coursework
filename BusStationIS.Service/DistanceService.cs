using BusStationIS.Data;
using BusStationIS.Data.Models;
using BusStationIS.Data.Models.Weather;
using BusStationIS.Data.ServiceSpecification;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusStationIS.Service
{
    public class DistanceService:IDistance
    {
        private readonly ApplicationDBContext _context;

        public DistanceService(ApplicationDBContext context)
        {
            _context = context;
        }

        public Distance CalculateDistance(City cityForm, City cityTo)
        {
            return GetAll()
                .FirstOrDefault(d => (d.CityFrom == cityForm && d.CityTo == cityTo)
                || (d.CityFrom == cityTo && d.CityTo == cityForm));
        }

        public IEnumerable<Distance> GetAll()
        {
            return _context.Distances
                .Include(d => d.CityFrom)
                .Include(d => d.CityTo);
        }
    }
}
