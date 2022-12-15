using BusStationIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.Departure
{
    public class DepartureDetailModel
    {
        public int Id { get; set; }
        public BusStationIS.Data.Models.City CityFrom { get; set; }
        public BusStationIS.Data.Models.City CityTo { get; set; }
        public BusStationIS.Data.Models.Carrier  Carrier { get; set; }
        public  PaymentCategory PaymentCategory { get; set; }
        public Vehicle Vehicle { get; set; }
        public Distance Distance { get; set; }
        public int NumberOfSeats { get; set; }
        public double PriceOfCard { get; set; }
        public List<Card> Cards { get; set; }
    }
}
