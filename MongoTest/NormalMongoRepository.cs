using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    public class NormalMongoRepository<TDocument> : BaseMongoRepository<TDocument>, IMongoRepository<TDocument> where TDocument : class, IMongoDocument
    {
        public NormalMongoRepository(string dbName, string collectionName) : base(dbName, collectionName)
        {

        }

        public long Count(FilterDefinition<TDocument> filter)
        {
            return  Collection.CountDocuments(filter);
        }

        public void InsertOne(TDocument doc)
        {
            Collection.InsertOne(doc);
        }

        public void InsertMany(IEnumerable<TDocument> docs)
        {
            Collection.InsertMany(docs);
        }

        public TDocument FindById(string id)
        {
            ObjectId oid = new ObjectId(id);
            return Collection.Find(m => m.Id.Equals(oid)).FirstOrDefaultAsync().Result;
        }

        public TDocument FindFirst(SortDefinition<TDocument> sort)
        {
            return Collection.Find(new BsonDocument()).Sort(sort).FirstOrDefault();
        }


        public TDocument FindFirst(FilterDefinition<TDocument> filter, SortDefinition<TDocument> sort)
        {
            return Collection.Find(filter).Sort(sort).FirstOrDefault();
        }

        public IEnumerable<TDocument> FindAll(FilterDefinition<TDocument> filter)
        {
            return Collection.Find(filter).ToList();
        }

        public DeleteResult Delete(TDocument doc)
        {
            return Collection.DeleteOne(c => c.Id.Equals(doc.Id));
        }

        public DeleteResult Delete(string id)
        {
            ObjectId oid = new ObjectId(id);
            return Collection.DeleteOne(m => m.Id.Equals(oid));
        }

        public DeleteResult DeleteMany(FilterDefinition<TDocument> filter)
        {
            return Collection.DeleteMany(filter);
        }

        public ReplaceOneResult Replace(TDocument doc)
        {
            return Collection.ReplaceOne(c => c.Id.Equals(doc.Id), doc);
        }

        public DeleteResult Clear()
        {
            return Collection.DeleteMany(c => true);
        }
    }
}
