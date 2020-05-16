using System;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MongoDB.Driver;
using WebIVBackend.Data;
using WebIVBackend.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace WebIVBackend.Domain.Services
{
    public class AdminService
    {
        private IMongoCollection<Admin> _admins;
        private string _key;
        
        public AdminService(IDatabaseSettings settings, IAppSettings appSettings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _admins = database.GetCollection<Admin>(settings.AdminsCollectionName);
            _key = appSettings.key;
        }
        
        public bool AuthorizeAdmin(LoginRequest login)
        {
            Admin admin = _admins.Find(u => u.Email.Equals(login.Email)).First();

            byte[] password = System.Text.Encoding.ASCII.GetBytes(login.Password);
            password = new System.Security.Cryptography.SHA256Managed().ComputeHash(password);
            return StructuralComparisons.StructuralEqualityComparer.Equals(password, admin.Password);

        }
        
        public string GetToken(string email)
        {
            Admin admin = _admins.Find(u => u.Email.Equals(email)).First();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, admin.Id),
                    new Claim(ClaimTypes.Role, "admin"), 
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var ret = tokenHandler.WriteToken(token);
            return ret;
        }
        
        public Admin GetAdmin(string id)
        {

            return _admins.Find(a =>
                a.Id.Equals(id)
            ).First();
        }
        
        public bool EmailAlreadyUsed(string email)
        {
            return _admins.Find(u => u.Email.Equals(email)).Any();
        }
        
    }
}