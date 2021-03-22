using MongoDB.Driver;
using Server.Database.Interfaces;

namespace Server.Database {
  public class DatabasePool: IDatabasePool {
    private static DatabasePool _instance;
    private readonly MongoClient _mongoClient;

    public DatabasePool() {
      _mongoClient = new MongoClient();
    }

    public static DatabasePool GetInstance() {
      return _instance ??= new DatabasePool();
    }

    public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName) {
      var database = _mongoClient.GetDatabase(databaseName);
      
      return database.GetCollection<T>(collectionName);
    }
  }
}