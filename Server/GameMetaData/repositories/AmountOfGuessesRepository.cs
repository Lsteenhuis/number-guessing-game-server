using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using Server.Database;
using Server.GameMetaData.models;
using Server.GameMetaData.services;

namespace Server.GameMetaData.repositories {
  public class AmountOfGuessesRepository {
    private readonly DatabasePool _databasePool;
    private readonly MetaDataCalculator _metaDataCalculator;

    public AmountOfGuessesRepository() {
      _databasePool = DatabasePool.GetInstance();
      _metaDataCalculator = new MetaDataCalculator();
    }

    public List<AmountOfGuessesMetaData> GetAmountOfGuessesMetaData() {
      var collection = _databasePool.GetCollection<AmountOfGuesses>("game-meta-data", "amountOfGuesses")
        .AsQueryable()
        .ToList();
      
      return _metaDataCalculator.Calculate(collection);
    }
  }
}