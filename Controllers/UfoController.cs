using be_linqBasics.Services;
using be_linqBasics.Views;

namespace be_linqBasics.Controllers;

public class UfoController
{
    private readonly LinqService _service;

    /// <summary>
    /// Constructor for the UfoController class. It initializes the LinqServices with the sightings read from the CSV file.
    /// </summary>
    /// <param name="csvPath">The path to the CSV file containing the sightings data.</param>
    public UfoController(string csvPath = "Data/scrubbed.csv")
    {
        var csvReader = new CsvReader();
        var sightings = csvReader.ReadScrubbed();
        _service = new LinqService(sightings);

        Console.WriteLine($"Loaded {sightings.Count} sightings from the '{csvPath}' file.\n");
    }

    /// <summary>
    /// Runs the main loop of the application, 
    /// allowing the user to select different LINQ operations to perform on the sightings data.
    /// </summary>
    public void Run()
    {
        bool running = true; //* Main loop to keep the application running until the user decides to exit
        while (running)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("UFO Sightings LINQ Basics");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. List all Cities (Select)");
            Console.WriteLine("2. List all US Sightings (Where)");
            Console.WriteLine("3. Top 10 Sightings by Duration (OrderBy)");
            Console.WriteLine("4. Count Sightings by Shape (GroupBy)");
            Console.WriteLine("5. List unique UFO Shapes (Distinct)");
            Console.WriteLine("0. Exit");
            Console.Write("\nSelect an option: ");

            var input = Console.ReadLine();
            Console.WriteLine();

            switch (input)
            {
                case "1":
                    var cities = _service.GetAllCities().Take(20);
                    Console.WriteLine("First 20 Cities:");
                    foreach (var city in cities)
                    {
                        Console.WriteLine(city);
                    }
                    break;
                case "2":
                    var usSightings = _service.GetUsSightings().Take(10);
                    Console.WriteLine("First 10 US Sightings:");
                    foreach (var sighting in usSightings)
                    {
                        Console.WriteLine($" [{sighting.DateTime}] - {sighting.City}, {sighting.State} - Shape: {sighting.Shape}");
                    }
                    break;
                case "3":
                    var longest = _service.GetSortedByDuration().Take(10);
                    Console.WriteLine("Top 10 Sightings by Duration in seconds:");
                    foreach (var sighting in longest)
                    {
                        Console.WriteLine($" {sighting.City}, {sighting.State} - {sighting.DurationSeconds}s ({sighting.DurationReadable})");
                    }
                    break;
                case "4":
                    var groups = _service.GetSightingsGroupedByShape();
                    Console.WriteLine("Sightings per shape:");
                    foreach (var group in groups.OrderByDescending(g => g.Count()))
                    {
                        Console.WriteLine($" {group.Key,-20}: {group.Count(),6} sightings");
                    }
                    break;
                case "5":
                    var shapes = _service.GetDistinctShapes();
                    Console.WriteLine("Unique UFO Shapes:");
                    foreach (var shape in shapes)
                    {
                        Console.WriteLine($" - {shape}");
                    }
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine();
        }
    }
}