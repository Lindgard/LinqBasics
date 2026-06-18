using be_linqBasics.Services;
using be_linqBasics.Views;

namespace be_linqBasics.Controllers;

public class UfoController
{
    private readonly LinqServices _service;

    /// <summary>
    /// Constructor for the UfoController class. It initializes the LinqServices with the sightings read from the CSV file.
    /// </summary>
    /// <param name="csvPath">The path to the CSV file containing the sightings data.</param>
    public UfoController(string csvPath = "Data/scrubbed.csv")
    {
        var csvReader = new CsvReader();
        var sightings = csvReader.ReadScrubbed();
        _service = new LinqServices(sightings);

        Console.WriteLine($"Loaded {sightings.Count} sightings from the '{csvPath}' file.\n");
    }

    /// <summary>
    /// Runs the LINQ queries and displays the results. 
    /// This method can be expanded to include calls to the various LINQ query methods 
    /// in the LinqServices class and display their results.
    /// </summary>
    public void Run()
    {

    }
}