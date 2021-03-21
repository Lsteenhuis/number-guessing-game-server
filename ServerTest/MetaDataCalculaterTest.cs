using System.Collections.Generic;
using NUnit.Framework;
using Server.GameMetaData.models;
using Server.GameMetaData.services;

namespace ServerTest {
  public class Tests {
    private MetaDataCalculator _metaDataCalculator;
    private List<AmountOfGuesses> _listOfGuesses;

    [SetUp]
    public void Setup() {
      _metaDataCalculator = new MetaDataCalculator();
      _listOfGuesses = new List<AmountOfGuesses> {
        new(4, 2),
        new(4, 3),
        new(5, 3),
        new(5, 6),
        new(5, 8),
        new(6, 5),
        new(7, 6),
        new(8, 7)
      };
    }

    [Test]
    public void Calculate_Should_Group_On_Amount_Of_Numbers_To_Guess() {
      var amountOfGuessesMetaData = _metaDataCalculator.Calculate(_listOfGuesses);

      Assert.AreEqual(5, amountOfGuessesMetaData.Count);
    }

    [Test]
    public void Calculate_Should_Get_The_Correct_Min_On_Guesses() {
      var amountOfGuessesMetaData = _metaDataCalculator.Calculate(_listOfGuesses);
      var metaDataOfNumber4 = amountOfGuessesMetaData.Find(guesses => guesses.AmountOfGuesses == 4);

      Assert.AreEqual(2, metaDataOfNumber4.MinAmountOfGuesses);
    }
    
    [Test]
    public void Calculate_Should_Get_The_Correct_Average_On_Guesses() {
      var amountOfGuessesMetaData = _metaDataCalculator.Calculate(_listOfGuesses);
      var metaDataOfNumber4 = amountOfGuessesMetaData.Find(guesses => guesses.AmountOfGuesses == 4);

      Assert.AreEqual(2.5, metaDataOfNumber4.AverageAmountOfGuesses);
    }
    
    [Test]
    public void Calculate_Should_Get_The_Correct_Max_On_Guesses() {
      var amountOfGuessesMetaData = _metaDataCalculator.Calculate(_listOfGuesses);
      var metaDataOfNumber4 = amountOfGuessesMetaData.Find(guesses => guesses.AmountOfGuesses == 4);

      Assert.AreEqual(3, metaDataOfNumber4.MaxAmountOfGuesses);
    }
    
    [Test]
    public void Calculate_Should_Return_Expected_Object_For_5() {
      var amountOfGuessesMetaData = _metaDataCalculator.Calculate(_listOfGuesses);
      var metaDataOfNumber5 = amountOfGuessesMetaData.Find(guesses => guesses.AmountOfGuesses == 5);

      Assert.AreEqual(5, metaDataOfNumber5.AmountOfGuesses);
      Assert.AreEqual(5.666666666666667d, metaDataOfNumber5.AverageAmountOfGuesses);
      Assert.AreEqual(3, metaDataOfNumber5.MinAmountOfGuesses);
      Assert.AreEqual(8, metaDataOfNumber5.MaxAmountOfGuesses);
    }
    
    [Test]
    public void Calculate_Should_Return_Expected_Object_For_6() {
      var amountOfGuessesMetaData = _metaDataCalculator.Calculate(_listOfGuesses);
      var metaDataOfNumber6 = amountOfGuessesMetaData.Find(guesses => guesses.AmountOfGuesses == 6);

      Assert.AreEqual(6, metaDataOfNumber6.AmountOfGuesses);
      Assert.AreEqual(5.0d, metaDataOfNumber6.AverageAmountOfGuesses);
      Assert.AreEqual(5, metaDataOfNumber6.MinAmountOfGuesses);
      Assert.AreEqual(5, metaDataOfNumber6.MaxAmountOfGuesses);
    }
  }
}