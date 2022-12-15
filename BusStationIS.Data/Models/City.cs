using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string ImageUrl { get; set; }

        public override bool Equals(object obj)
        {
            if(obj is City c)
            {
                if (c.Name == Name)
                    return true;
            }
            return false;
        }


    }
}
