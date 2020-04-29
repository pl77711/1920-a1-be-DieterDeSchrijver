using System;
using System.Collections;
using System.Collections.Generic;
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

        public DataInit(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            database.DropCollection(settings.MenusCollectionName);
            database.DropCollection(settings.AllergiesCollectionName);

            _allergies = database.GetCollection<Allergy>(settings.AllergiesCollectionName);
            _menus = database.GetCollection<Menu>(settings.MenusCollectionName);
        }

        public void init()
        {
            
            Allergy allergy1 = new Allergy("Koemelk", "koeMelkAllergy");
            Allergy allergy2 = new Allergy("Kippenei", "kippeneiAllergy");
            Allergy allergy3 = new Allergy("Pinda", "pindaAllergy");
            Allergy allergy4 = new Allergy("Noten", "notenAllergy");
            Allergy allergy5 = new Allergy("Vis, schaal- en schelpdieren", "visSchaalSchelpAllergy");
            Allergy allergy6 = new Allergy("Roosfruit", "roosFruitAllergy");
            Allergy allergy7 = new Allergy("Soja", "sojaAllergy");
            Allergy allergy8 = new Allergy("Tarwe", "tarweAllergy");
            
            List<Allergy> allergies1 = new List<Allergy>();
            allergies1.Add(allergy1);
            allergies1.Add(allergy2);
            allergies1.Add(allergy3);
            
            List<Allergy> allergies2 = new List<Allergy>();
            allergies2.Add(allergy4);
            allergies2.Add(allergy5);
            allergies2.Add(allergy6);
            
            List<Allergy> allergies3 = new List<Allergy>();
            allergies3.Add(allergy1);
            allergies3.Add(allergy7);
            allergies3.Add(allergy8);
            
            _allergies.InsertOne(allergy1);
            _allergies.InsertOne(allergy2);
            _allergies.InsertOne(allergy3);
            _allergies.InsertOne(allergy4);
            _allergies.InsertOne(allergy5);
            _allergies.InsertOne(allergy6);
            _allergies.InsertOne(allergy7);
            _allergies.InsertOne(allergy8);
            
            Menu menu1 = new Menu("TOSTI MET ROEREI", "Tosti’s, wij zijn er gek op, net zoals op roerei trouwens. Wij hebben deze twee dingen gecombineerd en een tosti roerei gemaakt. Wij gaan dit lekkere broodje vaker voor de lunch maken.", allergies1);
            Menu menu2 = new Menu("SHAKSHUKA IN EEN BROODJE", "Shakshuka, een pannetje met tomaat, paprika en ei. Wij zijn er dol op! We eten het regelmatig als lichte avondmaaltijd of als uitgebreide lunch met wat brood erbij. Maar waarom zou je het niet lekker in een broodje serveren? ", allergies2);
            Menu menu3 = new Menu("WRAP MET FALAFEL EN RIJST", "Maak eens deze wrap met falafel en rijst. Super makkelijk om te maken en verrassend lekker. Ik wilde eigen een burrito maken met kip, maar ik bleek geen kip en avocado in huis te hebben. In de diepvries vond ik een zak met falafel balletjes en zo was dit recept geboren. Sindsdien heb ik dit recept nog 2x gemaakt, zo lekker en makkelijk! Alle ingrediënten hebben wij meestal ook in huis.", allergies3);
            Menu menu4 = new Menu("GROENE ASPERGESOEP MET SPEK", "Tover met groene asperges deze overheerlijke groene aspergesoep met spek op tafel. Makkelijk om te maken en in ongeveer 25 minuten klaar. Lekker met wat brood erbij.");
            Menu menu5 = new Menu("PASTA FRITTATA MET SPEKJES", "Een frittata is een Italiaans recept. Het gerecht is eigenlijk uit armoede ontstaan. Het wordt namelijk gemaakt van alle restjes groenten, vlees, pasta en aardappel die over zijn van de dag ervoor. Wij hebben een lekkere pasta frittata met spekjes en geroosterde paprika gemaakt.", allergies2);
            
            _menus.InsertOne(menu1);
            _menus.InsertOne(menu2);
            _menus.InsertOne(menu3);
            _menus.InsertOne(menu4);
            _menus.InsertOne(menu5);
            
            
        }
    }
}
