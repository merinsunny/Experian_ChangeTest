using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Calculator.Model;
using Calculator.Model.Interface;

namespace Calculator
{
    public class Calculator : ICalculator
    {
        private List<IMoney> currencyDenominations = null;
        private Calculator()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalAmountDue">Amount due in pounds</param>
        /// <param name="amountGiven">Amount given in pounds</param>
        /// <returns>List of denominations</returns>
        public IList<IMoney> Calculate(in decimal totalAmountDue, in decimal amountGiven)
        {
            // multiply by 100 to convert to pence
            var remainingChange = amountGiven*100 - totalAmountDue*100;

            var change =  new List<IMoney>();

            foreach (var denomination in currencyDenominations)
            {
                if (remainingChange >= denomination.Value)
                {
                    var denominationQty = (int)Math.Floor( remainingChange / denomination.Value );

                    var money = new Money(denomination.Denomination, denominationQty);

                    change.Add(money);
                    remainingChange -= money.Value;
                }
            }

            if (remainingChange != 0)
            {
                throw new Exception($@"Unexpected remaining change. {string.Format("{0:#0.00}", remainingChange/100)}");
            }



            return change;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="totalAmountDue">Amount due in pounds</param>
        /// <param name="amountGiven">Amount given in pounds</param>
        /// <returns> string of denominations  as change</returns>
        public string getCalculatedChange(in decimal totalAmountDue, in decimal amountGiven)
        {
            try
            {
                string result = "";
                var change = Calculate(totalAmountDue, amountGiven);
                foreach (Money money in change)
                {
                    result += (result.Length>0?"  ,  ":"  ") +  money.ToString() ;
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        /// <summary>
        /// Creates an new instance of the calculator and initialise it ready for use.
        /// </summary>
        /// <returns></returns>
        public static ICalculator Create()
        {
            // could do a singleton, but don't really need to.
            // using a create method so the reflection can be moved out of the constructor.
            var newInstance  = new Calculator();
            newInstance.Init();

            return newInstance;
        }

        private void Init()
        {
            currencyDenominations = new List<IMoney>();
            currencyDenominations.Add(new Money(IMoney.eDenomination.FiftyPound, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.TwentyPound, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.TenPound, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.FivePound, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.TwoPound, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.Pound, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.FiftyPence, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.TwentyPence, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.TenPence, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.FivePence, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.TwoPence, 1));
            currencyDenominations.Add(new Money(IMoney.eDenomination.Pence, 1));
                         

        }
    }
}
