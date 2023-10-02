namespace Aloha_Academy_Graduate_Project.Models
{
    public class Location: Base
    {
        public string Name { get; set; }
        public int Capasity { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public ICollection<Activity> Activities { get; set; }

    }
}
