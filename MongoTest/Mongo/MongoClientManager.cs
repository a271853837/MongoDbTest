using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoTest
{
    /// <summary>
    /// MongoDb客户端管理
    /// </summary>
    public class MongoClientManager
    {
        private static MongoClient _mongoClient;
        private static int m_ConnectTimeout = 30;
        private static string MONGOSERVERHOST = "localhost";
        private static string MONGOROOTUSER = "admin";
        private static string MONGOADMINDB = "admin";
        private static int MONGOSERVERPORT = 27017;
        private static string MONGOSERVERPWD = "Li83361658";

        private static object _obj = new object();
        private MongoClientManager()
        {

        }

        public static MongoClient Instance()
        {
            if (_mongoClient == null)
            {
                lock (_obj)
                {
                    if (_mongoClient == null)
                    {
                        MongoClientSettings clientSettings = new MongoClientSettings()
                        {
                            Server = new MongoServerAddress(MONGOSERVERHOST, MONGOSERVERPORT),
                            ClusterConfigurator = builder =>
                            {
                                builder.ConfigureCluster(settings => settings.With(serverSelectionTimeout: TimeSpan.FromSeconds(m_ConnectTimeout)));
                            }
                        };
                        clientSettings.Credential = MongoCredential.CreateCredential(MONGOADMINDB, MONGOROOTUSER, MONGOSERVERPWD);
                        _mongoClient = new MongoClient(clientSettings);
                    }
                }
            }
            return _mongoClient;
        }
    }
}
