using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using BeatingQueensGambit.UI.ViewModels;

namespace BeatingQueensGambit.UI.Views;

public partial class GameOverWindow : Window
{
    public bool RestartRequested { get; private set; }

    public GameOverWindow()
    {
        InitializeComponent();
    }

    public GameOverWindow(string winner)
        : this()
    {
        DataContext = new GameOverViewModel(winner);
    }

    private void RestartClicked(
        object? sender,
        RoutedEventArgs e)
    {
        RestartRequested = true;
        Close();
    }

    private void ExitClicked(
        object? sender,
        RoutedEventArgs e)
    {
        if (Application.Current?.ApplicationLifetime
            is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }
}