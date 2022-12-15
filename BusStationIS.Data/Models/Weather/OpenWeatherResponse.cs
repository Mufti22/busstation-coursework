using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.Models.Weather
{
    public class OpenWeatherResponse
    {
        public string Name { get; set; }
        public IEnumerable<WeatherDescription> Weather { get; set; }
        public Main Main { get; set; }
        public Wind Wind { get; set; }
    }
}
