using System;
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

    public void AddMetaData(GameMetaDataDto gameMetaDataDto) {
      InsertEntrySpeedInDatabase(gameMetaDataDto);
      InsertAmountOfGuessesInDatabase(gameMetaDataDto);
    }

    private void InsertEntrySpeedInDatabase(GameMetaDataDto gameMetaDataDto) {
      var metaDataCollection = _databasePool.GetCollection<BsonDocument>("game-meta-data", "guessingSpeed");
      var documents = PrepareEntrySpeedDocuments(gameMetaDataDto);

      metaDataCollection.InsertMany(documents);
    }

    private IEnumerable<BsonDocument> PrepareEntrySpeedDocuments(GameMetaDataDto gameMetaData) {
      return gameMetaData.EntrySpeedInMs.Select(entrySpeedInMs =>
        new BsonDocument {
          {"UserEmail", gameMetaData.UserEmail},
          {"EntrySpeedInMs", entrySpeedInMs}
        });
    }

    private void InsertAmountOfGuessesInDatabase(GameMetaDataDto gameMetaDataDto) {
      var metaDataCollection = _databasePool.GetCollection<BsonDocument>("game-meta-data", "amountOfGuesses");
      var document = PrepareAmountOfGuessesDocument(gameMetaDataDto);

      metaDataCollection.InsertOne(document);
    }

    private BsonDocument PrepareAmountOfGuessesDocument(GameMetaDataDto gameMetaData) {
      return new() 
      {
        {"id", gameMetaData.Id},
        {"amountOfNumbersToGuess", gameMetaData.AmountOfNumbersToGuess},
        {"amountOfGuesses", gameMetaData.AmountOfGuessed}
      };
    }
  }
}