using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    public interface IMongoRepository<TDocument>
    {
        long Count(FilterDefinition<TDocument> filter);

        void InsertOne(TDocument doc);

        void InsertMany(IEnumerable<TDocument> docs);

        TDocument FindById(string id);

        TDocument FindFirst(SortDefinition<TDocument> sort);

        TDocument FindFirst(FilterDefinition<TDocument> filter, SortDefinition<TDocument> sort);

        IEnumerable<TDocument> FindAll(FilterDefinition<TDocument> filter);

        DeleteResult Delete(TDocument doc);

        DeleteResult Delete(string id);

        DeleteResult DeleteMany(FilterDefinition<TDocument> filter);

        ReplaceOneResult Replace(TDocument doc);

        DeleteResult Clear();
    }
}
