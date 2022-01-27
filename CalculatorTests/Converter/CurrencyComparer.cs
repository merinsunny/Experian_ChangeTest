#nullable enable
using System;
using System.Collections;

using Calculator.Model.Interface;

namespace CalculatorTests.Utilities
{
    public class CurrencyComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            var lhs = x as IMoney;
            var rhs = y as IMoney;
            
            if (lhs == null || rhs == null) throw new InvalidOperationException();
            
            return Compare(lhs, rhs);
        }

        public int Compare(IMoney x, IMoney y)
        {
            return (x.Denomination == y.Denomination && x.Quantity == y.Quantity)
                ? 0
                : -1
                ;
        }
    }
}