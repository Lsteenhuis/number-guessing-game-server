using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Server.Database;
using Server.GameMetaData.models;

namespace Server.GameMetaData.repositories {
  public class GuessingSpeedRepository {
    private readonly DatabasePool _databasePool;

    public GuessingSpeedRepository() {
      _databasePool = DatabasePool.GetInstance();
    }

    public List<EntrySpeedMetaData> GetAverageEntrySpeedOfUser(string userName) {
      var collection = _databasePool.GetCollection<EntrySpeed>("game-meta-data", "guessingSpeed");

      return collection.Aggregate()
        .Match(new BsonDocument {{"UserName", userName}})
        .Group<EntrySpeedMetaData>(new BsonDocument {
          {"_id", "$UserName"},
          {"AverageEntrySpeed", new BsonDocument("$avg", "$EntrySpeedInMs")},
          {"MinEntrySpeed", new BsonDocument("$min", "$EntrySpeedInMs")},
          {"MaxEntrySpeed", new BsonDocument("$max", "$EntrySpeedInMs")},
        })
        .ToList();
    }
  }
}