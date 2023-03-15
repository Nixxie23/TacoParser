using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
           

            logger.LogInfo("Log initialized");

          
            var lines = File.ReadAllLines(csvPath);
            if (lines.ToArray().Length == 0)
            {
                logger.LogError("No lines detected");
            }
            else if(lines.ToArray().Length == 1)
            {
                logger.LogWarning("Only 1 line detected.");
            }
            
            logger.LogInfo($"Lines: {lines[0]}");
            
            
            var parser = new TacoParser();
            logger.LogInfo("Lines being written to an array");
           
            var locations = lines.Select(parser.Parse).ToArray();

          
            ITrackable tacoBellOne = null;
            ITrackable tacoBellTwo = null;
            double distance = 0;
            

               
            foreach(var locationA in locations)
            {
                var coordinateA = new GeoCoordinate() { Latitude = locationA.Location.Latitude, Longitude = locationA.Location.Longitude };
                foreach(var locationB in locations)
                {
                    var coordinateB = new GeoCoordinate() { Latitude = locationB.Location.Latitude, Longitude = locationB.Location.Longitude};
                    double checkDistance = coordinateB.GetDistanceTo(coordinateA);
                    if(checkDistance > distance)
                    {
                        distance = checkDistance;
                        tacoBellOne = locationA;
                        tacoBellTwo = locationB;
                    }
                }
            }
            logger.LogInfo($"{tacoBellOne.Name} and {tacoBellTwo.Name} have the most distance between them.");
        }
    }
} 

            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------
            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line

            // Create a new instance of your TacoParser class
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)       
            
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.


            
   
