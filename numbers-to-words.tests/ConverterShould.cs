using NUnit.Framework;
using numbers_to_words;
using System;

namespace numbers_to_words.tests
{
    public class ConverterShould
    {
        [Test]
        public void DisplayCorrectNumberWhenTriggered()
        {
            var factory = new NumberToWordConverterFactory();

            var converter = factory.GetConverter(23456);
            string words = converter.GetWords(23456);

            Assert.That(words, Is.EqualTo("twenty three thousand, four hundred and fifty six"));
        }

        [Test]
        public void ShouldThrowErrorIfRangeConverterIsNotAvailable()
        {
            var factory = new NumberToWordConverterFactory();

            Assert.Throws<ArgumentException>(()=> factory.GetConverter(23452436));
        }
    }
}