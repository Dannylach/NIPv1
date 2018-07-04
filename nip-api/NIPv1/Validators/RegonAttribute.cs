using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NIPv1.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class RegonAttribute : ValidationAttribute
    {
        private static readonly int[] weightsShort = { 8, 9, 2, 3, 4, 5, 6, 7 };
        private static readonly int[] weightsLong = { 2, 4, 8, 5, 0, 9, 7, 3, 6, 1, 2, 4, 8 };
        private const int regonLongLength = 14;
        private const int regonShortLength = 7;
        private const int regonMidLength = 9;

        /// <summary>
        /// Regon validator
        /// </summary>
        /// <param name="value">Regon value</param>
        /// <returns>If Regon is validate or not</returns>
        public override bool IsValid(object value)
        {
            string input = value.ToString();
            int controlSum;
            if (input == "0") return true;
            if (input.Length == regonShortLength || input.Length == regonMidLength)
            {
                int offset = 9 - input.Length;
                controlSum = CalculateControlSum(input, weightsShort, offset);
            }
            else if (input.Length == regonLongLength)
            {
                controlSum = CalculateControlSum(input, weightsLong);
            }
            else
            {
                return false;
            }

            int controlNum = controlSum % 11;
            if (controlNum == 10)
            {
                controlNum = 0;
            }
            int lastDigit = int.Parse(input[input.Length - 1].ToString());

            return controlNum == lastDigit;
        }

        /// <summary>
        /// calculates control sum for regon validation
        /// </summary>
        /// <param name="input"> Regon value</param>
        /// <param name="weights"> Regon weights</param>
        /// <param name="offset"> optional offset value</param>
        /// <returns></returns>
        internal int CalculateControlSum(string input, int[] weights, int offset = 0)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i + offset] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }

        /// <summary>
        /// Formats error messate
        /// </summary>
        /// <param name="name">String containing error message</param>
        /// <returns></returns>
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
                ErrorMessageString, name);
        }
    }
}