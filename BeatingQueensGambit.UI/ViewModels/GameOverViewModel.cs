using CommunityToolkit.Mvvm.ComponentModel;

namespace BeatingQueensGambit.UI.ViewModels;

public partial class GameOverViewModel : ObservableObject
{
    public string Winner { get; }

    public string Message { get; }

    public GameOverViewModel(string winner)
    {
        Winner = winner;

        Message = $"{winner} wins!";
    }
}