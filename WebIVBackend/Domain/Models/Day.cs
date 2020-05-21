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
            if (maxUsers <= 0)
            {
                throw new System.Exception("maxUsers had to be greater than 0");
            }

            if (date < DateTime.Today)
            {
                throw new System.Exception("Date can not be in the past");
            }
            
            this.Date = date;
            this.MaxUsers = maxUsers;
            this.Menu = menu;
            this.RegisteredUsers = new List<User>();
        }

        public void AddUser(User user)
        {
            if (CanAdd(user))
            {
                RegisteredUsers.Add(user);
                //user.AddDay(Id);
            }
          
        }

        private bool CanAdd(User user)
        {
            if (MaxUsers <=  RegisteredUsers.Count)
            {
                throw new System.Exception( Date.ToString("dd-MM-yyyy") +" is already full");
                
            }
            
            if (RegisteredUsers.Any(u => u.Id == user.Id))
            {
                throw new System.Exception("User already registered");
            }

            return true;

        }
        
    }
}