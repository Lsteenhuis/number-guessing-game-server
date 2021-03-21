using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Server.GameMetaData.repositories;

namespace Server.GameMetaData {
  [ApiController]
  [Route("[controller]")]
  public class GameMetaDataController {
    private readonly ILogger<GameMetaDataController> _logger;
    private readonly GameMetaDataRepository _gameMetaDataRepository;

    public GameMetaDataController(ILogger<GameMetaDataController> logger) {
      _logger = logger;
      _gameMetaDataRepository = new GameMetaDataRepository();
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
  }
}