using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TravelCafe.App.Models;
using TravelCafe.App.Services;

namespace TravelCafe.App.Views;

public sealed partial class MainPage : Page, INotifyPropertyChanged
{
    private readonly TravelCafeDataService _dataService = new();
    private readonly Random _random = new();

    public ObservableCollection<CityDestination> Destinations { get; } = new();
    public ObservableCollection<Drink> Drinks { get; } = new();

    private List<Drink> _allDrinks = new(); // full dataset for current café
    private string _selectedCategory = "All";

    private string? _selectedCity;
    public string? SelectedCity
    {
        get => _selectedCity;
        set
        {
            if (_selectedCity == value) return;
            _selectedCity = value;
            OnPropertyChanged();
            UpdateCafeOfTheDay();
        }
    }

    private Cafe? _cafeOfTheDay;
    public Cafe? CafeOfTheDay
    {
        get => _cafeOfTheDay;
        private set
        {
            if (_cafeOfTheDay == value) return;
            _cafeOfTheDay = value;
            OnPropertyChanged();
        }
    }

    private int _cartCount;
    public int CartCount
    {
        get => _cartCount;
        private set
        {
            if (_cartCount == value) return;
            _cartCount = value;
            OnPropertyChanged();
        }
    }

    public MainPage()
    {
        InitializeComponent();
        DataContext = this;

        LoadInitialData();
    }

    // -------- Initialization & data --------

    private void LoadInitialData()
    {
        Destinations.Clear();
        foreach (var dest in _dataService.GetDestinations())
        {
            Destinations.Add(dest);
        }

        // Default city – triggers UpdateCafeOfTheDay via setter
        SelectedCity = "Tokyo";
    }

    private void UpdateCafeOfTheDay()
    {
        if (SelectedCity is null)
        {
            CafeOfTheDay = null;
            _allDrinks = new List<Drink>();
        }
        else
        {
            CafeOfTheDay = _dataService.GetCafeOfTheDay(SelectedCity);
            _allDrinks = CafeOfTheDay is null
                ? new List<Drink>()
                : _dataService.GetDrinksForCafe(CafeOfTheDay.Name).ToList();
        }

        CafeHero.Visibility = CafeOfTheDay is null
            ? Visibility.Collapsed
            : Visibility.Visible;

        ApplyFilter();
    }

    private void ApplyFilter()
    {
        Drinks.Clear();

        IEnumerable<Drink> filtered = _allDrinks;

        if (_selectedCategory != "All")
        {
            filtered = filtered.Where(d =>
                !string.IsNullOrEmpty(d.Category) &&
                string.Equals(d.Category, _selectedCategory, StringComparison.OrdinalIgnoreCase));
        }

        foreach (var drink in filtered)
        {
            Drinks.Add(drink);
        }
    }

    // -------- UI event handlers --------

    private void ViewMenu_Click(object sender, RoutedEventArgs e)
    {
        DrinksList.UpdateLayout();
        DrinksList.StartBringIntoView();
    }

    private void DestinationCard_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { DataContext: CityDestination dest })
        {
            SelectedCity = dest.City;
        }
    }

    private void Category_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is string category)
        {
            _selectedCategory = category;
            ApplyFilter();
            UpdateChipStyles(category);
        }
    }

    private void UpdateChipStyles(string selected)
    {
        if (ChipsPanel is null) return;

        foreach (var child in ChipsPanel.Children.OfType<Button>())
        {
            var cat = child.Tag as string;
            bool isSelected = string.Equals(cat, selected, StringComparison.OrdinalIgnoreCase);

            child.Style = (Style)Application.Current.Resources[
                isSelected ? "AccentChipButtonStyle" : "ChipButtonStyle"
            ];
        }
    }

    private void AddDrinkButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { DataContext: Drink drink })
        {
            AddToCart(drink);
        }
    }

    private void AddToCart(Drink drink)
    {
        if (drink is null) return;

        CartCount++;
        StatusText.Text = $"Added {drink.Name} to cart ({CartCount})";
        StatusText.Opacity = 1;
    }

    private void SurpriseMe_Click(object sender, RoutedEventArgs e)
    {
        if (_allDrinks.Count == 0)
        {
            SuggestionText.Text = "No drinks available yet. Add some to the menu first!";
            return;
        }

        var hour = DateTime.Now.Hour;
        string preferredCategory = hour switch
        {
            >= 6 and < 12 => "Hot",
            >= 12 and < 18 => "Iced",
            _ => "Specials"
        };

        var candidates = _allDrinks
            .Where(d =>
                !string.IsNullOrEmpty(d.Category) &&
                string.Equals(d.Category, preferredCategory, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (!candidates.Any())
        {
            candidates = _allDrinks; // fallback to any
        }

        var suggestion = candidates[_random.Next(candidates.Count)];
        SuggestionText.Text = $"We think you’ll love: {suggestion.Name} ({suggestion.Category})";
    }

    // -------- INotifyPropertyChanged --------

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
