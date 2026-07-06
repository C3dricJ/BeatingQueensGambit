using System.Collections.ObjectModel;
using BeatingQueensGambit.Core.Game;
using BeatingQueensGambit.Core.Models;
using BeatingQueensGambit.Core.Pieces;

namespace BeatingQueensGambit.UI.ViewModels;

public class ChessViewModel
{
    public ObservableCollection<SquareViewModel> Squares { get; }

    private readonly ChessGame _game;

    public ChessViewModel()
    {
        _game = new ChessGame();

        Squares = new ObservableCollection<SquareViewModel>();

        BuildBoard();
    }

    private void BuildBoard()
    {
        Squares.Clear();

        for (int row = 0; row < 8; row++)
        {
            for (int column = 0; column < 8; column++)
            {
                var position = new Position(row, column);

                Piece? piece =
                    _game.Board.GetPiece(position);

                Squares.Add(
                    new SquareViewModel(
                        row,
                        column,
                        piece));
            }
        }
    }
}