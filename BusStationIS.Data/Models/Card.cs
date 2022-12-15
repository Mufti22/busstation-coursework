namespace BusStationIS.Data.Models
{
    public class Card
    {
        public int Id { get; set; }
        public double  Price { get; set; }
        public virtual User? User { get; set; }
    }
}