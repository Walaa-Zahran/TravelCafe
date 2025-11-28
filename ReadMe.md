☕✈️ TravelCafé
A Cross-Platform Coffee & Travel Experience Built with .NET 8 + Uno Platform
🚀 Overview

TravelCafé is a visually rich, multi-platform application built with Uno Platform and .NET 8, delivering a stylized coffee-shop experience with a travel aesthetic — all from one shared codebase.

The app features:

🌍 Runs on Windows, iOS, Android, macOS, Linux, WebAssembly

✨ Hero section with Drink of the Day

🧭 Category filters with animated list transitions

🤖 AI-style “Cosmic Suggestion” system

⚡ Smooth micro-animations (button scale, fade-in cards)

🧱 100% shared UI using XAML
✨ Features
🎨 Stunning Hero Section

A premium-looking hero card featuring:

Featured drink

Beautiful gradients

Decorative shapes & tasteful typography

✈️ Travel-Themed Café Filters

Category chips:

All

Hot

Iced

Seasonal

Specials

These trigger smooth animated transitions of drink items.

⚡ Smooth Animations

Drink cards fade + slide into view

Add button “squish” animation

Hero section transitions

🤖 AI "Cosmic Suggestion" Engine

A playful rule-based recommendation system:

Morning → Hot drinks

Afternoon → Iced drinks

Evening → Specials

Displays:

"We think you'll love: Supernova Mocha"

This can be upgraded later to real ML-driven suggestions.

🛠 Tech Stack

Uno Platform

.NET 8 / C#

WinUI XAML

Skia (desktop)

WebAssembly (browser)
📁 Project Structure
TravelCafe/
│
├── src/
│   ├── TravelCafe.App/               # Shared UI & Logic (XAML + C#)
│   │   ├── Views/
│   │   │   ├── MainPage.xaml
│   │   │   └── MainPage.xaml.cs
│   │   ├── Models/
│   │   │   └── Drink.cs
│   │   ├── Assets/
│   │   └── App.xaml
│   │
│   ├── TravelCafe.App.Skia.Gtk/      # Desktop (Windows/macOS/Linux)
│   ├── TravelCafe.App.Skia.Wasm/     # WebAssembly project
│   └── TravelCafe.App.Mobile/        # iOS & Android
│
├── assets/
│   ├── cover.png
│   ├── demo-home.gif
│   ├── demo-filter.gif
│   ├── demo-add.gif
│   ├── desktop.png
│   └── browser.png
│
└── README.md
🏗 Building the App
WebAssembly
cd src/TravelCafe.App.Skia.Wasm
dotnet run
Desktop (Skia.Gtk)
cd src/TravelCafe.App.Skia.Gtk
dotnet run
🧪 Future Enhancements

Real AI recommendations (OpenAI / Azure ML)

Cart + checkout flow

Full travel destinations browser

Animation upgrades (Lottie, transitions)
📄 License

MIT License.
