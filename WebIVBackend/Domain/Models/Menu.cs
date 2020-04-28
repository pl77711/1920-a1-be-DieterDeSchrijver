using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebIVBackend.Domain.Models
{
    public class Menu
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public List<string> Allergies { get; set; }

        public double Price;

        public Menu()
        {
            
        }

        public Menu(string title, string description)
        {
            Title = title;
            Description = description;
        }
        
        public Menu(string title, string description, List<string> allergies)
        {
            Title = title;
            Description = description;
            Allergies = allergies;
        }
        
    }
}