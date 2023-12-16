using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Entities.Base;

    public class EntityBase<T>:DomainEntity, IEntityBase<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual T Id { get; set; } = default!;
    }
