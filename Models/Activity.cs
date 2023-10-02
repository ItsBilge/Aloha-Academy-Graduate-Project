namespace Aloha_Academy_Graduate_Project.Models
{
    public class Activity: Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ActivityDate { get; set; }
        public string ActivityImage { get; set; }
        public decimal Ticketprice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
