using MongoDB.Bson;


namespace MongoTest
{
    public interface IMongoDocument
    {
        ObjectId Id { get; set; }
    }
}
