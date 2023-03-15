namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();

        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            
            var cells = line.Split(',');

           
            if (cells.Length < 3)
            {
                logger.LogWarning("CELL LENGTH LESS THAN 3, DATA INCOMPLETE");
               
                return null; 
            }
            var tacoBellLocation = new TacoBell();
            tacoBellLocation.Name = cells[2];
            tacoBellLocation.Location = new Point() { Latitude = double.Parse(cells[0]), Longitude = double.Parse(cells[1]) };

            return tacoBellLocation;
                }
    }
}
           
            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            // If your array.Length is less than 3, something went wrong
            // Log that and return null
            // Do not fail if one record parsing fails, return null
            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

           
