using System.Collections.Generic;
using Calculator.Model.Interface;

namespace Calculator
{
    public interface ICalculator
    {
        IList<IMoney> Calculate(in decimal totalAmountDue, in decimal amountGiven);
        string getCalculatedChange(in decimal totalAmountDue, in decimal amountGiven);
    }
}