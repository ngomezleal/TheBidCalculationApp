using System;

namespace BidCalculationApi.Helpers
{
    public static class GenericMethods
    {
        public static bool Between(decimal number, decimal from, decimal until)
        {
            return number >= from && number <= until;
        }

        public static decimal NearestValue(decimal number, decimal from, decimal until)
        {
            var vFrom = Math.Abs(from - number);
            var vUntil = Math.Abs(until - number);
            return (vFrom < vUntil ? from : until);
        }
    }
}
