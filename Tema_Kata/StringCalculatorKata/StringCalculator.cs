using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        private const string defaultDelimiter = ",";
        private const string delimiterIndicator = "//";
        private const int maxNumber = 1000;

        private (string, string) SplitFromFirstAppearance(string str, char delimiter)
        {
            var firstValue = str.Split(delimiter)[0];
            var lastValue = str.Substring(firstValue.Length);
            return (firstValue, lastValue);
        }

        private List<int> ConvertNumbers(string[] unconvertedNumbers)
        {
            List<int> convertedNumbers = new List<int>();
            foreach (var number in unconvertedNumbers)
            {
                int convertedNumber;
                if (Int32.TryParse(number, out convertedNumber))
                    convertedNumbers.Add(convertedNumber);
                else
                    return new List<int>();
            }
            return convertedNumbers;
        }

        private List<string> GetDelimiters(string input)
        {
            List<string> result = new List<string>();

            if (input.StartsWith(delimiterIndicator))
            {
                int x = delimiterIndicator.Length;
                string substring = input.Substring(x);
                if (substring.StartsWith('[') && substring.EndsWith(']'))
                {
                    string[] split = substring.Split(new Char[] { '[', ']' }, 
                        StringSplitOptions.RemoveEmptyEntries);

                    result = split.ToList();
                    return result;
                }
                else
                {
                    result.Add(substring);
                    return result;
                }
            }
            else
            {
                result.Add(defaultDelimiter);
                return result;
            }
        }

        private int IntListSum(List<int> list)
        {
            int sum = 0;
            foreach (var number in list)
            {
                if (number <= maxNumber)
                    sum += number;
            }
            return sum;
        }

        private void CheckForNegatives(List<int> list)
        {
            StringBuilder bld = new StringBuilder();

            foreach (var number in list)
            {
                if (number < 0)
                    bld.Append(number).Append(' ');    
            }

            string negatives = bld.ToString();
            if (negatives != "")
                throw new InvalidOperationException("Negatives not allowed: " + negatives);
        }

        private string ReplaceNewLines(string str, string delimiter)
        {
            if (str == "")
                return "";

            if (str[0] == '\n')
                str = str.Remove(0, 1);
            return str.Replace("\n", delimiter);
        }

        public int Add(string numbers)
        {
            string delimiter;
            string firstInputPart;
            string lastInputPart;
            string[] unconvertedNumbers;

            (firstInputPart, lastInputPart) = SplitFromFirstAppearance(numbers, '\n');

            List<string> delimitersList = GetDelimiters(firstInputPart);
            delimiter = delimitersList[0];
            delimitersList.RemoveRange(0, 1);

            foreach (var extraDelimiter in delimitersList) 
            {
                lastInputPart = lastInputPart.Replace(extraDelimiter, delimiter);
                numbers = numbers.Replace(extraDelimiter, delimiter);
            }

            lastInputPart = ReplaceNewLines(lastInputPart, delimiter);
            numbers = ReplaceNewLines(numbers, delimiter);

            if (!firstInputPart.StartsWith(delimiterIndicator))
            {
                unconvertedNumbers = numbers.Split(delimiter);
            }
            else
            {
                unconvertedNumbers = lastInputPart.Split(delimiter);
            }

            List<int> convertedNumbers = ConvertNumbers(unconvertedNumbers);
            CheckForNegatives(convertedNumbers);

            return IntListSum(convertedNumbers);
        }
    }
}