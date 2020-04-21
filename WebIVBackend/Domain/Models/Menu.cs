using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebIVBackend.Domain.Models
{
    public class Menu
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
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