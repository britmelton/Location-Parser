using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using Domain;

namespace TacoParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string csvPath = "TacoBell-US-AL.csv";
            const double metersToMiles = 0.00062137;

            var values = File.ReadAllLines(csvPath); //grabs all the values from CVS file

            var parser = new LocationParser();

            var locations = values.Select(x => parser.Parse(x)).ToArray(); //returns array of locations

            // used to store two locations that are the farthest from each other.
            ITrackable longestOrigin = null;
            ITrackable longestDestination = null;
            // stores the distance
            double longestDistance = 0;

            foreach (var origin in locations)
            {
                var originCoordinates = new GeoCoordinate(origin.Coordination.Latitude, origin.Coordination.Longitude);

                foreach (var destination in locations)
                {
                    var destinationCoordinates = new GeoCoordinate(destination.Coordination.Latitude, destination.Coordination.Longitude);

                    var distance = originCoordinates.GetDistanceTo(destinationCoordinates); //comparing the two distances

                    Console.WriteLine($"distance from {origin.Name} to {destination.Name} is {distance}");

                    // If the distance is greater than the currently saved distance,
                    // updates the distances in the two `ITrackable` variables above
                    if (distance > longestDistance)
                    {
                        longestDistance = distance;
                        longestOrigin = origin;
                        longestDestination = destination;
                        Console.WriteLine($"\nCurrent longest distance is {longestDistance}");
                    }
                }
            }

            Console.WriteLine($"\n{longestDestination.Name} is furthest away from {longestOrigin.Name}.");
            Console.WriteLine($"The total distance is {Math.Round((longestDistance * metersToMiles), 2)} miles.");
        }
    }
}
