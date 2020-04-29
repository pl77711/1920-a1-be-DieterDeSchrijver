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
        
        public List<Allergy> Allergies { get; set; }

        public double Price;

        public Menu()
        {
            Allergies = new List<Allergy>();
        }

        public Menu(string title, string description)
        {
            Title = title;
            Description = description;
            Allergies = new List<Allergy>();
        }
        
        public Menu(string title, string description, List<Allergy> allergies)
        {
            Title = title;
            Description = description;
            Allergies = allergies;
        }
        
        
        
        
    }
}