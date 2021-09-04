using System;

namespace GeneticAlgorithm
{
    public static class BaseConverter
    {
        public static long ToDecimal(this string binaryNum)
        {
            return Convert.ToInt64(binaryNum, 2);
        }

        public static string ToBinary(this int decimalNum)
        {
            return Convert.ToString(decimalNum, 2);
        }
    }
}
