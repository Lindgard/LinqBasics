using be_linqBasics.Models;

namespace be_linqBasics.Views;

public class CsvReader
{
    public List<ScrubbedCsvRow> /*Read("./Data/scrubbed.csv")*/
    {
        var lines = File.ReadAllLines("./Data/scrubbed.csv");
    }
}