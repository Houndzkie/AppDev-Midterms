namespace Midterms.Models;

/// <summary>
/// Represents a tourist booking reservation for an Egyptian pyramid tour.
/// </summary>
public class TourBooking
{
    public int Id { get; set; }
    public int PyramidId { get; set; }
    public string PyramidName { get; set; } = string.Empty;
    public DateTime TourDate { get; set; } = DateTime.Today.AddDays(1);
    public int NumberOfTickets { get; set; } = 1;
    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "Confirmed";
}

