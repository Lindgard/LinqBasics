using be_linqBasics.Models;
namespace be_linqBasics.Services;

public class LinqServices
{
    private readonly List<Sighting> _sightings;

    public LinqServices(List<Sighting> sightings)
    {
        _sightings = sightings;
    }

    /// <summary>
    /// SELECT - Returns a list of all cities from the sightings.
    /// </summary>
    /// <returns>An enumerable of city names from the sightings.</returns>
    public IEnumerable<string> GetAllCities()
    {
        return _sightings.Select(s => s.City);
    }

    /// <summary>
    /// WHERE - Returns all sightings that occurred in the United States.
    /// </summary>
    /// <returns>An enumerable of Sighting objects that occurred in the United States.</returns>
    public IEnumerable<Sighting> GetUsSightings()
    {
        return _sightings.Where(s => s.Country.ToLower() == "us");
    }

    /// <summary>
    /// ORDERBY - Returns all sightings sorted by duration in descending order.
    /// </summary>
    /// <returns>An enumerable of Sighting objects sorted by duration in descending order.</returns>
    public IEnumerable<Sighting> GetSortedByDuration()
    {
        return _sightings.OrderByDescending(s => s.DurationSeconds);
    }

    /// <summary>
    /// GROUPBY - Groups sightings by shape and returns the count of sightings for each shape.
    /// </summary>
    /// <returns>An enumerable of anonymous objects containing the shape and count of sightings for each shape</returns>
    public IEnumerable<IGrouping<string, Sighting>> GetSightingsGroupedByShape()
    {
        return _sightings.GroupBy(s => s.Shape);
    }

    /// <summary>
    /// DISTINCT - Returns a list of distinct shapes from the sightings.
    /// </summary>
    /// <returns>An enumerable of distinct shapes from the sightings.</returns>
    public IEnumerable<string> GetDistinctShapes()
    {
        return _sightings.Select(s => s.Shape).Distinct();
    }
}