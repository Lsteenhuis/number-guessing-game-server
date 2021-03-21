using MongoDB.Bson.Serialization.Attributes;

namespace Server.GameMetaData.models {
  [BsonIgnoreExtraElements]
  public class EntrySpeed {
    public string UserEmail { get; set; }
    public int EntrySpeedInMs { get; set; }
  }
}