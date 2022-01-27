using System.Collections;
using System.Collections.Generic;
using Calculator.Model;
using Calculator.Model.Interface;
using NUnit.Framework;

namespace CalculatorTests
{
    public class CurrencyUnitTests
    {

        [Test]
        [TestCaseSource(nameof(TestCaseSourceData))]
        public void ToString_ReturnsText(Money testCurrencyUnit, string expectedResult)
        {
            //Arrange
            
            //Act
            var actualResult = testCurrencyUnit.ToString();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        public static IEnumerable<TestCaseData> TestCaseSourceData()
        {
            yield return new TestCaseData(new Money(IMoney.eDenomination.Pence, 1), @"1 x 1p");
            yield return new TestCaseData(new Money(IMoney.eDenomination.Pence, 99), @"99 x 1p");
            yield return new TestCaseData(new Money(IMoney.eDenomination.Pound, 1), @"1 x £1");
            yield return new TestCaseData(new Money(IMoney.eDenomination.TenPound, 10), @"10 x £10");
        }
    }
}
