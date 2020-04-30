using System.Collections.Generic;
using MongoDB.Driver;
using WebIVBackend.Data;
using WebIVBackend.Domain.Models;

namespace WebIVBackend.Domain.Repositories
{
    public class DayRepository
    {
        private IMongoCollection<Day> _days;

        public DayRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            

            _days = database.GetCollection<Day>(settings.DaysCollectionName);
            
        }

        public void AddDay(Day day)
        {
            _days.InsertOne(day);
        }

        public Day GetDay(string id)
        {
            return _days.Find(m => m.Id.Equals(id)).FirstOrDefault();
        }

        public IList<Day> GetAll()
        {
            return _days.Find(c => true).ToList();
        }

        public Day UpdateDay(Day day)
        {
            var d = _days.Find(m => m.Id.Equals(day.Id)).FirstOrDefault();
            _days.FindOneAndReplace(m => m.Id.Equals(day.Id), day);
            return _days.Find(m => m.Id.Equals(day.Id)).FirstOrDefault();
        }

        public void DeleteDay(string id)
        {
            _days.DeleteOne(m => m.Id.Equals(id));
        }
    }
}