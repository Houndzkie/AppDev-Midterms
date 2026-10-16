using System.ComponentModel.DataAnnotations;

namespace Midterms.Models;

/// <summary>
/// Represents an authenticated or registered user in the Egypt Pyramids Tourism portal.
/// </summary>
public class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email address is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// User's chosen travel interest tags (e.g. Archaeology, Photography, Sunset Tours, Camel Trekking).
    /// </summary>
    public List<string> Preferences { get; set; } = new();
}

