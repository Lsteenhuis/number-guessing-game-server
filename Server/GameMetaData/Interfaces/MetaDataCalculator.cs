using System.Collections.Generic;
using Server.GameMetaData.models;

namespace Server.GameMetaData.interfaces {
  public interface IMetaDataCalculator {
    List<AmountOfGuessesMetaData> Calculate(IEnumerable<AmountOfGuesses> amountOfGuesses);
  }
}