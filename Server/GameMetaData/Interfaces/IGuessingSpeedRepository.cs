using System.Collections.Generic;
using Server.GameMetaData.models;

namespace Server.GameMetaData.interfaces {
  public interface IGuessingSpeedRepository {
    public List<EntrySpeedMetaData> GetAverageEntrySpeedOfUser(string userName);
  }
}