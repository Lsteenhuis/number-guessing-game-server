using MongoDB.Bson.Serialization.Attributes;

namespace Server.GameMetaData.models {
  [BsonIgnoreExtraElements]
  public class AmountOfGuessesMetaData {
    public int AmountOfGuesses { get; set; }
    public double AverageAmountOfGuesses { get; set; }
    public int MinAmountOfGuesses { get; set; }
    public int MaxAmountOfGuesses { get; set; }
    
    public AmountOfGuessesMetaData(int amountOfGuesses, double averageAmountOfGuesses, int minAmountOfGuesses,
      int maxAmountOfGuesses) {
      AmountOfGuesses = amountOfGuesses;
      AverageAmountOfGuesses = averageAmountOfGuesses;
      MinAmountOfGuesses = minAmountOfGuesses;
      MaxAmountOfGuesses = maxAmountOfGuesses;
    }
  }
}