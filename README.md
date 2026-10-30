# 🏛️ PyramidX — Ancient Wonders & Egyptian Expedition Portal

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-InteractiveServer-512BD4?logo=blazor&logoColor=white)](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
[![Tailwind CSS](https://img.shields.io/badge/TailwindCSS-v3-38B2AC?logo=tailwind-css&logoColor=white)](https://tailwindcss.com/)
[![Repository](https://img.shields.io/badge/GitHub-PyramidX-F59E0B?logo=github&logoColor=white)](https://github.com/Houndzkie/PyramidX)

**PyramidX** is an interactive, modern web application and premier tourism booking portal dedicated to exploring the ancient monuments and UNESCO World Heritage sites of Egypt. Built with **ASP.NET Core 8 Blazor** and styled with a luxury Egyptian-inspired aesthetic, PyramidX provides tourists, archaeologists, and history enthusiasts with an immersive digital gateway to the monumental tombs of the Giza Plateau and Saqqara Necropolis.

---

## 🌟 What is PyramidX About?

PyramidX bridges 4,500 years of civilization with modern web technology, offering an end-to-end expedition planning experience:

- **Discover Ancient Engineering**: Learn about colossal wonders like the **Great Pyramid of Giza (Khufu)**, the **Pyramid of Khafre**, and the pioneering **Step Pyramid of Djoser**. Inspect architectural metrics including monument heights, historical dynasties, and visitor ratings.
- **Seamless Tour Reservations**: Book guided expeditions with instant ticket calculation, date scheduling, and real-time pass generation.
- **Reservation Management**: Track, review, and manage active booking statuses (Confirmed, Cancelled) with live summary statistics.
- **Personalized Explorer Profiles**: Member registration and authentication that tailor expeditions according to chosen interest tags like Archaeology, Sunset Tours, VIP Tomb Access, and Photography.

---

## ✨ Key Features

### 1. 📊 Explorer Dashboard
- **Key Metric Indicators**: Instant stats on total UNESCO heritage destinations, optimal travel seasons (Oct–Apr mild 24°C), active ticket passes, and aggregate visitor satisfaction ratings (4.92/5.0).
- **Interactive Promoted Pyramids Gallery**: High-definition monument cards detailing construction eras, verified ratings, entry fees, and locations.
- **Booking Modal Window**: Fast reservation modal with live subtotal calculation as ticket quantities and dates adjust.
- **Active Bookings Live Table**: Real-time management interface supporting cancellation and record deletion with reactive UI updates.

### 2. 🔐 Authentication & Session Management
- **Member Sign In (`/login`)**: Direct authentication supporting both username and email with validation alerts.
- **Explorer Registration (`/register`)**: New user onboarding with interactive, selectable interest tags:
  - *Archaeology*, *Photography*, *Sunset Tours*, *Camel Trekking*, *VIP Tomb Access*, *Nile Cruises*, *Ancient Hieroglyphs*.
- **Reactive State Flow**: Global scoped session state (`TravelDataService`) with event triggers updating the UI in real time without full page refreshes.

### 3. 🎨 Monumental Aesthetic & Visual Experience
- **Color Palette**: Custom theme blending obsidian nights (`#0B0F19`), desert sands, and luminous pharaonic gold accents (`#E5A93C`).
- **Typography**: Dual-font layout pairing **Cinzel** (classical, monumental serif) with **Plus Jakarta Sans** (crisp, modern readability).
- **Responsive Layout**: Sticky blurred glassmorphism navigation bar, responsive mobile menu drawer, and visitor advisory footer.

---

## 🛠️ Technology Stack

| Layer | Technology |
|---|---|
| **Framework** | [ASP.NET Core 8.0 Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) (InteractiveServer) |
| **Language** | C# 12 / .NET 8 SDK |
| **Frontend Styling** | Tailwind CSS + Custom CSS Glassmorphism & Gold Glow Animations |
| **Typography** | Google Fonts (*Cinzel* & *Plus Jakarta Sans*) |
| **State Management** | Scoped In-Memory Service (`TravelDataService`) with event-driven notifications (`OnChange`) |
| **Form Handling** | Blazor `EditForm` with `DataAnnotationsValidator` |

---

## 📂 Project Architecture

```
PyramidX/
├── Components/
│   ├── App.razor                 # Root HTML shell with Tailwind configuration & Google Fonts
│   ├── Routes.razor              # Blazor route view router
│   ├── _Imports.razor            # Shared namespaces & Razor directives
│   ├── Layout/
│   │   ├── MainLayout.razor      # Core shell layout with header & footer
│   │   └── NavMenu.razor         # Sticky brand header & responsive navigation
│   └── Pages/
│       ├── Dashboard.razor       # Main expedition portal, metrics & booking table
│       ├── Login.razor           # User login page with form validation
│       ├── Register.razor        # Account creation with interest preference selector
│       ├── Home.razor            # Entry route redirector
│       └── Error.razor           # Diagnostic error handling page
├── Models/
│   ├── Pyramid.cs                # Monument data model (Height, Era, Fee, Rating)
│   ├── TourBooking.cs            # Expedition reservation model (Dates, Tickets, Total)
│   └── User.cs                   # User account & explorer interest preferences model
├── Services/
│   └── TravelDataService.cs      # Central state store for monuments, auth & bookings
├── wwwroot/
│   ├── app.css                   # Custom glassmorphism, scrollbars & glow animations
│   ├── tailwindcss.js            # Tailwind runtime styling engine
│   └── favicon.png               # Brand icon
├── Program.cs                    # Application bootstrapping & service container configuration
└── Midterms.csproj               # Project dependencies & .NET 8 target
```

---

## 🚀 Getting Started Locally

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or higher.
- A modern web browser.

### Installation & Execution

1. **Clone the repository**:
   ```bash
   git clone https://github.com/Houndzkie/PyramidX.git
   cd PyramidX
   ```

2. **Restore dependencies & build**:
   ```bash
   dotnet restore
   dotnet build
   ```

3. **Run the development server**:
   ```bash
   dotnet run
   ```

4. **Open in browser**:
   Navigate to the URL output in your terminal (typically `http://localhost:5000` or `https://localhost:7000`).

---

## 🔑 Default Demo Account

For quick exploration, the application is pre-seeded with an active explorer session:

- **Username**: `RamsesExplorer`
- **Email**: `ramses@pyramids.eg`
- **Password**: `Password123!`
- **Preloaded Interests**: Archaeology, Sunset Tours, VIP Tomb Access, Photography

*(You can also log out and create any new explorer account via the Register page.)*

---

## 📜 License & Acknowledgments

- Built for **Applications Development and Emerging Technologies**.
- Content and historical imagery courtesy of Wikimedia Commons & UNESCO World Heritage documentation.
- Developed with ❤️ using **Blazor** and **Tailwind CSS**.
