using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using BeatingQueensGambit.UI.ViewModels;

namespace BeatingQueensGambit.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new ChessViewModel();
    }

    //----------------------------------------------------
    // Called whenever the user clicks a chess square
    //----------------------------------------------------

    private void SquarePressed(
        object? sender,
        PointerPressedEventArgs e)
    {
        if (sender is not Border border)
            return;

        if (border.DataContext is not SquareViewModel square)
            return;

        if (DataContext is ChessViewModel vm)
        {
            vm.SelectSquare(square);
        }
    }

    //----------------------------------------------------
    // Restart Button
    //----------------------------------------------------

    private void RestartGameClicked(
        object? sender,
        RoutedEventArgs e)
    {
        if (DataContext is ChessViewModel vm)
        {
            vm.RestartGame();
        }
    }
}