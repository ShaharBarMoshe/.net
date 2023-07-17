using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Playlist.API.Models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

       [BsonElement("username")]
        public string Name { get; set; }

        [BsonElement("items")]
        public List<string> items { get; set; }
    }
}