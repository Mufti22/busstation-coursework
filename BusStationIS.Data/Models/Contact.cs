namespace BusStationIS.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public virtual ContactType Type { get; set; }
        public string ContactContent { get; set; }
    }

    public enum ContactType
    {
        LandlineTelephone = 1,
        MobilePhone = 2,
        EMail = 3,
        Fax = 4,
        Facebook = 5,
        Instagram = 6,
        Twitter = 7
    }

}