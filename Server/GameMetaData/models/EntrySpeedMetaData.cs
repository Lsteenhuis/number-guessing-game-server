using MongoDB.Bson.Serialization.Attributes;

namespace Server.GameMetaData.models {
  [BsonIgnoreExtraElements] 
  public class AverageEntrySpeedResult {
    public string _id { get; set; }
    public double AverageEntrySpeed { get; set; }
    public int MinEntrySpeed { get; set; }
    public int MaxEntrySpeed { get; set; }
  }
}
