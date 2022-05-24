using Domain;

namespace Domain_Spec;

public class WhenParsingALocation
{
    [Fact]
    public void ThenLocationShouldContainLatLongName()
    {
        //Arrange
        var tacoParser = new LocationParser();
        //Act
        var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");
        //Assert
        Assert.NotNull(actual);

    }

    [Theory]
    [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
    public void ThenLongitudeShouldParse(string line, double expectedLongitude)
    {
        // TODO: Complete - "line" represents input data we will Parse to
        //       extract the Longitude.  Your .csv file will have many of these lines,
        //       each representing a TacoBell location
        //Arrange
        LocationParser longitudetester = new LocationParser();

        //Act
        ITrackable trackableLon = longitudetester.Parse(line);

        //Assert
        Assert.Equal(expectedLongitude, trackableLon.Coordination.Longitude);
    }

    //TODO: Create a test ShouldParseLatitude
    [Theory]
    [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
    public void ThenLatitudeShouldParse(string line, double expectedLatitude)
    {
        LocationParser latitudetester = new LocationParser();
        ITrackable trackableLat = latitudetester.Parse(line);
        Assert.Equal(expectedLatitude, trackableLat.Coordination.Latitude);
    }


    //if values is less than 3 cannot parse 

    //[Fact]

    //public void ThenLocationShouldNotContainLessThanThreeValues()
    //{
    //    const string csvPath = "TacoBell-US-AL.csv";
    //    var values = File.ReadAllLines(csvPath);
    //    TacoParser location = new TacoParser();
    //    ITrackable value = location.Parse(record);
    //    Assert(values.Equals(3));

    //}
}