using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ExtratoSalarial.Core.Domain.Entities
{
    public abstract class Entity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; protected set; }

        public void Initialize()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
