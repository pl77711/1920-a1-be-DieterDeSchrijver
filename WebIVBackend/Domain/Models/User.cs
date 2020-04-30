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

        public List<Day> RegisteredDays {get; set;}

        public int AmountOfPeople { get; set; }

        public User()
        {
            
        }

        public User(string firstName, string lastName, string email, int amountOfPeople)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            RegisteredDays = new List<Day>();
            AmountOfPeople = amountOfPeople;
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