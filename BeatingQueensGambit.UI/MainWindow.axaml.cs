using Avalonia.Controls;
using Avalonia.Input;
using BeatingQueensGambit.UI.ViewModels;

namespace BeatingQueensGambit.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new ChessViewModel();
    }

    private void SquarePressed(object? sender, PointerPressedEventArgs e)
    {
        if (sender is Border border &&
            border.DataContext is SquareViewModel square)
        {
            square.Parent?.SelectSquare(square);
        }
    }
}