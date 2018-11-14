using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    public class Test
    {
        public void TestMethod()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("admin");





            //var collection = database.GetCollection<BsonDocument>("Role");

            #region 创建一个数据库和一个集合
            //client.DropDatabase("NewDatabase"); // NewDatebase存在则删除NewDatebase
            //database = client.GetDatabase("NewDatabase"); // 获取NewDatabase 创建collection时，NewDatabase不存在则自动创建
            //database.DropCollection("NewCollection"); // NewCollection存在则删除NewCollection
            //database.CreateCollection("NewCollection"); // 创建 NewCollection

            //var options = new CreateCollectionOptions { Capped = true, MaxSize = 1024 * 1024 };
            //database.CreateCollection("NewCollection1", options);
            #endregion

            #region 列出所有库
            //Console.WriteLine("--------列出所有库----------");
            //using (var cursor = client.ListDatabases())
            //{
            //    foreach (var document in cursor.ToEnumerable())
            //    {
            //        Console.WriteLine(document.ToString());
            //    }
            //}
            #endregion

            #region 列出指定库的所有表
            //Console.WriteLine("------列出指定库的所有表-----");
            //using (var cursor = database.ListCollections())
            //{
            //    foreach (var document in cursor.ToEnumerable())
            //    {
            //        Console.WriteLine(document.ToString());
            //    }
            //}
            #endregion

            #region 列出指定表的所有数据
            //Console.WriteLine("------列出指定表的所有数据-----");
            //var cursor = collection.Find(new BsonDocument());
            //foreach (var document in cursor.ToEnumerable())
            //{
            //    Console.WriteLine(document.ToString());
            //} 
            #endregion

            #region 创建索引
            //collection.Indexes.CreateOne(new BsonDocument("newIndex", 1));

            //var keys = Builders<BsonDocument>.IndexKeys.Ascending("newIndex");
            //collection.Indexes.CreateOne(keys);
            #endregion

            #region 列出指定表的所有索引
            //Console.WriteLine("------列出指定表的所有索引-----");
            //using (var cursor = collection.Indexes.List())
            //{
            //    foreach (var document in cursor.ToEnumerable())
            //    {
            //        Console.WriteLine(document.ToString());
            //    }
            //}
            #endregion




            #region 执行指令
            var str = "{ user: \"admin\",pwd: \"Li83361658\", roles: [ { role: \"userAdminAnyDatabase\", db: \"admin\" } ]}";
            var createCommond = BsonDocument.Parse("{\"createUser\":\"admin\",\"pwd\":\"123456\",\"roles\":[{\"role\":\"userAdminAnyDatabase\",\"db\":\"admin\"}]}");
            Console.WriteLine("------执行指令-----");


            //database.RunCommand(new BsonDocumentCommand<BsonDocument>(BsonDocument.Parse("db.auth(\"admin\",\"Li83361658\"")));


            //database.RunCommand(new BsonDocumentCommand<BsonDocument>(BsonDocument.Parse("{\"authenticate\":{\"user\":\"admin\",\"pwd\":\"Li83361658\"}}")));
            var delete = BsonDocument.Parse("{ dropUser: \"admin\"}");


            //database.RunCommand(new BsonDocumentCommand<BsonDocument>(delete));
            var buildInfoCommand = new BsonDocumentCommand<BsonDocument>(createCommond);



            var result = database.RunCommand(buildInfoCommand);





            //Console.WriteLine(result);
            #endregion
        }
    }
}
