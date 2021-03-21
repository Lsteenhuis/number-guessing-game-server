using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using Server.Database;
using Server.GameMetaData.models;

namespace Server.GameMetaData.repositories {
  public class GameMetaDataRepository {
    private readonly DatabasePool _databasePool;

    public GameMetaDataRepository() {
      _databasePool = DatabasePool.GetInstance();
    }

    public void AddMetaData(models.GameMetaData gameMetaData) {
      InsertEntrySpeedInDatabase(gameMetaData);
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
          {"UserEmail", gameMetaData.UserEmail},
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