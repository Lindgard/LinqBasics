namespace be_linqBasics.Models;

public class ScrubbedCsvRow
{
    public string city { get; set; } = string.Empty;
    public int year { get; set; }
    public string state { get; set; } = string.Empty;
    public string country { get; set; } = string.Empty;
    public string shape { get; set; } = string.Empty;
    public int durationInSeconds { get; set; }
    public string duration { get; set; } = string.Empty;
    public string comments { get; set; } = string.Empty;
    public int datePosted { get; set; }
    public decimal latitude { get; set; }
    public decimal longitude { get; set; }
}