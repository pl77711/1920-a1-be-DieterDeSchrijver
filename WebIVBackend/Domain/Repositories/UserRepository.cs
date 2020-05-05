using System.Collections.Generic;
using MongoDB.Driver;
using WebIVBackend.Data;
using WebIVBackend.Domain.Models;

namespace WebIVBackend.Domain.Repositories
{
    public class UserRepository
    {
        private IMongoCollection<User> _users;

        public UserRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            

            _users = database.GetCollection<User>(settings.UsersCollectionName);
            
        }

        public void AddUser(User user)
        {
            _users.InsertOne(user);
        }

        public User GetUser(string id)
        {
            return _users.Find(m => m.Id.Equals(id)).FirstOrDefault();
        }

        public IList<User> GetAll()
        {
            return _users.Find(c => true).ToList();
        }

        public User UpdateUser(User user)
        {
            var d = _users.Find(m => m.Id.Equals(user.Id)).FirstOrDefault();
            _users.FindOneAndReplace(m => m.Id.Equals(user.Id), user);
            return _users.Find(m => m.Id.Equals(user.Id)).FirstOrDefault();
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(m => m.Id.Equals(id));
        }
    }
}