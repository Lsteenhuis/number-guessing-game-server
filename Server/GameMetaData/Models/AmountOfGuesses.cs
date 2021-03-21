using MongoDB.Bson.Serialization.Attributes;

namespace Server.GameMetaData.models {
  [BsonIgnoreExtraElements]
  public class AmountOfGuesses {
    public int AmountOfNumbersToGuess { get; set; }
    public int AmountOfGuessesNeeded { get; set; }

    public AmountOfGuesses(int amountOfNumbersToGuess, int amountOfGuessesNeeded) {
      AmountOfNumbersToGuess = amountOfNumbersToGuess;
      AmountOfGuessesNeeded = amountOfGuessesNeeded;

    }
  }
}