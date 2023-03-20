using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Users_mongodb_mar17.Models
{
    public class Users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }
        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string UserName { get; set; }

        public string  UserPassword { get; set; }

        
    }
}
