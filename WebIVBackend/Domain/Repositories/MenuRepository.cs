using System.Collections;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using WebIVBackend.Data;
using WebIVBackend.Domain.Models;

namespace WebIVBackend.Domain.Repositories
{
    public class MenuRepository
    {
        private IMongoCollection<Menu> _menus;

        public MenuRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _menus = database.GetCollection<Menu>(settings.MenusCollectionName);
        }

        public void AddMenu(Menu menu)
        {
            _menus.InsertOne(menu);
        }

        public Menu GetMenu(string id)
        {
          return _menus.Find(m => m.Id.Equals(id)).First();
        }

        public IList<Menu> GetAll()
        {
            return _menus.Find(c => true).ToList();
        }

        public Menu UpdateMenu(Menu menu)
        {
            _menus.FindOneAndReplace(m => m.Id.Equals(menu.Id), menu);
            return _menus.Find(m => m.Id.Equals(menu.Id)).First();
        }
    }
}