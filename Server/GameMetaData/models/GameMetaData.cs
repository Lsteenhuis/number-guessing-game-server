using System.Collections.Generic;

namespace Server.GameMetaData.models {
  public class GameMetaData {
    public string Id { get; set; }
    // ToDo GDPR? 
    public string UserEmail { get; set; }
    public IEnumerable<int> EntrySpeedInMs{ get; set; }
    public bool IsSolved { get; set; }
    public int AmountOfNumbersToGuess { get; set; }
    public int AmountOfGuessed { get; set; }
  }
}