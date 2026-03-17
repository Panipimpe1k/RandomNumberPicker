using Microsoft.Maui.Controls;
using RandomNumbers.Views;

namespace RandomNumbers;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage())
        {
            BarBackgroundColor = Color.FromArgb("#b8a6db"),
            BarTextColor = Colors.White
        };
    }
}