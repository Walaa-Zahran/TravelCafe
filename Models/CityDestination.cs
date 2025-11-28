namespace TravelCafe.App.Models;

public class CityDestination
{
    public string City { get; set; }
    public string Country { get; set; }
    public string DisplayName => $"{City}, {Country}";
    public string ImagePath { get; set; }   // e.g. "Assets/Images/Cities/tokyo.jpg"
}
