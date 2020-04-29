using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebIVBackend.Domain.Models
{
    public class Allergy
    {
        [BsonId] [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }

        public Allergy()
        {
            
        }

        public Allergy(string name)
        {
            Name = name;
        }

        public Allergy(string name, string iconName)
        {
            Name = name;
            IconName = iconName;
        }
    }
}