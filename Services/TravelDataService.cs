using Midterms.Models;

namespace Midterms.Services;

/// <summary>
/// Scoped service providing state management for the Egypt Pyramids Tourism portal.
/// Holds the promoted pyramids list, user session, and active tour bookings across all pages.
/// </summary>
public class TravelDataService
{
    public event Action? OnChange;

    public List<Pyramid> Pyramids { get; private set; } = new();
    public List<TourBooking> Bookings { get; private set; } = new();
    public List<User> RegisteredUsers { get; private set; } = new();

    public User? CurrentUser { get; private set; }

    public bool IsAuthenticated => CurrentUser != null;

    private int _nextBookingId = 101;
    private int _nextUserId = 1;

    public TravelDataService()
    {
        InitializeSeedData();
    }

    private void InitializeSeedData()
    {
        // 1. Seed Promoted Pyramids
        Pyramids = new List<Pyramid>
        {
            new Pyramid
            {
                Id = 1,
                Name = "Great Pyramid of Giza",
                Location = "Giza Plateau, Greater Cairo",
                Height = 146.6,
                BuiltEra = "Old Kingdom, 4th Dynasty (~2560 BC)",
                Description = "The monumental tomb of Pharaoh Khufu. The oldest and sole surviving wonder of the original Seven Wonders of the Ancient World, constructed with over 2.3 million megalithic limestone blocks.",
                EntryFeeUSD = 25.00m,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e7/Great_Pyramid_of_Giza_-_Pyramid_of_Khufu.jpg/1280px-Great_Pyramid_of_Giza_-_Pyramid_of_Khufu.jpg",
                Rating = 4.95
            },
            new Pyramid
            {
                Id = 2,
                Name = "Pyramid of Khafre",
                Location = "Giza Plateau, Greater Cairo",
                Height = 136.4,
                BuiltEra = "Old Kingdom, 4th Dynasty (~2570 BC)",
                Description = "Built for Pharaoh Khafre, son of Khufu. Perched on higher bedrock and still crowned by its lustrous original polished Tura limestone casing stones, guarded by the iconic Great Sphinx.",
                EntryFeeUSD = 20.00m,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/6/69/Pyramid_of_Khafre_and_Sphinx%2C_Giza%2C_Greater_Cairo%2C_Egypt.jpg",
                Rating = 4.88
            },
            new Pyramid
            {
                Id = 3,
                Name = "Step Pyramid of Djoser",
                Location = "Saqqara Necropolis, Giza",
                Height = 62.5,
                BuiltEra = "Old Kingdom, 3rd Dynasty (~2670 BC)",
                Description = "Designed by the legendary architect Imhotep for Pharaoh Djoser. Widely celebrated as humanity's very first colossal stone monument, pioneering a revolutionary six-tiered mastaba design.",
                EntryFeeUSD = 18.00m,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6a/Sakkara_01.jpg/1280px-Sakkara_01.jpg",
                Rating = 4.82
            }
        };

        // 2. Seed Default Registered User
        var defaultUser = new User
        {
            Id = _nextUserId++,
            Username = "RamsesExplorer",
            Email = "ramses@pyramids.eg",
            Password = "Password123!",
            Preferences = new List<string> { "Archaeology", "Sunset Tours", "VIP Tomb Access", "Photography" }
        };
        RegisteredUsers.Add(defaultUser);

        // Pre-authenticate the demo user so dashboard is vibrant upon first arrival
        CurrentUser = defaultUser;

        // 3. Seed Sample Active Tour Bookings
        Bookings = new List<TourBooking>
        {
            new TourBooking
            {
                Id = _nextBookingId++,
                PyramidId = 1,
                PyramidName = "Great Pyramid of Giza",
                TourDate = DateTime.Today.AddDays(2),
                NumberOfTickets = 2,
                TotalPrice = 50.00m,
                Status = "Confirmed"
            },
            new TourBooking
            {
                Id = _nextBookingId++,
                PyramidId = 3,
                PyramidName = "Step Pyramid of Djoser",
                TourDate = DateTime.Today.AddDays(5),
                NumberOfTickets = 3,
                TotalPrice = 54.00m,
                Status = "Confirmed"
            }
        };
    }

    /// <summary>
    /// Authenticate existing user by username or email.
    /// </summary>
    public bool Login(string usernameOrEmail, string password, out string? errorMessage)
    {
        errorMessage = null;

        var user = RegisteredUsers.FirstOrDefault(u =>
            (string.Equals(u.Username, usernameOrEmail, StringComparison.OrdinalIgnoreCase) ||
             string.Equals(u.Email, usernameOrEmail, StringComparison.OrdinalIgnoreCase)) &&
            u.Password == password);

        if (user != null)
        {
            CurrentUser = user;
            NotifyStateChanged();
            return true;
        }

        errorMessage = "Invalid credentials. Please verify your username/email and password.";
        return false;
    }

    /// <summary>
    /// Register a new user and start their session.
    /// </summary>
    public bool Register(User newUser, out string? errorMessage)
    {
        errorMessage = null;

        if (RegisteredUsers.Any(u => string.Equals(u.Username, newUser.Username, StringComparison.OrdinalIgnoreCase)))
        {
            errorMessage = "This username is already taken. Please choose another one.";
            return false;
        }

        if (RegisteredUsers.Any(u => string.Equals(u.Email, newUser.Email, StringComparison.OrdinalIgnoreCase)))
        {
            errorMessage = "An account with this email address already exists.";
            return false;
        }

        newUser.Id = _nextUserId++;
        RegisteredUsers.Add(newUser);
        CurrentUser = newUser;
        NotifyStateChanged();
        return true;
    }

    /// <summary>
    /// Log out the current user session.
    /// </summary>
    public void Logout()
    {
        CurrentUser = null;
        NotifyStateChanged();
    }

    /// <summary>
    /// Create and record a new tour booking.
    /// </summary>
    public TourBooking? CreateBooking(int pyramidId, DateTime tourDate, int numberOfTickets)
    {
        var pyramid = Pyramids.FirstOrDefault(p => p.Id == pyramidId);
        if (pyramid == null || numberOfTickets < 1)
        {
            return null;
        }

        var booking = new TourBooking
        {
            Id = _nextBookingId++,
            PyramidId = pyramid.Id,
            PyramidName = pyramid.Name,
            TourDate = tourDate,
            NumberOfTickets = numberOfTickets,
            TotalPrice = pyramid.EntryFeeUSD * numberOfTickets,
            Status = "Confirmed"
        };

        Bookings.Insert(0, booking);
        NotifyStateChanged();
        return booking;
    }

    /// <summary>
    /// Cancel an active booking by ID.
    /// </summary>
    public bool CancelBooking(int bookingId)
    {
        var booking = Bookings.FirstOrDefault(b => b.Id == bookingId);
        if (booking != null)
        {
            booking.Status = "Cancelled";
            NotifyStateChanged();
            return true;
        }
        return false;
    }

    /// <summary>
    /// Delete a booking entirely.
    /// </summary>
    public bool DeleteBooking(int bookingId)
    {
        var removed = Bookings.RemoveAll(b => b.Id == bookingId) > 0;
        if (removed)
        {
            NotifyStateChanged();
        }
        return removed;
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}

