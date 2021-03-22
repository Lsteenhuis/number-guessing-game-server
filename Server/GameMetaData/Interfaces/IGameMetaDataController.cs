using System.Collections.Generic;
using Server.GameMetaData.models;

namespace Server.GameMetaData.interfaces {
  public interface IGameMetaDataController {
    void CreateGameMetaData(models.GameMetaData gameMetaData);
    List<EntrySpeedMetaData> GetEntrySpeedMetaData(string userName);
    List<AmountOfGuessesMetaData> GetEntrySpeedMetaData();
  }
}