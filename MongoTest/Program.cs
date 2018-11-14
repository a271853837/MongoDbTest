using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var rep = MongoRepositoryFactory<Person>.CreateRepository("Person", "table");


            Person p = new Person()
            {
                Age = 20,
                Name = "张三"
            };

            //rep.InsertOne(p);


            var filter1 = Builders<Person>.Filter.Eq(c => c.Name, "张三");
            var filter2 = Builders<Person>.Filter.Eq("Name", "张三");
            long count = rep.Count(filter1);

            Console.ReadLine();
        }
    }

    public class Person : IMongoDocument
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public ObjectId Id { get; set; }
    }
}
