using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebIVBackend.Domain.Models
{
    public class Admin
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
        public string Id; 
        
        public string Email;

        public Byte[] Password;

        public Admin()
        {
            
        }
        
        public Admin(string email, string password)
        {
            Email = email;
            
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            Password = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            
        }
    }
}