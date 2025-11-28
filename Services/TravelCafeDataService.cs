using System;
using System.Collections.Generic;
using System.Linq;
using TravelCafe.App.Models;

namespace TravelCafe.App.Services;

public class TravelCafeDataService
{
    public List<CityDestination> GetDestinations() => new()
    {
        new CityDestination
        {
            City = "Tokyo",
            Country = "Japan",
            ImagePath = "ms-appx:///Assets/Images/Cities/tokyo.jpg"
        },
        new CityDestination
        {
            City = "Paris",
            Country = "France",
            ImagePath = "ms-appx:///Assets/Images/Cities/paris.jpg"
        },
        new CityDestination
        {
            City = "Cairo",
            Country = "Egypt",
            ImagePath = "ms-appx:///Assets/Images/Cities/cairo.jpg"
        },
        new CityDestination
        {
            City = "New York",
            Country = "USA",
            ImagePath = "ms-appx:///Assets/Images/Cities/newyork.jpg"
        }
    };

    public List<Cafe> GetCafes() => new()
    {
        // Tokyo
        new Cafe
        {
            Name = "Café Sakura",
            City = "Tokyo",
            Tagline = "Matcha & espresso harmony",
            ImagePath = "ms-appx:///Assets/Images/Cafes/tokyo_sakura.jpg"
        },
        new Cafe
        {
            Name = "Shibuya Brew Lab",
            City = "Tokyo",
            Tagline = "Cold brews for neon nights",
            ImagePath = "ms-appx:///Assets/Images/Cafes/tokyo_brewlab.jpg"
        },

        // Paris
        new Cafe
        {
            Name = "Café des Arts",
            City = "Paris",
            Tagline = "Where espresso meets elegance",
            ImagePath = "ms-appx:///Assets/Images/Cafes/paris_arts.jpg"
        },
        new Cafe
        {
            Name = "Le Marais Bean Loft",
            City = "Paris",
            Tagline = "Minimalist specialty coffee",
            ImagePath = "ms-appx:///Assets/Images/Cafes/paris_loft.jpg"
        },

        // Cairo
        new Cafe
        {
            Name = "Zamalek Roasters",
            City = "Cairo",
            Tagline = "Nile-side specialty brews",
            ImagePath = "ms-appx:///Assets/Images/Cafes/cairo_zamalek.jpg"
        },

        // New York
        new Cafe
        {
            Name = "Central Perk Loft",
            City = "New York",
            Tagline = "Espresso in the concrete jungle",
            ImagePath = "ms-appx:///Assets/Images/Cafes/nyc_loft.jpg"
        }
    };

    public List<Drink> GetDrinks() => new()
    {
        // Café Sakura (Tokyo)
        new Drink
        {
            Name = "Matcha Nebula Latte",
            CafeName = "Café Sakura",
            Description = "Creamy matcha latte with a double espresso shot.",
            Price = 4.95,
            Category = "Hot",
            ImagePath = "ms-appx:///Assets/Images/Drinks/matcha_latte.jpg"
        },
        new Drink
        {
            Name = "Sakura Seasonal Blend",
            CafeName = "Café Sakura",
            Description = "Limited spring roast with floral aroma.",
            Price = 5.25,
            Category = "Seasonal",
            ImagePath = "ms-appx:///Assets/Images/Drinks/sakura_blend.jpg"
        },
        new Drink
        {
            Name = "Galaxy Mocha",
            CafeName = "Café Sakura",
            Description = "Rich chocolate & espresso with galaxy foam.",
            Price = 5.75,
            Category = "Specials",
            ImagePath = "ms-appx:///Assets/Images/Drinks/galaxy_mocha.jpg"
        },

        // Shibuya Brew Lab (Tokyo)
        new Drink
        {
            Name = "Iced Comet Cold Brew",
            CafeName = "Shibuya Brew Lab",
            Description = "Ultra-smooth cold brew over comet ice.",
            Price = 4.50,
            Category = "Iced",
            ImagePath = "ms-appx:///Assets/Images/Drinks/iced_comet_brew.jpg"
        },
        new Drink
        {
            Name = "Neon Night Nitro",
            CafeName = "Shibuya Brew Lab",
            Description = "Nitro cold brew with a creamy cascading top.",
            Price = 5.10,
            Category = "Specials",
            ImagePath = "ms-appx:///Assets/Images/Drinks/nitro_coldbrew.jpg"
        },

        // Café des Arts (Paris)
        new Drink
        {
            Name = "Seine-side Espresso Tonic",
            CafeName = "Café des Arts",
            Description = "Bright espresso over sparkling tonic.",
            Price = 5.25,
            Category = "Iced",
            ImagePath = "ms-appx:///Assets/Images/Drinks/espresso_tonic.jpg"
        },
        new Drink
        {
            Name = "Parisian Crème Cappuccino",
            CafeName = "Café des Arts",
            Description = "Silky cappuccino with vanilla crème.",
            Price = 4.80,
            Category = "Hot",
            ImagePath = "ms-appx:///Assets/Images/Drinks/cappuccino.jpg"
        },

        // Zamalek Roasters (Cairo)
        new Drink
        {
            Name = "Nile Spice Latte",
            CafeName = "Zamalek Roasters",
            Description = "Spiced latte with cardamom and cinnamon.",
            Price = 4.60,
            Category = "Hot",
            ImagePath = "ms-appx:///Assets/Images/Drinks/spiced_latte.jpg"
        },
        new Drink
        {
            Name = "Cairo Sunset Cold Brew",
            CafeName = "Zamalek Roasters",
            Description = "Cold brew with orange peel and dates.",
            Price = 4.90,
            Category = "Iced",
            ImagePath = "ms-appx:///Assets/Images/Drinks/cairo_coldbrew.jpg"
        },

        // Central Perk Loft (New York)
        new Drink
        {
            Name = "Times Square Flat White",
            CafeName = "Central Perk Loft",
            Description = "Bold double-shot flat white.",
            Price = 5.00,
            Category = "Hot",
            ImagePath = "ms-appx:///Assets/Images/Drinks/flat_white.jpg"
        },
        new Drink
        {
            Name = "Manhattan Mocha Frappe",
            CafeName = "Central Perk Loft",
            Description = "Blended mocha with crushed ice and cream.",
            Price = 5.60,
            Category = "Specials",
            ImagePath = "ms-appx:///Assets/Images/Drinks/mocha_frappe.jpg"
        }
    };

    public Cafe? GetCafeOfTheDay(string city)
    {
        var cafes = GetCafes()
            .Where(c => string.Equals(c.City, city, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (!cafes.Any())
        {
            return null;
        }

        var dayOfYear = DateTime.Today.DayOfYear;
        var index = dayOfYear % cafes.Count;
        return cafes[index];
    }

    public List<Drink> GetDrinksForCafe(string cafeName)
    {
        return GetDrinks()
            .Where(d => string.Equals(d.CafeName, cafeName, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
