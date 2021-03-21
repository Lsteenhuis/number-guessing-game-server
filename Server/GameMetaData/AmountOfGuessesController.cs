using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Server.GameMetaData.models;
using Server.GameMetaData.repositories;

namespace Server.GameMetaData {
  [ApiController]
  [Route("GameMetaData")]
  public class AmountOfGuessesController {
    private readonly AmountOfGuessesRepository _amountOfGuessesRepository;

      public AmountOfGuessesController() {
        _amountOfGuessesRepository = new AmountOfGuessesRepository();
      }
      
      [HttpGet("/amountOfGuesses")]
      public List<AmountOfGuessesMetaData> GetEntrySpeedMetaData() {
        return _amountOfGuessesRepository.GetAmountOfGuessesMetaData();
      }
  }
}