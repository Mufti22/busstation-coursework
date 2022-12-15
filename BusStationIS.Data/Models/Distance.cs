namespace BusStationIS.Data.Models
{
    public class Distance
    {
        public int Id { get; set; }
        public virtual City CityFrom { get; set; }
        public virtual City CityTo { get; set; }
        public int DistanceBetween { get; set; }
    }
}