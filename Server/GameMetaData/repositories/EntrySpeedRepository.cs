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

    public List<AverageEntrySpeedResult> GetAverageEntrySpeedOfUser(string email) {
      var collection = _databasePool.GetCollection<EntrySpeed>("game-meta-data", "guessingSpeed");
      
      return collection.Aggregate()
        .Match(new BsonDocument {{"UserEmail", email}})
        .Group<AverageEntrySpeedResult>(new BsonDocument {
          {"_id", "$UserEmail"},
          {"AverageEntrySpeed", new BsonDocument("$avg", "$EntrySpeedInMs")},
          {"MinEntrySpeed", new BsonDocument("$min", "$EntrySpeedInMs")},
          {"MaxEntrySpeed", new BsonDocument("$max", "$EntrySpeedInMs")},
        })
        .ToList();
    }
  }
}