using System.Collections.Generic;
using System.Linq;
using Server.GameMetaData.interfaces;
using Server.GameMetaData.models;

namespace Server.GameMetaData.services {
  public class MetaDataCalculator: IMetaDataCalculator{
    public List<AmountOfGuessesMetaData> Calculate(IEnumerable<AmountOfGuesses> amountOfGuesses) {
      var listOfGroupedGuesses = amountOfGuesses.GroupBy(a => a.AmountOfNumbersToGuess)
        .Select(grp => grp.ToList())
        .ToList();

      return listOfGroupedGuesses.Select(CreateMetaData).ToList();
    }

    private AmountOfGuessesMetaData CreateMetaData(List<AmountOfGuesses> amountOfGuesses) {
      var amountOfNumbersToGuess = amountOfGuesses.First().AmountOfNumbersToGuess;
      var average = CalculateAverage(amountOfGuesses);
      var min = CalculateMin(amountOfGuesses);
      var max = CalculateMax(amountOfGuesses);

      return new AmountOfGuessesMetaData(amountOfNumbersToGuess, average, min, max);
    }

    private double CalculateAverage(IEnumerable<AmountOfGuesses> amountOfGuesses) {
      return amountOfGuesses.Average(guess => guess.AmountOfGuessesNeeded);
    }

    private static int CalculateMin(IEnumerable<AmountOfGuesses> amountOfGuesses) {
      return amountOfGuesses.Min(guess => guess.AmountOfGuessesNeeded);
    }

    private int CalculateMax(IEnumerable<AmountOfGuesses> amountOfGuesses) {
      return amountOfGuesses.Max(guess => guess.AmountOfGuessesNeeded);
    }
  }
}