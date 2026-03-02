using Microsoft.VisualBasic;

namespace be_linqBasics.Models;

public class CompleteCsvRow
{
    public string City { get; set; }
    public int Year { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Shape { get; set; }
    public int DurationInSeconds { get; set; }
    public string Duration { get; set; }
    public string Comments { get; set; }
    public int DatePosted { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}