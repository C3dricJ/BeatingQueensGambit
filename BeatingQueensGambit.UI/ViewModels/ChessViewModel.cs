using System.Collections.ObjectModel;
using BeatingQueensGambit.Core.Game;

namespace BeatingQueensGambit.UI.ViewModels;

public class ChessViewModel
{
    public ChessGame Game { get; }

    public ObservableCollection<SquareViewModel> Squares { get; }

    public ChessViewModel()
    {
        Game = new ChessGame();

        Squares = new ObservableCollection<SquareViewModel>();

        BuildBoard();
    }

    private void BuildBoard()
    {
        Squares.Clear();

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                Squares.Add(
                    new SquareViewModel(
                        row,
                        col,
                        Game.Board));
            }
        }
    }
}