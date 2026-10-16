namespace Midterms.Models;

/// <summary>
/// Represents a historic Egyptian pyramid promoted for tourism.
/// </summary>
public class Pyramid
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public double Height { get; set; } // Height in meters
    public string BuiltEra { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal EntryFeeUSD { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public double Rating { get; set; }
}

