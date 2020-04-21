using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver.Linq;

namespace WebIVBackend.Domain.Models
{
    public class Day
    {
        public string Id;

        public DateTime Date;

        public int MaxUsers;

        public List<User> RegisteredUsers = new List<User>();

        public Menu Menu;

        public Day()
        {
            
        }

        public Day(DateTime date, int maxUsers, Menu menu)
        {
            this.Date = date;
            this.MaxUsers = maxUsers;
            this.Menu = menu;
        }

        public void AddUser(User user)
        {
            if (RegisteredUsers.Any(u => u.Id == user.Id))
            {
                throw new System.ArgumentException("User already registered");
            }

            RegisteredUsers.Add(user);
        }
    }
}