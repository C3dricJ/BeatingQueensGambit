using Avalonia.Controls;
using BeatingQueensGambit.UI.ViewModels;

namespace BeatingQueensGambit.UI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new ChessViewModel();
    }
}