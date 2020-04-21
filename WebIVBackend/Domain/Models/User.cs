using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebIVBackend.Domain.Models
{
    public class User
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
        public string Id;

        public string FirstName;

        public string LastName;

        public string Email;
        
        public List<Day> RegisteredDays = new List<Day>();

        public User()
        {
            
        }

        public User(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
        }
        
        public void AddDay(Day day)
        {
            if (RegisteredDays.Any(d => d.Id == day.Id))
            {
                throw new System.ArgumentException("Day already registered");
            }

            RegisteredDays.Add(day);
        }

    }
}