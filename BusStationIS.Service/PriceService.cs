using BusStationIS.Data.ServiceSpecification;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Service
{
    public class PriceService : IPriceManager
    {
        public double CalculatePrice(int distance, double priceFromCategory)
        {
            if(distance < 50)
            {
                return distance * 4 + priceFromCategory;
            }else if(distance < 100)
            {
                return distance * 5 + priceFromCategory;
            }else if(distance < 150)
            {
                return distance * 6 + priceFromCategory;
            }
            else
            {
                return distance * 7 + priceFromCategory;
            }
        }
    }
}
