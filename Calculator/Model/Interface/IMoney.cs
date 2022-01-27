namespace Calculator.Model.Interface
{
    public interface IMoney
    {
        public enum eDenomination
        {
            Pence,
            TwoPence,
            FivePence,
            TenPence,
            TwentyPence,
            FiftyPence,
            Pound,
            TwoPound,
            FivePound,
            TenPound,
            TwentyPound,
            FiftyPound
        }
        /// <summary>
        /// Value of the currency unit, expressed in the base unit (pence for GBP)
        /// </summary>
        eDenomination Denomination { get; }

        int Quantity { get; }
        
        /// <summary>
        /// Total value express in pence.
        /// </summary>
        int Value { get; }
    }
}
