using Avalonia.Controls;
using BeatingQueensGambit.UI.ViewModels;

namespace BeatingQueensGambit.UI.Views;

public partial class StartWindow : Window
{
    public StartWindow()
    {
        InitializeComponent();

        DataContext = new StartViewModel();
    }
}