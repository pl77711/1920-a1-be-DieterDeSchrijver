using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebIVBackend.Domain.Models
{
    public class User
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<string> RegisteredDays {get; set;}

        public User()
        {
            
        }

        public User(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            RegisteredDays = new List<string>();
        }
        
        public void AddDay(string id)
        {
            if (RegisteredDays.Any(d => d == id))
            {
                throw new System.ArgumentException("Day already registered");
            }

            RegisteredDays.Add(id);
        }

    }
}