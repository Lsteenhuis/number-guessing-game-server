using System.Collections.Generic;
using Server.GameMetaData.models;

namespace Server.GameMetaData.interfaces {
  public interface IAmountOfGuessesRepository {
    List<AmountOfGuessesMetaData> GetAmountOfGuessesMetaData();
  }
}