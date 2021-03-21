using MongoDB.Bson.Serialization.Attributes;

namespace Server.GameMetaData.models {
  [BsonIgnoreExtraElements]
  public class AmountOfGuesses {
    public int AmountOfNumbersToGuess { get; set; }
    public int AmountOfGuessesNeeded { get; set; } 
  }
}