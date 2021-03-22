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
        var errorMessage =
          $"Encountered an error while trying to store GameSession \"{gameMetaData.Id}\" to the database. {error.Message} ";
        
        _logger.LogError(errorMessage);
        
        throw new Exception(errorMessage);
      }
    }
    
    [HttpGet("{userName}/EntrySpeed")]
    public List<EntrySpeedMetaData> GetEntrySpeedMetaData(string userName) {
      try {
        _logger.LogInformation("Trying to retrieve EntrySpeedMetaData for user \"{0}\"", userName);
        
        return _guessingSpeedRepository.GetAverageEntrySpeedOfUser(userName);
      }
      catch (Exception error) {
        var errorMessage =
          $"Encountered an error while trying to retrieve EntrySpeedMetaData for user  {userName}. Error: {error.Message} ";
        
        _logger.LogError(errorMessage);
        
        throw new Exception(errorMessage);
      }
    }
    
    [HttpGet("/amountOfGuesses")]
    public List<AmountOfGuessesMetaData> GetEntrySpeedMetaData() {
      try {
        return _amountOfGuessesRepository.GetAmountOfGuessesMetaData();
      }
      catch (Exception error) {
        var errorMessage =
          $"Encountered an error while trying to retrieve AmountOfGuessesMetaData. Error: {error.Message} ";
        
        _logger.LogError(errorMessage);
        
        throw new Exception(errorMessage);
      }
    }
  }
}