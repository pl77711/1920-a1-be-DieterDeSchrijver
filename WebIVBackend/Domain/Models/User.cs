using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebIVBackend.Domain.Models
{
    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }


        public User()
        {
            
        }

        public User(string firstName, string lastName, string email)
        {    
            this.FirstName = firstName;
            this.LastName = lastName;
            Id = email;
        }

    }
}