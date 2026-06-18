using be_linqBasics.Models;

namespace be_linqBasics.Views;

public class CsvReader
{
    private readonly string _filePath;

    public CsvReader(string filePath = "Data/scrubbed.csv")
    {
        _filePath = filePath;
    }

    /// <summary>
    /// Reads the scrubbed CSV file and returns a list of Sighting objects.
    /// </summary>
    /// <returns>A list of Sighting objects.</returns>
    public List<Sighting> ReadScrubbed()
    {
        var sightings = new List<Sighting>(); //* Initialize an empty list to hold the sightings

        var lines = File.ReadAllLines(_filePath);

        //* Skip the header line and process each subsequent line to create Sighting objects */
        foreach (var line in lines.Skip(1))
        {
            var columns = line.Split(",");

            if (columns.Length != 11) continue;

            sightings.Add(new Sighting
            {
                DateTime = columns[0].Trim(),
                City = columns[1].Trim(),
                State = columns[2].Trim(),
                Country = columns[3].Trim(),
                Shape = columns[4].Trim(),
                DurationSeconds = double.TryParse(columns[5].Trim(), out var duration) ? duration : 0,
                DurationReadable = columns[6].Trim(),
                Comments = columns[7].Trim(),
                DatePosted = columns[8].Trim(),
                Latitude = double.TryParse(columns[9].Trim(), out var latitude) ? latitude : 0,
                Longitude = double.TryParse(columns[10].Trim(), out var longitude) ? longitude : 0
            });
        }

        return sightings;
    }
}