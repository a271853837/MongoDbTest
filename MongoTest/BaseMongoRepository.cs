using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    public class BaseMongoRepository<TDocument>
    {
        private string dbName;
        protected string collectionName;
        public BaseMongoRepository(string dbName, string collectionName)
        {
            this.dbName = dbName;
            this.collectionName = collectionName;
        }

        protected IMongoDatabase Database
        {
            get
            {
                IMongoDatabase db = MongoClientManager.Instance().GetDatabase(dbName);
                return db;
            }
        }

        protected IMongoCollection<TDocument> Collection
        {
            get
            {
                return this.Database.GetCollection<TDocument>(collectionName);
            }
        }
    }
}
