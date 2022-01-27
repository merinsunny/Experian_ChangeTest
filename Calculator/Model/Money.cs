using System;
using Calculator.Model.Interface;

namespace Calculator.Model
{
    public class Money : IMoney
    {
        public Money(IMoney.eDenomination denomination, int quantity)
        {
            Denomination = denomination;
            Quantity = quantity;
        }

        public IMoney.eDenomination Denomination { get; }
        public int Quantity { get; }
        public int Value => baseValue * Quantity;

        /// <summary>
        /// Value expressed as whole pence
        /// </summary>
        private int baseValue => GetBaseValue();

        private int GetBaseValue()
        {
            switch (Denomination)
            {
                case IMoney.eDenomination.Pence:       return 1;
                case IMoney.eDenomination.TwoPence:    return 2;
                case IMoney.eDenomination.FivePence:   return 5;
                case IMoney.eDenomination.TenPence:    return 10;
                case IMoney.eDenomination.TwentyPence: return 20;
                case IMoney.eDenomination.FiftyPence:  return 50;
                case IMoney.eDenomination.Pound:       return 100;
                case IMoney.eDenomination.TwoPound:    return 200;
                case IMoney.eDenomination.FivePound:   return 500;
                case IMoney.eDenomination.TenPound:    return 1000;
                case IMoney.eDenomination.TwentyPound: return 2000;
                case IMoney.eDenomination.FiftyPound:  return 5000;
                
                default:
                    throw new Exception(@"Unknown denomination.");
            }
        }

        private string DisplayString()
        {
            switch (Denomination)
            {
                case IMoney.eDenomination.Pence: return "1p";
                case IMoney.eDenomination.TwoPence: return "2p";
                case IMoney.eDenomination.FivePence: return "5p";
                case IMoney.eDenomination.TenPence: return "10p";
                case IMoney.eDenomination.TwentyPence: return "20p";
                case IMoney.eDenomination.FiftyPence: return "50p";
                case IMoney.eDenomination.Pound: return "£1";
                case IMoney.eDenomination.TwoPound: return "£2";
                case IMoney.eDenomination.FivePound: return "£5";
                case IMoney.eDenomination.TenPound: return "£10";
                case IMoney.eDenomination.TwentyPound: return "£20";
                case IMoney.eDenomination.FiftyPound: return "£50";

                default:
                    throw new Exception(@"Unknown denomination.");
            }

        }
        public override string ToString()
        {
            return $"{Quantity} x {DisplayString()}";
        }
    }
}