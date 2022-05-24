using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class LocationParser
    {
        public ITrackable Parse(string record)
        {//take values from CSV file and split it into an array of strings, separated by a comma
            var values = record.Split(','); //will split a string everytime it sees a comma and turn it into an array of strings.

            var latitude = double.Parse(values[0]); // grab the latitude from your array at index 0
            var longitude = double.Parse(values[1]); // grab the longitude from your array at index 1
            var tacoBellName = values[2]; // grab the name from your array at index 2

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            var tacoBell = new Location();
            tacoBell.Name = tacoBellName;
            tacoBell.Coordination = new Point(longitude, latitude);

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
            return tacoBell;

        }
    }

    public interface ITrackable
    {
        string Name { get; set; }
        Point Coordination { get; set; }
    }

    public struct Point
    {
        public Point(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }

    internal class Location : ITrackable
    {
        public string Name { get; set; }
        public Point Coordination { get; set; }

    }


}
