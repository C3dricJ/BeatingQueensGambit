using Avalonia.Controls;
using Avalonia.Interactivity;
using BeatingQueensGambit.UI.ViewModels;

namespace BeatingQueensGambit.UI.Views;

public partial class StartWindow : Window
{
    private readonly StartViewModel _viewModel;

    public StartWindow()
    {
        InitializeComponent();

        _viewModel = new StartViewModel();

        DataContext = _viewModel;
    }

    private void StartClicked(
        object? sender,
        RoutedEventArgs e)
    {
        var settings = _viewModel.BuildSettings();

        var game = new MainWindow(settings);

        game.Show();

        Close();
    }
}