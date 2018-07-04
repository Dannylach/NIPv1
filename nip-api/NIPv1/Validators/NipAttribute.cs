using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace NIPv1.Validators
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NipAttribute : ValidationAttribute
    {
        private static readonly int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
        private const int nipLength = 10;

        public override bool IsValid(object value)
        {
            string input = value.ToString();
            bool result = false;
            if (input == "0") return true;
            if (input.Length == nipLength)
            {
                int controlSum = CalculateControlSum(input, weights);
                int controlNum = controlSum % 11;
                if (controlNum == nipLength)
                {
                    controlNum = 0;
                }
                int lastDigit = int.Parse(input[input.Length - 1].ToString());
                result = controlNum == lastDigit;
            }
            return result;
        }
        internal int CalculateControlSum(string input, int[] weights)
        {
            int controlSum = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                controlSum += weights[i] * int.Parse(input[i].ToString());
            }
            return controlSum;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name);
        }
    }
}