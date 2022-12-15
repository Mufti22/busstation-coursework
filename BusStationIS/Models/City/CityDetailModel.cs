using BusStationIS.Controllers.FrontHelpers;
using BusStationIS.Data.Models;
using BusStationIS.Models.BasStation;
using BusStationIS.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models
{
    public class CityDetailModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<BusStationIS.Data.Models.Carrier> Carriers { get; set; }
        public IEnumerable<BusStation> BusStations { get; set; }
        public string Helper { get; set; }
        public Task<OpenWeatherResponseOutput> OpenWeather { get; set; }
    }
}
