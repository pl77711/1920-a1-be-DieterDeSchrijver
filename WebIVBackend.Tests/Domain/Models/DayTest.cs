using System;
using WebIVBackend.Domain.Models;
using Xunit;

namespace WebIVBackend.Tests.Domain.Models
{
    public class DayTest
    {
        Menu menu = new Menu();
        User user1 = new User();
        User user2 = new User();
        
        [Fact]
        public void Day_DayInThePast_ThrowError()
        {
            DateTime dateInThePast = new DateTime(1998, 05, 12);

            Assert.Throws<Exception>(
                () => new Day(dateInThePast, 20, menu));
        }

        [Fact]
        public void Day_DayIsToday_DayCreated()
        {
            DateTime dateNow = DateTime.Now;
            
            Day day = new Day(dateNow, 20, menu);
            
            Assert.NotNull(day);
        }

        [Fact]
        public void Day_RegisteredUsersIsEmpty()
        {
            DateTime dateNow = DateTime.Now;
            
            Day day = new Day(dateNow, 20, menu);

            Assert.True(day.RegisteredUsers.Count == 0);
        }

        [Fact]
        public void Day_NegativeMaxUsers_ThrowError()
        {
            DateTime dateNow = DateTime.Now;
            
            Assert.Throws<Exception>(
                () => new Day(dateNow, -20, menu));
        }

        [Fact]
        public void Day_MaxUsers0_ThrowsError()
        {
            DateTime dateNow = DateTime.Now;
            
            Assert.Throws<Exception>(
                () => new Day(dateNow, 0, menu));
        }
        
        [Fact]
        public void AddUser_UsersIsAdded()
        {
            DateTime dateNow = DateTime.Now;
            
            Day day = new Day(dateNow, 20, menu);
            day.AddUser(user1);

            Assert.Equal(user1, day.RegisteredUsers[0]);
        }

        [Fact]
        public void AddUser_DayIsFull_ThrowsError()
        {
            DateTime dateNow = DateTime.Now;
            
            Day day = new Day(dateNow, 1, menu);
            day.AddUser(user1);

            Assert.Throws<Exception>(
                () => day.AddUser(user2));
        }
        
        [Fact]
        public void AddUser_AlreadyAdded_ThrowsError()
        {
            DateTime dateNow = DateTime.Now;
            
            Day day = new Day(dateNow, 20, menu);
            day.AddUser(user1);

            Assert.Throws<Exception>(
                () => day.AddUser(user1));
        }
    }
}