using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using MongoDB.Driver;
using WebIVBackend.Data;
using WebIVBackend.Domain.Models;

namespace WebIVBackend.Data
{
    public class DataInit
    {
        private IMongoCollection<Menu> _menus;
        private IMongoCollection<Allergy> _allergies;
        private IMongoCollection<Day> _days;
        private IMongoCollection<User> _users;
        private IMongoCollection<Admin> _admins;

        public DataInit(IDatabaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            database.DropCollection(settings.MenusCollectionName);
            database.DropCollection(settings.AllergiesCollectionName);
            database.DropCollection(settings.DaysCollectionName);
            database.DropCollection(settings.UsersCollectionName);
            database.DropCollection(settings.AdminsCollectionName);

            _allergies = database.GetCollection<Allergy>(settings.AllergiesCollectionName);
            _menus = database.GetCollection<Menu>(settings.MenusCollectionName);
            _days = database.GetCollection<Day>(settings.DaysCollectionName);
            _users = database.GetCollection<User>(settings.UsersCollectionName);
            _admins = database.GetCollection<Admin>(settings.AdminsCollectionName);
        }

        public void init()
        {
            
            Allergy allergy1 = new Allergy("KoemelkK", "koeMelkAllergy");
            Allergy allergy2 = new Allergy("Kippenei", "kippeneiAllergy");
            Allergy allergy3 = new Allergy("Pinda", "pindaAllergy");
            Allergy allergy4 = new Allergy("Noten", "notenAllergy");
            Allergy allergy5 = new Allergy("Vis, schaal- en schelpdieren", "visSchaalSchelpAllergy");
            Allergy allergy7 = new Allergy("Soja", "sojaAllergy");
            Allergy allergy8 = new Allergy("Tarwe", "tarweAllergy");
            
            List<Allergy> allergies1 = new List<Allergy>();
            allergies1.Add(allergy1);
            allergies1.Add(allergy2);
            allergies1.Add(allergy3);
            
            List<Allergy> allergies2 = new List<Allergy>();
            allergies2.Add(allergy4);
            allergies2.Add(allergy5);
            allergies2.Add(allergy1);
            
            List<Allergy> allergies3 = new List<Allergy>();
            allergies3.Add(allergy1);
            allergies3.Add(allergy7);
            allergies3.Add(allergy8);
            
            _allergies.InsertOne(allergy1);
            _allergies.InsertOne(allergy2);
            _allergies.InsertOne(allergy3);
            _allergies.InsertOne(allergy4);
            _allergies.InsertOne(allergy5);
            _allergies.InsertOne(allergy7);
            _allergies.InsertOne(allergy8);
            
            Menu menu1 = new Menu("TOSTI MET ROEREI", "Tosti’s, wij zijn er gek op, net zoals op roerei trouwens. Wij hebben deze twee dingen gecombineerd en een tosti roerei gemaakt. Wij gaan dit lekkere broodje vaker voor de lunch maken.", allergies1, "template");
            Menu menu2 = new Menu("SHAKSHUKA IN EEN BROODJE", "Shakshuka, een pannetje met tomaat, paprika en ei. Wij zijn er dol op! We eten het regelmatig als lichte avondmaaltijd of als uitgebreide lunch met wat brood erbij. Maar waarom zou je het niet lekker in een broodje serveren? ", allergies2, "template");
            Menu menu3 = new Menu("WRAP MET FALAFEL EN RIJST", "Maak eens deze wrap met falafel en rijst. Super makkelijk om te maken en verrassend lekker. Ik wilde eigen een burrito maken met kip, maar ik bleek geen kip en avocado in huis te hebben. In de diepvries vond ik een zak met falafel balletjes en zo was dit recept geboren. Sindsdien heb ik dit recept nog 2x gemaakt, zo lekker en makkelijk! Alle ingrediënten hebben wij meestal ook in huis.", allergies3, "template");
            Menu menu4 = new Menu("GROENE ASPERGESOEP MET SPEK", "Tover met groene asperges deze overheerlijke groene aspergesoep met spek op tafel. Makkelijk om te maken en in ongeveer 25 minuten klaar. Lekker met wat brood erbij.",allergies2, "template");
            Menu menu5 = new Menu("PASTA FRITTATA MET SPEKJES", "Een frittata is een Italiaans recept. Het gerecht is eigenlijk uit armoede ontstaan. Het wordt namelijk gemaakt van alle restjes groenten, vlees, pasta en aardappel die over zijn van de dag ervoor. Wij hebben een lekkere pasta frittata met spekjes en geroosterde paprika gemaakt.", allergies2, "template");
            
            _menus.InsertOne(menu1);
            _menus.InsertOne(menu2);
            _menus.InsertOne(menu3);
            _menus.InsertOne(menu4);
            _menus.InsertOne(menu5);
            
            DateTime date1 = new DateTime(2020,5,12);
            DateTime date2 = new DateTime(2020,5,1);
            DateTime date3 = new DateTime(2020,5,3);
            DateTime date4 = new DateTime(2020,5,11);
            DateTime date5 = new DateTime(2020,6,3);
            DateTime date6 = new DateTime(2020,5,3);
            
            Day day1 = new Day(date1,20, menu1);
            Day day2 = new Day(date2,30, menu3);
            Day day3 = new Day(date3,20, menu4);
            Day day4 = new Day(date4,20, menu2);
            Day day5 = new Day(date5,30, menu5);
            Day day6 = new Day(date6,20, menu1);

            _days.InsertOne(day1);
            _days.InsertOne(day2);
            _days.InsertOne(day3);
            _days.InsertOne(day4);
            _days.InsertOne(day5);
            _days.InsertOne(day6);
            
            User user1 = new User("Jonas", "De Smet", "jonasdesmet@gmail.com");
            User user2 = new User("Elke", "De Smet", "elkeelke@gmail.com");
            User user3 = new User("Thomas", "De Trein", "voetballer12@gmail.com");
            User user4 = new User("Saartje", "De Backer", "saartjeprive@gmail.com");
            User user5 = new User("Tuur", "Meerts", "tuurm@gmail.com");
            
            
            _users.InsertOne(user1);
            _users.InsertOne(user2);
            _users.InsertOne(user3);
            _users.InsertOne(user4);
            _users.InsertOne(user5);
            
            day1.AddUser(user1);
            day1.AddUser(user2);
            day1.AddUser(user3);
            day1.AddUser(user4);
            day1.AddUser(user5);
            day2.AddUser(user2);
            day2.AddUser(user3);
            
            _days.FindOneAndReplace(m => m.Id.Equals(day1.Id), day1);
            _days.FindOneAndReplace(m => m.Id.Equals(day2.Id), day2);
            
            Admin admin = new Admin("jvo1@telenet.be", "Test123!");
            _admins.InsertOne(admin);

            CreateAdmin("jvo1@telenet.be", "Test123!");

            
        }
        private void CreateAdmin(string email, string password)
        {
            Admin admin = new Admin(email, password);
            _admins.InsertOne(admin);
        }
    }
}
