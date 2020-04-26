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
        List<string> _allergies = new List<string> { "noten", "ei", "soja" };

        public DataInit(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            database.DropCollection(settings.MenusCollectionName);

            _menus = database.GetCollection<Menu>(settings.MenusCollectionName);
        }

        public void init()
        {
            
            
            Menu menu1 = new Menu("TOSTI MET ROEREI", "Tosti’s, wij zijn er gek op, net zoals op roerei trouwens. Wij hebben deze twee dingen gecombineerd en een tosti roerei gemaakt. Wij gaan dit lekkere broodje vaker voor de lunch maken.", _allergies);
            Menu menu2 = new Menu("SHAKSHUKA IN EEN BROODJE", "Shakshuka, een pannetje met tomaat, paprika en ei. Wij zijn er dol op! We eten het regelmatig als lichte avondmaaltijd of als uitgebreide lunch met wat brood erbij. Maar waarom zou je het niet lekker in een broodje serveren? ", _allergies);
            Menu menu3 = new Menu("WRAP MET FALAFEL EN RIJST", "Maak eens deze wrap met falafel en rijst. Super makkelijk om te maken en verrassend lekker. Ik wilde eigen een burrito maken met kip, maar ik bleek geen kip en avocado in huis te hebben. In de diepvries vond ik een zak met falafel balletjes en zo was dit recept geboren. Sindsdien heb ik dit recept nog 2x gemaakt, zo lekker en makkelijk! Alle ingrediënten hebben wij meestal ook in huis.");
            Menu menu4 = new Menu("GROENE ASPERGESOEP MET SPEK", "Tover met groene asperges deze overheerlijke groene aspergesoep met spek op tafel. Makkelijk om te maken en in ongeveer 25 minuten klaar. Lekker met wat brood erbij.", _allergies);
            Menu menu5 = new Menu("PASTA FRITTATA MET SPEKJES", "Een frittata is een Italiaans recept. Het gerecht is eigenlijk uit armoede ontstaan. Het wordt namelijk gemaakt van alle restjes groenten, vlees, pasta en aardappel die over zijn van de dag ervoor. Wij hebben een lekkere pasta frittata met spekjes en geroosterde paprika gemaakt.", _allergies);
            
            _menus.InsertOne(menu1);
            _menus.InsertOne(menu2);
            _menus.InsertOne(menu3);
            _menus.InsertOne(menu4);
            _menus.InsertOne(menu5);
        }
    }
}
