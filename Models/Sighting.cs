namespace be_linqBasics.Models;

public class Sighting
{
    public string DateTime { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Shape { get; set; } = string.Empty;
    public double DurationSeconds { get; set; }
    public string DurationReadable { get; set; } = string.Empty;
    public string Comments { get; set; } = string.Empty;
    public string DatePosted { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}