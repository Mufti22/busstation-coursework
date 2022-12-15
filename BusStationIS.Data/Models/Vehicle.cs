using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationIS.Data.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public int Capacity { get; set; }
        public bool Available { get; set; }
    }
    public enum VehicleType
    {
        TheBus = 1,
        Minibus = 2,
        DoubleDecker = 3
    }
}
