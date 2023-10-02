namespace Aloha_Academy_Graduate_Project.Models
{
    public class Category: Base
    {
        public string Name { get; set; }
        public ICollection<Activity> Activities { get; set; }

    }
}
