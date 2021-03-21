using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.GameMetaData.models;
using Server.GameMetaData.repositories;

namespace Server.GameMetaData {
  [ApiController]
  [Route("[controller]")]
  public class GameMetaDataController {
    private readonly ILogger<GameMetaDataController> _logger;
    private readonly GameMetaDataRepository _gameMetaDataRepository;
    private readonly GuessingSpeedRepository _guessingSpeedRepository;
    private readonly AmountOfGuessesRepository _amountOfGuessesRepository;

    public GameMetaDataController(ILogger<GameMetaDataController> logger) {
      _logger = logger;
      _gameMetaDataRepository = new GameMetaDataRepository();
      _guessingSpeedRepository = new GuessingSpeedRepository();
      _amountOfGuessesRepository = new AmountOfGuessesRepository();
    }

    [HttpPost]
    public void CreateGameMetaData(models.GameMetaData gameMetaData) {
      try {
        _logger.LogInformation("Trying to store GameSession \"{0}\" to the database", gameMetaData.Id);

        _gameMetaDataRepository.AddMetaData(gameMetaData);
      } catch (Exception error) {
        _logger.LogError("Encountered an error while trying to store GameSession \"{0}\" to the database. {1} ",
          gameMetaData.Id, error.Message);
        throw;
      }
    }
    
    [HttpGet("{userName}/EntrySpeed")]
    public List<EntrySpeedMetaData> GetEntrySpeedMetaData(string userName) {
      return _guessingSpeedRepository.GetAverageEntrySpeedOfUser(userName);
    }
    
    [HttpGet("/amountOfGuesses")]
    public List<AmountOfGuessesMetaData> GetEntrySpeedMetaData() {
      return _amountOfGuessesRepository.GetAmountOfGuessesMetaData();
    }
  }
}