using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Server.GameMetaData.models;
using Server.GameMetaData.repositories;

namespace Server.GameMetaData {
  [ApiController]
  [EnableCors("AllowAll")]
  [Route("GameMetaData")]
  public class GuessingSpeedController {
    private readonly GuessingSpeedRepository _guessingSpeedRepository;
    
    public GuessingSpeedController() {
      _guessingSpeedRepository = new GuessingSpeedRepository();
    }

    [HttpGet("{email}/EntrySpeed")]
    public List<EntrySpeedMetaData> GetEntrySpeedMetaData(string email) {
      return _guessingSpeedRepository.GetAverageEntrySpeedOfUser(email);
    }
  }
}