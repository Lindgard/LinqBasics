namespace be_linqBasics.Models;

public class ScrubbedCsvRow
{
    public string City { get; set; } = string.Empty;
    public int Year { get; set; }
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Shape { get; set; } = string.Empty;
    public int DurationInSeconds { get; set; }
    public string Duration { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public int DatePosted { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}