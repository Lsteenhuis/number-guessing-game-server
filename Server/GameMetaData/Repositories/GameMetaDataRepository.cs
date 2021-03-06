using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using Server.Database;
using Server.Database.Interfaces;
using Server.GameMetaData.interfaces;

namespace Server.GameMetaData.repositories {
  public class GameMetaDataRepository: IGameMetaDataRepository {
    private readonly IDatabasePool _databasePool;

    public GameMetaDataRepository() {
      _databasePool = DatabasePool.GetInstance();
    }

    public void AddMetaData(models.GameMetaData gameMetaData) {
      // _logger.LogInformation($"Starting to insert EntrySpeed into database for {gameMetaData.Id}");
      InsertEntrySpeedInDatabase(gameMetaData);
      
      // _logger.LogInformation($"Starting to insert AmountOfGuesses into database for {gameMetaData.Id}");
      InsertAmountOfGuessesInDatabase(gameMetaData);
    }

    private void InsertEntrySpeedInDatabase(models.GameMetaData gameMetaData) {
      var metaDataCollection = _databasePool.GetCollection<BsonDocument>("game-meta-data", "guessingSpeed");
      var documents = PrepareEntrySpeedDocuments(gameMetaData);

      metaDataCollection.InsertMany(documents);
    }

    private IEnumerable<BsonDocument> PrepareEntrySpeedDocuments(models.GameMetaData gameMetaData) {
      return gameMetaData.EntrySpeedInMs.Select(entrySpeedInMs =>
        new BsonDocument {
          {"UserName", gameMetaData.UserName},
          {"EntrySpeedInMs", entrySpeedInMs}
        });
    }

    private void InsertAmountOfGuessesInDatabase(models.GameMetaData gameMetaData) {
      var metaDataCollection = _databasePool.GetCollection<BsonDocument>("game-meta-data", "amountOfGuesses");
      var document = PrepareAmountOfGuessesDocument(gameMetaData);

      metaDataCollection.InsertOne(document);
    }

    private BsonDocument PrepareAmountOfGuessesDocument(models.GameMetaData gameMetaData) {
      return new() 
      {
        {"AmountOfNumbersToGuess", gameMetaData.AmountOfNumbersToGuess},
        {"AmountOfGuessesNeeded", gameMetaData.AmountOfGuessed}
      };
    }
  }
}