using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {

            var tacoParser = new TacoParser();          
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("34.795116, -86.97191, Taco Bell Athens...", -86.97191)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", -84.56005)]
        public void ShouldParseLongitude(string line, double expected)
        {
            var challenger = new TacoParser();
            var actual = challenger.Parse(line).Location.Longitude;
            Assert.Equal(actual, expected);           
        }
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("34.795116, -86.97191, Taco Bell Athens...", 34.795116)]
        [InlineData("34.113051,-84.56005,Taco Bell Woodstoc...", 34.113051)]

        public void ShouldParseLatitude(string line, double expected) 
        {
            var challenger = new TacoParser();
            var actual = challenger.Parse(line).Location.Latitude;
            Assert.Equal(actual, expected);
        }
    }
}
