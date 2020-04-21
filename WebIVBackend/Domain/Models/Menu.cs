namespace WebIVBackend.Domain.Models
{
    public class Menu
    {
        public string Id;

        public string Title;

        public string Description;

        public double Price;

        public Menu()
        {
            
        }

        public Menu(string title, string description)
        {
            this.Title = title;
            this.Description = description;
        }
    }
}