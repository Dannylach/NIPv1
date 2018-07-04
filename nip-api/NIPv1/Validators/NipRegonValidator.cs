using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NIPv1.Validators
{
    public class NipRegonValidator
    {
        private static readonly int[] Weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
        private static readonly int[] WeightsShort = { 8, 9, 2, 3, 4, 5, 6, 7 };
        private static readonly int[] WeightsLong = { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
        private const int RegonLongLength = 14;
        private const int RegonShortLength = 7;
        private const int RegonMidLength = 9;
        private const int NipLength = 10;

        public static int IsValid(string value)
        {
            string input = value;
            int controlSum;
            int controlNum;
            int lastDigit;
            if (input.Length == NipLength)
            {
                if (value[0] == '0' && value[1] == '0' && value[2] == '0') return 1;
                controlSum = CalculateControlSum(input, Weights);
                controlNum = controlSum % 11;
                if (controlNum == NipLength)
                {
                    controlNum = 0;
                }
                lastDigit = int.Parse(input[input.Length - 1].ToString());
                if(controlNum == lastDigit) return 0;
            }
            if (input.Length == RegonShortLength || input.Length == RegonMidLength)
            {
                int offset = 9 - input.Length;
                controlSum = CalculateControlSum(input, WeightsShort, offset);
            }
            else if (input.Length == RegonLongLength)
            {
                controlSum = CalculateControlSum(input, WeightsLong);
            }
            else
            {
                return 1;
            }
            controlNum = controlSum % 11;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            lastDigit = int.Parse(input[input.Length - 1].ToString());
            if(controlNum == lastDigit) return 2;
            return 3;
        }
        internal static int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
    }
}