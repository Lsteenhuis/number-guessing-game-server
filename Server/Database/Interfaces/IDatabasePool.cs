using MongoDB.Driver;

namespace Server.Database.Interfaces {
  public interface IDatabasePool {
    public IMongoCollection<T> GetCollection<T>(string databaseName, string collectionName);
  }
}