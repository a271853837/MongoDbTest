using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    public class MongoRepositoryFactory<TDocument> where TDocument : class, IMongoDocument
    {
        public static IMongoRepository<TDocument> CreateRepository(string dbName,string collectionName)
        {
            return new NormalMongoRepository<TDocument>(dbName, collectionName);
        }
    }
}
