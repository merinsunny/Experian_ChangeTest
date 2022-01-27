using System.Collections;
using System.Collections.Generic;


using NUnit.Framework;

using Calculator.Model.Interface;
using CalculatorTests.Utilities;
using Calculator.Model;

namespace CalculatorTests
{
    public class CalculateTests
    {

        [Test]
        public void Calculate_ReturnsCorrectChangeList()
        {
            //Arrange
            var totalAmountDue = 5.50m;
            var amountGiven = 20.00m;
            IList<IMoney> expectedResult = new List<IMoney>(
                new IMoney[]
                {
                    new Money(IMoney.eDenomination.TenPound, 1),
                    new Money(IMoney.eDenomination.TwoPound,2), 
                    new Money(IMoney.eDenomination.FiftyPence,1)
                });


            var calculator = Calculator.Calculator.Create();

            //Act
            var actualResult = calculator.Calculate(totalAmountDue, amountGiven);

            //Assert
            IComparer comparer = new CurrencyComparer();
            CollectionAssert.AreEqual(expectedResult, actualResult, comparer);
        }
    }
}