using System;

namespace numbers_to_words
{
    public class DefaultConverter : INumberToWordConverter
    {
        string[] primaryNumberStrings = new string[]
            {
                "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
                "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
            };

        string[] secondaryNumberStrings = new string[]
        {
                "zero,","ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        private string NumbersToStrings(int number)
        {
            string output = string.Empty;

            if (number % 10 == number)
            {
                return GetCase(number, 1, string.Empty);
            }

            if (number % 100 == number)
            {
                return GetTensCase(number);
            }

            if (number % 1000 == number)
            {
                return GetCase(number, 100, " hundred ", true);
            }

            if (number % 10000 == number)
            {
                return GetCase(number, 1000, " thousand, ");
            }

            if (number % 100000 == number)
            {
                return string.Format("{0} thousand, {1}", GetTensCase(number / 1000), NumbersToStrings(number % 1000));
            }

            return output;
        }

        public string GetWords(int number)
        {
            return NumbersToStrings(number);
        }

        private string GetCase(int number, int divisionNumber, string valueString, bool addAnd = false)
        {
            if (number % divisionNumber == 0)
            {
                return primaryNumberStrings[number / divisionNumber] + valueString;
            }

            int index = number / divisionNumber;

            return addAnd
                ? string.Format("{0}{1}{2}{3}", primaryNumberStrings[index], valueString, "and ", NumbersToStrings(number % divisionNumber))
                : string.Format("{0}{1}{2}", primaryNumberStrings[index], valueString, NumbersToStrings(number % divisionNumber));
        }

        private string GetTensCase(int number)
        {
            if (number % 10 == 0)
            {
                int stringIndex = (number / 10) - 1;
                return secondaryNumberStrings[stringIndex];
            }

            int tensNumber = number / 10;

            return secondaryNumberStrings[tensNumber] + " " + NumbersToStrings(number % 10);
        }
    }
}
