
﻿using System.Collections.Generic;
using MongoDB.Driver;
using WebIVBackend.Data;
using WebIVBackend.Domain.Models;

namespace WebIVBackend.Domain.Repositories

{
    public class AllergyRepository
    {
        

        private IMongoCollection<Allergy> _allergies;

        public AllergyRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _allergies = database.GetCollection<Allergy>(settings.AllergiesCollectionName);
        }
        
        public IList<Allergy> GetAll()
        {
            return _allergies.Find(c => true).ToList();
        }

        public Allergy GetById(string id)
        {
            return _allergies.Find(a => a.Id.Equals(id)).FirstOrDefault();
        }
    }
    
}