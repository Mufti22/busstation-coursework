using BusStationIS.Models.CarrierViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusStationIS.Models.CarrierViewModel
{
    public class CarrierIndexModel
    {
        public IEnumerable<CarrierDetailModel> Carriers { get; set; }
    }
}
