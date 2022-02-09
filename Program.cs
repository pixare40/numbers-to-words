using System;

namespace numbers_to_words
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new NumberToWordConverterFactory();

            DisplayWords(args, factory);
        }

        public static void DisplayWords(string[] args, NumberToWordConverterFactory factory)
        {
            if (args.Length > 0)
            {
                foreach (var n in args)
                {
                    if (int.TryParse(n, out int parsedNumber))
                    {
                        try
                        {
                            string wordRep = DisplayWordRepresentation(factory, parsedNumber);
                            Console.WriteLine(wordRep);
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Argument does not fall within expected range");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Error Parsing Argument");
                    }
                }
            }
        }

        private static string DisplayWordRepresentation(NumberToWordConverterFactory factory, int parsedNumber)
        {
            INumberToWordConverter converter = factory.GetConverter(parsedNumber);
            return converter.GetWords(parsedNumber);
        }
    }
}
