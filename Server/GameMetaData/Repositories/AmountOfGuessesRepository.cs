using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Server.Database;
using Server.Database.Interfaces;
using Server.GameMetaData.interfaces;
using Server.GameMetaData.models;

namespace Server.GameMetaData.repositories {
  public class AmountOfGuessesRepository : IAmountOfGuessesRepository {
    private readonly IDatabasePool _databasePool;
    private readonly IMetaDataCalculator _metaDataCalculator;

    public AmountOfGuessesRepository(IMetaDataCalculator iMetaDataCalculator) {
      _databasePool = DatabasePool.GetInstance();
      _metaDataCalculator = iMetaDataCalculator;
    }

    public List<AmountOfGuessesMetaData> GetAmountOfGuessesMetaData() {
      // _logger.LogInformation("Starting to retrieve AmountOfGuessesMetaData");
      
      var collection = _databasePool.GetCollection<AmountOfGuesses>("game-meta-data", "amountOfGuesses")
        .AsQueryable()
        .ToList();

      return _metaDataCalculator.Calculate(collection);
    }
  }
}