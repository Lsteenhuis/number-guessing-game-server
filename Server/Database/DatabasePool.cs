using MongoDB.Bson;
using MongoDB.Driver;

namespace Server.Database {
  public class DatabasePool {
    private static DatabasePool _instance;
    private readonly MongoClient _mongoClient;

    private DatabasePool() {
      _mongoClient = new MongoClient();
    }

    public static DatabasePool GetInstance() {
      if (_instance == null) {
        _instance = new DatabasePool();
      }

      return _instance;
    }

    public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName) {
      var database = _mongoClient.GetDatabase(databaseName);
      
      return database.GetCollection<T>(collectionName);
    }
  }
}