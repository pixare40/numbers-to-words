using System;
using System.Collections.Generic;
using System.Linq;

namespace numbers_to_words
{
    public class NumberToWordConverterFactory
    {
        IDictionary<Range, INumberToWordConverter> converterDictionary;

        public NumberToWordConverterFactory()
        {
            Initialise();
        }

        public virtual void Initialise()
        {
            converterDictionary = new Dictionary<Range, INumberToWordConverter>();
            converterDictionary.Add(new Range(0, 99999), new DefaultConverter());
        }

        public INumberToWordConverter GetConverter(int number)
        {
            foreach(var c in converterDictionary.Keys)
            {
                if(Enumerable.Range(c.Start.Value, c.End.Value).Contains(number))
                {
                    return converterDictionary[c];
                }

                throw new ArgumentException();
            }

            return new DefaultConverter();
        }

        public void AddConverter(Range range, INumberToWordConverter converter)
        {
            converterDictionary.Add(range, converter);
        }

        public void ReplaceConverters(IDictionary<Range, INumberToWordConverter> converters)
        {
            converterDictionary = converters;
        }
    }
}
