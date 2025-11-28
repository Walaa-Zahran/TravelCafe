namespace TravelCafe.App.Models;

public class Drink
{
    public string Name { get; set; }
    public string CafeName { get; set; }    // Link to Cafe by name
    public string Description { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public string ImagePath { get; set; }   // e.g. "Assets/Images/Drinks/matcha_latte.jpg"
    public string PriceDisplay => $"${Price:0.00}";

}
