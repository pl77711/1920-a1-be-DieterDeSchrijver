using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver.Linq;

namespace WebIVBackend.Domain.Models
{
    public class Day
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public int MaxUsers { get; set; }

        public List<User> RegisteredUsers { get; set; }

        public Menu Menu { get; set; }

        public Day()
        {
            
        }

        public Day(DateTime date, int maxUsers, Menu menu)
        {
            this.Date = date;
            this.MaxUsers = maxUsers;
            this.Menu = menu;
            this.RegisteredUsers = new List<User>();
        }

        public void AddUser(User user)
        {
            if (CanAdd((user)))
            {
                RegisteredUsers.Add(user);
            }
          
        }

        private bool CanAdd(User user)
        {
            if (this.MaxUsers < user.AmountOfPeople + RegisteredUsers.Count)
            {
                throw new System.ArgumentException("Day is already full");
                
            }
            
            if (RegisteredUsers.Any(u => u.Id == user.Id))
            {
                throw new System.ArgumentException("User already registered");
            }

            return true;

        }
        
    }
}